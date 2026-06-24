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
    ConectarSerial(ref port, comPort, baudRate);
}

if (modoSimulacion)
{
    Console.ForegroundColor = ConsoleColor.DarkYellow;
    Console.WriteLine("MODO SIMULACION activado. Generando datos cada 2 segundos.");
    Console.ResetColor();
    Console.WriteLine("(Conecta el Arduino y ejecuta sin --simulate para modo real)\n");
}

Console.WriteLine($"SQL Server: {connectionString}");
Console.WriteLine("Presiona Ctrl+C para salir.\n");

// ---- BUCLE PRINCIPAL ----
while (true)
{
    try
    {
        float temp = 0, humAire = 0;
        int humSuelo = 0, luz = 0, bomba = 0, vent = 0, humi = 0, lampara = 0;
        bool hayDatos = false;

        if (!modoSimulacion)
        {
            if (port == null || !port.IsOpen)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] Reconectando serial en 5 seg...");
                Console.ResetColor();
                Thread.Sleep(5000);
                ConectarSerial(ref port, comPort, baudRate);
                continue;
            }

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
            hayDatos = true;
        }
        else if (modoSimulacion)
        {
            // === MODO SIMULACION: Generar datos realistas ===
            cicloSimulacion++;
            Thread.Sleep(2000);

            temp = 28.0f + (float)(rnd.NextDouble() * 4.0 - 2.0);
            humAire = 60.0f + (float)(rnd.NextDouble() * 10.0 - 5.0);
            humSuelo = 65 + rnd.Next(-10, 10);
            luz = 15000 + rnd.Next(-5000, 5000);
            bomba = humSuelo < 30 ? 1 : 0;
            vent = temp > 30.0 ? 1 : 0;
            humi = humAire < 40.0 ? 1 : 0;
            lampara = luz < 200 ? 1 : 0;
            hayDatos = true;

            if (cicloSimulacion % 5 == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine($"[SIMULACION] Generando datos ciclo #{cicloSimulacion}...");
                Console.ResetColor();
            }
        }

        if (!hayDatos) continue;

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
    catch (InvalidOperationException)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"\n[{DateTime.Now:HH:mm:ss}] ERROR: Arduino desconectado. Reintentando en 5 seg...");
        Console.ResetColor();
        try { port?.Close(); port?.Dispose(); } catch { }
        port = null;
    }
    catch (Exception ex) { Console.WriteLine($"Error: {ex.Message}"); Thread.Sleep(1000); }
}

static void ConectarSerial(ref SerialPort? port, string comPort, int baudRate)
{
    if (port != null)
    {
        try { port.Close(); } catch { }
        try { port.Dispose(); } catch { }
        port = null;
    }

    try
    {
        port = new SerialPort(comPort, baudRate) { ReadTimeout = 3000, DtrEnable = true, RtsEnable = true };
        port.Open();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] Conectado a {comPort} a {baudRate} baud.");
        Console.ResetColor();
    }
    catch
    {
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.Write($"[{DateTime.Now:HH:mm:ss}] {comPort} no disponible, escaneando puertos... ");
        string[] ports = SerialPort.GetPortNames();
        Console.ResetColor();
        bool conectado = false;
        foreach (string p in ports)
        {
            if (string.Equals(p, comPort, StringComparison.OrdinalIgnoreCase)) continue;
            try
            {
                port = new SerialPort(p, baudRate) { ReadTimeout = 3000, DtrEnable = true, RtsEnable = true };
                port.Open();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Conectado a {p}!");
                Console.ResetColor();
                conectado = true;
                break;
            }
            catch { port = null; }
        }
        if (!conectado)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Ningun puerto disponible.");
            Console.ResetColor();
        }
    }
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
