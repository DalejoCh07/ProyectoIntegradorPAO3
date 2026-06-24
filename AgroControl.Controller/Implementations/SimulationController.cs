using System.Data;
using System.Data.SqlClient;
using AgroControl.Controller.Interfaces;

namespace AgroControl.Controller.Implementations
{
    public class SimulationController : ISimulationController
    {
        private const double C = 10.0, alpha = 0.5, alpha2 = 0.8, beta = 0.1, gamma = 2.0, eta = 1.5;
        private const double kr = 5.0, kd = 0.5, ke = 0.1, kh = 4.0, kv = 1.2, ks = 0.8, kL = 500.0;

        public (double[] fechas, double[] tempAire, double[] humAire, double[] humSuelo, double[] luzTotal)
            GenerarCurvas(int idInvernadero)
        {
            string sqlAct = "SELECT tipo, estado FROM ACTUADOR WHERE idInvernadero = @idInv";
            DataTable dtAct = Model.DataAccess.GetQuery(sqlAct, new List<SqlParameter> { new("@idInv", idInvernadero) });
            double L = 0, V = 0, S_servo = 0, R_bomba = 0, U_hum = 0;
            foreach (DataRow r in dtAct.Rows)
            {
                string tipo = r["tipo"].ToString()!.ToLower();
                double val = 0;
                if (r["estado"] != DBNull.Value)
                {
                    if (r["estado"] is bool b) val = b ? 1.0 : 0.0;
                    else double.TryParse(r["estado"].ToString(), out val);
                }
                if (tipo.Contains("foco") || tipo.Contains("lampara") || tipo.Contains("luz")) L = val;
                else if (tipo.Contains("ventilador")) V = val;
                else if (tipo.Contains("servo") || tipo.Contains("compuerta") || tipo.Contains("apertura")) S_servo = val;
                else if (tipo.Contains("bomba") || tipo.Contains("riego")) R_bomba = val;
                else if (tipo.Contains("humidificador")) U_hum = val;
            }

            string sqlLec = @"SELECT TOP 100 L.fechaHora,
                MAX(CASE WHEN S.tipo = 'tempAire' THEN L.valor END) AS T,
                MAX(CASE WHEN S.tipo = 'humAire' THEN L.valor END) AS Ha,
                MAX(CASE WHEN S.tipo = 'humSuelo' THEN L.valor END) AS Hs,
                MAX(CASE WHEN S.tipo = 'luz' THEN L.valor END) AS I
                FROM LECTURA L INNER JOIN SENSORES S ON L.idSensor = S.idSensor
                WHERE S.idInvernadero = @idInv GROUP BY L.fechaHora ORDER BY L.fechaHora ASC";
            DataTable dtLec = Model.DataAccess.GetQuery(sqlLec, new List<SqlParameter> { new("@idInv", idInvernadero) });
            int n = dtLec.Rows.Count;
            double[] fechas = new double[n], tempAire = new double[n], humAire = new double[n], humSuelo = new double[n], luzTotal = new double[n];
            if (n == 0) return (fechas, tempAire, humAire, humSuelo, luzTotal);

            var first = dtLec.Rows[0];
            double T = first["T"] != DBNull.Value ? Convert.ToDouble(first["T"]) : 25.0;
            double Ha = first["Ha"] != DBNull.Value ? Convert.ToDouble(first["Ha"]) : 60.0;
            double Hs = first["Hs"] != DBNull.Value ? Convert.ToDouble(first["Hs"]) : 40.0;

            for (int i = 0; i < n; i++)
            {
                var r = dtLec.Rows[i];
                fechas[i] = Convert.ToDateTime(r["fechaHora"]).ToOADate();
                double I_real = r["I"] != DBNull.Value ? Convert.ToDouble(r["I"]) : 0;
                luzTotal[i] = I_real + kL * L;
                double evap = (T > 0 ? T : 0) * ((100.0 - Ha) / 100.0);
                T += (1.0 / C) * ((alpha * I_real) + (alpha2 * L) - (beta * T) - (gamma * V) - (eta * S_servo));
                tempAire[i] = T;
                Hs += (kr * R_bomba) - (kd * Hs) - (ke * evap);
                Hs = Math.Max(0, Math.Min(100, Hs));
                humSuelo[i] = Hs;
                Ha += (kh * U_hum) + (ke * Hs) - (kv * V * Ha) - (ks * S_servo * Ha);
                Ha = Math.Max(0, Math.Min(100, Ha));
                humAire[i] = Ha;
            }
            return (fechas, tempAire, humAire, humSuelo, luzTotal);
        }

        public (double[] tiempos, double[] tempReal, double[] tempModelo, double[] humedadSuelo) ObtenerComparacion(int idInvernadero)
        {
            string sql = @"SELECT TOP 50 DATEDIFF(MINUTE, MIN(fechaHora) OVER(), fechaHora) AS Tiempo,
                MAX(CASE WHEN S.tipo = 'humSuelo' THEN L.valor END) AS Hs,
                MAX(CASE WHEN S.tipo = 'tempAire' THEN L.valor END) AS TempReal
                FROM LECTURA L INNER JOIN SENSORES S ON L.idSensor = S.idSensor
                WHERE S.idInvernadero = @idInv GROUP BY L.fechaHora ORDER BY L.fechaHora ASC";
            DataTable dt = Model.DataAccess.GetQuery(sql, new List<SqlParameter> { new("@idInv", idInvernadero) });
            int n = dt.Rows.Count;
            double[] tiempos = new double[n], tempReal = new double[n], tempModelo = new double[n], humedadSuelo = new double[n];
            for (int i = 0; i < n; i++)
            {
                var r = dt.Rows[i];
                tiempos[i] = r["Tiempo"] != DBNull.Value ? Convert.ToDouble(r["Tiempo"]) : 0;
                double hs = r["Hs"] != DBNull.Value ? Convert.ToDouble(r["Hs"]) : 40.0;
                humedadSuelo[i] = hs;
                tempReal[i] = r["TempReal"] != DBNull.Value ? Convert.ToDouble(r["TempReal"]) : 25.0;
                tempModelo[i] = -0.08 * hs + 0.03 * tiempos[i] + 30.0;
            }
            return (tiempos, tempReal, tempModelo, humedadSuelo);
        }
    }
}
