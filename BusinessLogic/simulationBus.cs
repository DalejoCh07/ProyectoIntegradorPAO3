using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BusinessLogic
{
    public class SimulationBus
    {
        // CONSTANTES DEL MODELO 
        private const double C = 10.0;
        private const double alpha = 0.5;
        private const double alpha2 = 0.8;
        private const double beta = 0.1;
        private const double gamma = 2.0;
        private const double eta = 1.5;

        private const double kr = 5.0;
        private const double kd = 0.5;
        private const double ke = 0.1;

        private const double kh = 4.0;
        private const double kv = 1.2;
        private const double ks = 0.8;

        private const double kL = 500.0;

        private static double CalcularEvaporacion(double T, double Ha)
        {
            return (T > 0 ? T : 0) * ((100.0 - Ha) / 100.0);
        }

        // Modificamos el método para recibir el ID del invernadero
        public static (double[] fechas, double[] tempAire, double[] humAire, double[] humSuelo, double[] luzTotal)
            GenerarCurvasModelo(int idInvernadero)
        {
            // 1. EXTRAER ESTADOS DE LOS ACTUADORES DESDE LA BASE DE DATOS
            string sqlActuadores = "SELECT tipo, estado FROM ACTUADOR WHERE idInvernadero = @idInv";
            List<SqlParameter> paramAct = new List<SqlParameter> { new SqlParameter("@idInv", idInvernadero) };
            DataTable dtActuadores = DataAccess.DataAccess.getQuery(sqlActuadores, paramAct);

            double L = 0;       // Foco LED
            double V = 0;       // Ventilador
            double S_servo = 0; // Apertura
            double R_bomba = 0; // Bomba
            double U_hum = 0;   // Humidificador

            foreach (DataRow row in dtActuadores.Rows)
            {
                string tipo = row["tipo"].ToString().ToLower();

                // Conversión segura del estado (asumiendo que puede ser bit, int o decimal en SQL)
                double estadoValor = 0;
                if (row["estado"] != DBNull.Value)
                {
                    // Si el estado es un booleano (bit), lo convertimos a 1.0 o 0.0, sino intentamos extraer el número
                    if (row["estado"] is bool b) estadoValor = b ? 1.0 : 0.0;
                    else double.TryParse(row["estado"].ToString(), out estadoValor);
                }

                // Asignamos el valor a la variable correspondiente según el tipo registrado en la BD
                // Asegúrate de que los textos coincidan con los que guardas en tu columna 'tipo'
                if (tipo.Contains("foco") || tipo.Contains("lampara") || tipo.Contains("luz")) L = estadoValor;
                else if (tipo.Contains("ventilador")) V = estadoValor;
                else if (tipo.Contains("servo") || tipo.Contains("compuerta") || tipo.Contains("apertura")) S_servo = estadoValor;
                else if (tipo.Contains("bomba") || tipo.Contains("riego")) R_bomba = estadoValor;
                else if (tipo.Contains("humidificador")) U_hum = estadoValor;
            }

            // 2. EXTRAER HISTORIAL DE LECTURAS PARA EL ESTADO INICIAL
            string sqlLecturas = @"
                SELECT TOP 100 
                    L.fechaHora,
                    MAX(CASE WHEN S.tipo = 'tempAire' THEN L.valor END) AS T,
                    MAX(CASE WHEN S.tipo = 'humAire' THEN L.valor END) AS Ha,
                    MAX(CASE WHEN S.tipo = 'humSuelo' THEN L.valor END) AS Hs,
                    MAX(CASE WHEN S.tipo = 'luz' THEN L.valor END) AS I
                FROM LECTURA L
                INNER JOIN SENSORES S ON L.idSensor = S.idSensor
                WHERE S.idInvernadero = @idInv
                GROUP BY L.fechaHora
                ORDER BY L.fechaHora ASC";

            List<SqlParameter> paramLec = new List<SqlParameter> { new SqlParameter("@idInv", idInvernadero) };
            DataTable dtLecturas = DataAccess.DataAccess.getQuery(sqlLecturas, paramLec);

            int n = dtLecturas.Rows.Count;

            double[] fechas = new double[n];
            double[] tempAire = new double[n];
            double[] humAire = new double[n];
            double[] humSuelo = new double[n];
            double[] luzTotal = new double[n];

            if (n == 0) return (fechas, tempAire, humAire, humSuelo, luzTotal);

            DataRow primeraFila = dtLecturas.Rows[0];
            double T_actual = primeraFila["T"] != DBNull.Value ? Convert.ToDouble(primeraFila["T"]) : 25.0;
            double Ha_actual = primeraFila["Ha"] != DBNull.Value ? Convert.ToDouble(primeraFila["Ha"]) : 60.0;
            double Hs_actual = primeraFila["Hs"] != DBNull.Value ? Convert.ToDouble(primeraFila["Hs"]) : 40.0;

            double dt_step = 1.0;

            // 3. EJECUTAR EL BUCLE DE LA SIMULACIÓN CON LOS VALORES FIJOS DE LA BD
            for (int i = 0; i < n; i++)
            {
                DataRow row = dtLecturas.Rows[i];
                fechas[i] = Convert.ToDateTime(row["fechaHora"]).ToOADate();

                double I_real = row["I"] != DBNull.Value ? Convert.ToDouble(row["I"]) : 0;

                // LUZ TOTAL
                luzTotal[i] = I_real + (kL * L);

                // TEMPERATURA AIRE
                double dT_dt = (1.0 / C) * ((alpha * I_real) + (alpha2 * L) - (beta * T_actual) - (gamma * V) - (eta * S_servo));
                T_actual += dT_dt * dt_step;
                tempAire[i] = T_actual;

                // HUMEDAD SUELO
                double evaporacion = CalcularEvaporacion(T_actual, Ha_actual);
                double dHs_dt = (kr * R_bomba) - (kd * Hs_actual) - (ke * evaporacion);
                Hs_actual += dHs_dt * dt_step;
                Hs_actual = Math.Max(0, Math.Min(100, Hs_actual));
                humSuelo[i] = Hs_actual;

                // HUMEDAD AIRE
                double dHa_dt = (kh * U_hum) + (ke * Hs_actual) - (kv * V * Ha_actual) - (ks * S_servo * Ha_actual);
                Ha_actual += dHa_dt * dt_step;
                Ha_actual = Math.Max(0, Math.Min(100, Ha_actual));
                humAire[i] = Ha_actual;
            }

            return (fechas, tempAire, humAire, humSuelo, luzTotal);
        }

        public static double CalcularTemperaturaModelo(double Hs, double t)
        {
            return -0.08 * Hs + 0.03 * t + 30.0;
        }

        public static (double[] tiempos, double[] tempReal, double[] tempModelo) ObtenerComparacionModelo(int idInvernadero)
        {
            string sql = @"
                SELECT TOP 50 
                    DATEDIFF(MINUTE, MIN(fechaHora) OVER(), fechaHora) AS Tiempo,
                    MAX(CASE WHEN S.tipo = 'humSuelo' THEN L.valor END) AS Hs,
                    MAX(CASE WHEN S.tipo = 'tempAire' THEN L.valor END) AS TempReal
                FROM LECTURA L
                INNER JOIN SENSORES S ON L.idSensor = S.idSensor
                WHERE S.idInvernadero = @idInv
                GROUP BY L.fechaHora
                ORDER BY L.fechaHora ASC";

            List<SqlParameter> param = new List<SqlParameter> { new SqlParameter("@idInv", idInvernadero) };
            DataTable df = DataAccess.DataAccess.getQuery(sql, param);
            int n = df.Rows.Count;

            double[] tiempos = new double[n];
            double[] tempReal = new double[n];
            double[] tempModelo = new double[n];

            // Arrays para análisis interno (equivalente a tu df["Error"])
            double[] error = new double[n];

            for (int i = 0; i < n; i++)
            {
                DataRow row = df.Rows[i];

                // Extraemos valores asegurando que no sean nulos
                tiempos[i] = row["Tiempo"] != DBNull.Value ? Convert.ToDouble(row["Tiempo"]) : 0;
                double Hs_actual = row["Hs"] != DBNull.Value ? Convert.ToDouble(row["Hs"]) : 40.0;
                tempReal[i] = row["TempReal"] != DBNull.Value ? Convert.ToDouble(row["TempReal"]) : 25.0;

                // Aplicamos el modelo: df.apply(lambda row: temperatura(...))
                tempModelo[i] = CalcularTemperaturaModelo(Hs_actual, tiempos[i]);

                // Cálculo del error: df["Error"] = abs(real - calculada)
                error[i] = Math.Abs(tempReal[i] - tempModelo[i]);
            }

            // Aquí podrías imprimir o guardar el error promedio si lo necesitas para un reporte
            // double errorPromedio = error.Average();

            return (tiempos, tempReal, tempModelo);
        }
    }
}