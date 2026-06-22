using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Entities; // Asegúrate de referenciar tu capa de entidades

namespace BusinessLogic // O el namespace de tu capa de negocio
{
    public class ReadingBus
    {
        // MÉTODO 1: Insertar una nueva lectura (Ideal para cuando el hardware envía un nuevo dato)
        public static int insertar(Reading reading)
        {
            string sql = "INSERT INTO LECTURA (valor, fechaHora, idSensor) VALUES (@valor, @fecha, @idSensor)";

            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@valor", reading.Valor));
            parametros.Add(new SqlParameter("@fecha", reading.FechaHora));
            parametros.Add(new SqlParameter("@idSensor", reading.IdSensor));

            // Utilizamos estrictamente tu capa de acceso a datos
            return DataAccess.DataAccess.execQuery(sql, parametros);
        }

        // MÉTODO 2: Obtener todas las lecturas crudas en forma de lista de objetos
        public static List<Reading> getLecturas()
        {
            List<Reading> lista = new List<Reading>();
            string sql = "SELECT * FROM LECTURA ORDER BY fechaHora DESC";

            DataTable tabla = DataAccess.DataAccess.getQuery(sql);

            foreach (DataRow row in tabla.Rows)
            {
                Reading lectura = new Reading();
                lectura.IdLectura = Convert.ToInt32(row["idLectura"]);

                // Usamos Convert.ToDecimal o Convert.ToDouble según tu base de datos
                lectura.Valor = Convert.ToDecimal(row["valor"]);
                lectura.FechaHora = Convert.ToDateTime(row["fechaHora"]);
                lectura.IdSensor = Convert.ToInt32(row["idSensor"]);

                lista.Add(lectura);
            }
            return lista;
        }

        // MÉTODO 3: Obtener el historial pivoteado para el DataGridView (El que arreglamos antes)
        public static DataTable getHistorialPivot()
        {
            string sql = @"
                SELECT 
                    L.fechaHora AS 'Fecha y hora',
                    MAX(CASE WHEN S.tipo = 'humSuelo' THEN L.valor END) AS 'Humedad del suelo',
                    MAX(CASE WHEN S.tipo = 'tempAire' THEN L.valor END) AS 'Temperatura',
                    MAX(CASE WHEN S.tipo = 'humAire' THEN L.valor END) AS 'Humedad del aire',
                    MAX(CASE WHEN S.tipo = 'luz' THEN L.valor END) AS 'Intensidad de luz'
                FROM LECTURA L
                INNER JOIN SENSORES S ON L.idSensor = S.idSensor
                GROUP BY L.fechaHora
                ORDER BY L.fechaHora DESC";

            return DataAccess.DataAccess.getQuery(sql);
        }

        public static DataTable getHistorialPivot(int idInvernadero)
        {
            string sql = @"
                SELECT 
                    L.fechaHora AS 'Fecha y hora',
                    MAX(CASE WHEN S.tipo = 'humSuelo' THEN L.valor END) AS 'Humedad del suelo',
                    MAX(CASE WHEN S.tipo = 'tempAire' THEN L.valor END) AS 'Temperatura',
                    MAX(CASE WHEN S.tipo = 'humAire' THEN L.valor END) AS 'Humedad del aire',
                    MAX(CASE WHEN S.tipo = 'luz' THEN L.valor END) AS 'Intensidad de luz'
                FROM LECTURA L
                INNER JOIN SENSORES S ON L.idSensor = S.idSensor
                WHERE S.idInvernadero = @idInv
                GROUP BY L.fechaHora
                ORDER BY L.fechaHora DESC";

            List<SqlParameter> parametros = new List<SqlParameter> { new SqlParameter("@idInv", idInvernadero) };
            return DataAccess.DataAccess.getQuery(sql, parametros);
        }
    }
}
