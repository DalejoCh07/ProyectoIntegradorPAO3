using System.Data.SqlClient;
using System.IO.Ports;

namespace AgroControl
{
    public class SerialReaderService
    {
        private Thread? _thread;
        private volatile bool _running;
        private readonly string _connectionString;
        private readonly int _idInvernadero;
        public string Status { get; private set; } = "Stopped";
        public DateTime? UltimaLectura { get; private set; }

        public SerialReaderService(int idInvernadero)
        {
            _idInvernadero = idInvernadero;
            _connectionString = AgroControl.Model.DataAccess.ConnectionString;
        }

        public void Start()
        {
            if (_running) return;
            _running = true;
            _thread = new Thread(Ejecutar) { IsBackground = true, Name = "SerialReader" };
            _thread.Start();
        }

        public void Stop()
        {
            _running = false;
            _thread?.Join(3000);
            _thread = null;
        }

        private void Ejecutar()
        {
            GarantizarSensores();

            while (_running)
            {
                try
                {
                    using var port = AbrirPuerto();
                    if (port == null)
                    {
                        Status = "No COM port available, retrying in 5s...";
                        Thread.Sleep(5000);
                        continue;
                    }

                    Status = $"Connected to {port.PortName}";
                    while (_running && port.IsOpen)
                    {
                        string? line = port.ReadLine()?.Trim();
                        if (string.IsNullOrEmpty(line)) continue;

                        var parts = line.Split(',');
                        if (parts.Length < 4) continue;

                        var temp = float.Parse(parts[0], System.Globalization.CultureInfo.InvariantCulture);
                        var humAire = float.Parse(parts[1], System.Globalization.CultureInfo.InvariantCulture);
                        var humSuelo = int.Parse(parts[2]);
                        var luz = int.Parse(parts[3]);

                        var ahora = DateTime.Now;
                        InsertLectura((decimal)temp, ahora, 22);
                        InsertLectura((decimal)humAire, ahora, 21);
                        InsertLectura((decimal)humSuelo, ahora, 20);
                        InsertLectura((decimal)luz, ahora, 23);
                        UltimaLectura = ahora;
                        Status = $"Reading OK - T:{temp:F1} HA:{humAire:F0} HS:{humSuelo} Luz:{luz}";
                    }
                }
                catch (TimeoutException) { }
                catch (InvalidOperationException)
                {
                    Status = "Arduino disconnected, reconnecting in 3s...";
                    Thread.Sleep(3000);
                }
                catch (Exception ex)
                {
                    Status = $"Error: {ex.Message}";
                    Thread.Sleep(3000);
                }
            }

            Status = "Stopped";
        }

        private SerialPort? AbrirPuerto()
        {
            string[] ports = SerialPort.GetPortNames();
            foreach (string p in ports)
            {
                try
                {
                    var port = new SerialPort(p, 9600) { ReadTimeout = 3000, DtrEnable = true, RtsEnable = true };
                    port.Open();
                    return port;
                }
                catch { }
            }
            return null;
        }

        private void InsertLectura(decimal valor, DateTime fecha, int idSensor)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(
                "INSERT INTO LECTURA (valor, fechaHora, idSensor) VALUES (@valor, @fecha, @idSensor)", conn);
            cmd.Parameters.AddWithValue("@valor", valor);
            cmd.Parameters.AddWithValue("@fecha", fecha);
            cmd.Parameters.AddWithValue("@idSensor", idSensor);
            conn.Open();
            cmd.ExecuteNonQuery();
        }

        private void GarantizarSensores()
        {
            try
            {
                var ids = new[] { 20, 21, 22, 23 };
                var tipos = new[] { "humSuelo", "humAire", "tempAire", "luz" };
                for (int i = 0; i < ids.Length; i++)
                {
                    using var c = new SqlConnection(_connectionString);
                    c.Open();
                    using var chk = new SqlCommand("SELECT COUNT(*) FROM SENSORES WHERE idSensor = @id", c);
                    chk.Parameters.AddWithValue("@id", ids[i]);
                    if ((int)chk.ExecuteScalar()! == 0)
                    {
                        using var ins = new SqlCommand(
                            "INSERT INTO SENSORES (idSensor, tipo, idInvernadero) VALUES (@id, @tipo, @inv)", c);
                        ins.Parameters.AddWithValue("@id", ids[i]);
                        ins.Parameters.AddWithValue("@tipo", tipos[i]);
                        ins.Parameters.AddWithValue("@inv", _idInvernadero);
                        ins.ExecuteNonQuery();
                    }
                }
            }
            catch { }
        }
    }
}
