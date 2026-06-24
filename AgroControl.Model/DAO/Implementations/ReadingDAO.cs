using System.Data;
using System.Data.SqlClient;
using AgroControl.Model.Entities;
using AgroControl.Model.DAO.Interfaces;

namespace AgroControl.Model.DAO.Implementations
{
    public class ReadingDAO : IReadingDAO
    {
        public int Insert(Reading reading)
        {
            string sql = "INSERT INTO LECTURA (valor, fechaHora, idSensor) VALUES (@valor, @fecha, @idSensor)";
            var pars = new List<SqlParameter>
            {
                new("@valor", reading.Valor),
                new("@fecha", reading.FechaHora),
                new("@idSensor", reading.IdSensor)
            };
            return DataAccess.ExecQuery(sql, pars);
        }

        public List<Reading> GetAll()
        {
            var lista = new List<Reading>();
            DataTable dt = DataAccess.GetQuery("SELECT * FROM LECTURA ORDER BY fechaHora DESC");
            foreach (DataRow r in dt.Rows)
                lista.Add(new Reading
                {
                    IdLectura = Convert.ToInt32(r["idLectura"]),
                    Valor = Convert.ToDecimal(r["valor"]),
                    FechaHora = Convert.ToDateTime(r["fechaHora"]),
                    IdSensor = Convert.ToInt32(r["idSensor"])
                });
            return lista;
        }

        public DataTable GetHistorialPivot(int idInv)
        {
            string sql = @"SELECT L.fechaHora AS 'Fecha y hora',
                MAX(CASE WHEN S.tipo = 'humSuelo' THEN L.valor END) AS 'Humedad del suelo',
                MAX(CASE WHEN S.tipo = 'tempAire' THEN L.valor END) AS 'Temperatura',
                MAX(CASE WHEN S.tipo = 'humAire' THEN L.valor END) AS 'Humedad del aire',
                MAX(CASE WHEN S.tipo = 'luz' THEN L.valor END) AS 'Intensidad de luz'
                FROM LECTURA L INNER JOIN SENSORES S ON L.idSensor = S.idSensor
                WHERE S.idInvernadero = @idInv
                GROUP BY L.fechaHora ORDER BY L.fechaHora DESC";
            return DataAccess.GetQuery(sql, new List<SqlParameter> { new("@idInv", idInv) });
        }

        public DataTable GetEstadisticas(DateTime desde, DateTime hasta, int idInv)
        {
            string sql = @"SELECT S.tipo AS Sensor, COUNT(L.valor) AS Muestras,
                CAST(ROUND(MIN(L.valor), 1) AS DECIMAL(10,1)) AS Minimo,
                CAST(ROUND(AVG(L.valor), 1) AS DECIMAL(10,1)) AS Promedio,
                CAST(ROUND(MAX(L.valor), 1) AS DECIMAL(10,1)) AS Maximo
                FROM LECTURA L INNER JOIN SENSORES S ON L.idSensor = S.idSensor
                WHERE S.idInvernadero = @idInv AND L.fechaHora BETWEEN @desde AND @hasta
                GROUP BY S.tipo ORDER BY S.tipo";
            var pars = new List<SqlParameter>
            {
                new("@idInv", idInv), new("@desde", desde), new("@hasta", hasta)
            };
            return DataAccess.GetQuery(sql, pars);
        }

        public decimal GetUltimaLectura(int idSensor, int idInv)
        {
            string sql = @"SELECT TOP 1 L.valor FROM LECTURA L
                INNER JOIN SENSORES S ON L.idSensor = S.idSensor
                WHERE S.idInvernadero = @idInv AND L.idSensor = @idSensor
                ORDER BY L.fechaHora DESC";
            var pars = new List<SqlParameter>
            {
                new("@idInv", idInv), new("@idSensor", idSensor)
            };
            DataTable dt = DataAccess.GetQuery(sql, pars);
            if (dt.Rows.Count > 0) return Convert.ToDecimal(dt.Rows[0]["valor"]);
            return 0;
        }
    }
}
