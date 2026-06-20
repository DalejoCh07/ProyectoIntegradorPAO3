using System.Data;
using System.Data.SqlClient;
using System.IO.Ports;
using System.Globalization;

Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine("============================================");
Console.WriteLine("  AgroControl - Puente Serial a SQL Server  ");
Console.WriteLine("============================================");
Console.ResetColor();

string connectionString = "server=localhost\\SQLDEVELOPER; Database=agroControl; Trusted_Connection=True;";
string comPort = args.Contains("--port") ? args[Array.IndexOf(args, "--port") + 1] : "COM3";
int baudRate = 9600;
bool modoSimulacion = args.Contains("--simulate") || args.Contains("-s");
Random rnd = new();
DateTime ultimaLectura = DateTime.MinValue;
int cicloSimulacion = 0;

// ---- INTENTAR CONEXION SERIAL ----
SerialPort? port = null;
if (!modoSimulacion)
{
    try
    {
        port = new SerialPort(comPort, baudRate) { ReadTimeout = 3000, DtrEnable = true, RtsEnable = true };
        port.Open();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Conectado a {comPort} a {baudRate} baud.");
        Console.ResetColor();
        Console.WriteLine("Modo: Arduino REAL. Enviando datos a SQL Server...\n");
    }
    catch (Exception ex)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"No se pudo conectar a {comPort}: {ex.Message}");
        modoSimulacion = true;
    }
}

if (modoSimulacion)
{
    Console.ForegroundColor = ConsoleColor.DarkYellow;
    Console.WriteLine("MODO SIMULACION activado. Generando datos cada 5 segundos.");
    Console.ResetColor();
    Console.WriteLine("(Usa --simulate para forzar, o conecta el Arduino para modo real)\n");
}

Console.WriteLine($"SQL Server: {connectionString}");
Console.WriteLine("Presiona Ctrl+C para salir.\n");

// ---- BUCLE PRINCIPAL ----
while (true)
{
    try
    {
        float temp, humAire;
        int humSuelo, luz, bomba, vent, humi, lampara;

        if (!modoSimulacion && port != null && port.IsOpen)
        {
            // === MODO REAL: Leer desde Arduino ===
            string? line = port.ReadLine()?.Trim();
            if (string.IsNullOrEmpty(line)) { Thread.Sleep(100); continue; }

            string[] parts = line.Split(',');
            if (parts.Length < 4) continue;

            temp = float.Parse(parts[0], CultureInfo.InvariantCulture);
            humAire = float.Parse(parts[1], CultureInfo.InvariantCulture);
            humSuelo = int.Parse(parts[2]);
            luz = int.Parse(parts[3]);
            bomba = parts.Length > 4 ? int.Parse(parts[4]) : 0;
            vent = parts.Length > 5 ? int.Parse(parts[5]) : 0;
            humi = parts.Length > 6 ? int.Parse(parts[6]) : 0;
            lampara = parts.Length > 7 ? int.Parse(parts[7]) : 0;
        }
        else
        {
            // === MODO SIMULACION: Generar datos realistas ===
            cicloSimulacion++;
            Thread.Sleep(5000);

            temp = 28.0f + (float)(rnd.NextDouble() * 4.0 - 2.0);         // 26-30°C
            humAire = 60.0f + (float)(rnd.NextDouble() * 10.0 - 5.0);     // 55-65%
            humSuelo = 65 + rnd.Next(-10, 10);                              // 55-75%
            luz = 15000 + rnd.Next(-5000, 5000);                            // 10000-20000 lx

            // Simular actuadores según condiciones
            bomba = humSuelo < 30 ? 1 : 0;
            vent = temp > 30.0 ? 1 : 0;
            humi = humAire < 40.0 ? 1 : 0;
            lampara = luz < 200 ? 1 : 0;

            if (cicloSimulacion % 5 == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine($"[SIMULACION] Generando datos ciclo #{cicloSimulacion}...");
                Console.ResetColor();
            }
        }

        // === INSERTAR EN SQL SERVER ===
        DateTime ahora = DateTime.Now;

        using SqlConnection conn = new(connectionString);
        conn.Open();

        InsertLectura(conn, (decimal)temp, ahora, 22);
        InsertLectura(conn, (decimal)humAire, ahora, 21);
        InsertLectura(conn, (decimal)humSuelo, ahora, 20);
        InsertLectura(conn, (decimal)luz, ahora, 23);

        string estadoBomba = ObtenerEstadoActual(conn, 1);
        string estadoVent = ObtenerEstadoActual(conn, 2);
        string estadoHum = ObtenerEstadoActual(conn, 3);
        string estadoLuz = ObtenerEstadoActual(conn, 4);

        if (modoSimulacion || bomba != (estadoBomba == "ON" ? 1 : 0))
            UpdateActuador(conn, 1, bomba == 1);
        if (modoSimulacion || vent != (estadoVent == "ON" ? 1 : 0))
            UpdateActuador(conn, 2, vent == 1);
        if (modoSimulacion || humi != (estadoHum == "ON" ? 1 : 0))
            UpdateActuador(conn, 3, humi == 1);
        if (modoSimulacion || lampara != (estadoLuz == "ON" ? 1 : 0))
            UpdateActuador(conn, 4, lampara == 1);

        conn.Close();

        double diffMs = ultimaLectura == DateTime.MinValue ? 0 : (ahora - ultimaLectura).TotalMilliseconds;
        ultimaLectura = ahora;

        Console.ForegroundColor = ConsoleColor.White;
        Console.Write($"[{ahora:HH:mm:ss}] ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write($"T:{temp,6:F1}°C ");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write($"HA:{humAire,5:F0}% ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write($"HS:{humSuelo,3}% ");
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.Write($"Luz:{luz,5}lx ");
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.Write($"| B:{bomba} V:{vent} H:{humi} L:{lampara} ");
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine(ultimaLectura == DateTime.MinValue ? "" : $"(+{diffMs:F0}ms)");
        Console.ResetColor();
    }
    catch (TimeoutException) { /* Sin datos serial, continuar */ }
    catch (FormatException ex) { Console.WriteLine($"Error formato: {ex.Message}"); }
    catch (Exception ex) { Console.WriteLine($"Error: {ex.Message}"); Thread.Sleep(1000); }
}

static void InsertLectura(SqlConnection conn, decimal valor, DateTime fecha, int idSensor)
{
    using SqlCommand cmd = new(
        "INSERT INTO LECTURA (valor, fechaHora, idSensor) VALUES (@valor, @fecha, @idSensor)", conn);
    cmd.Parameters.AddWithValue("@valor", valor);
    cmd.Parameters.AddWithValue("@fecha", fecha);
    cmd.Parameters.AddWithValue("@idSensor", idSensor);
    cmd.ExecuteNonQuery();
}

static void UpdateActuador(SqlConnection conn, int idActuador, bool encendido)
{
    string estado = encendido ? "ON" : "OFF";
    using SqlCommand cmd = new(
        "UPDATE ACTUADOR SET estado = @estado WHERE idActuador = @id", conn);
    cmd.Parameters.AddWithValue("@estado", estado);
    cmd.Parameters.AddWithValue("@id", idActuador);
    cmd.ExecuteNonQuery();
}

static string ObtenerEstadoActual(SqlConnection conn, int idActuador)
{
    using SqlCommand cmd = new(
        "SELECT estado FROM ACTUADOR WHERE idActuador = @id", conn);
    cmd.Parameters.AddWithValue("@id", idActuador);
    object? result = cmd.ExecuteScalar();
    return result?.ToString()?.ToUpper() ?? "OFF";
}
