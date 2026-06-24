using System.Data;
using System.Data.SqlClient;
using AgroControl.Model.Entities;
using AgroControl.Model.DAO.Interfaces;

namespace AgroControl.Model.DAO.Implementations
{
    public class SensorDAO : ISensorDAO
    {
        public int Insert(Sensor sensor)
        {
            string sql = "INSERT INTO SENSORES (tipo, idInvernadero) VALUES (@tipo, @idInv)";
            var pars = new List<SqlParameter>
            {
                new("@tipo", sensor.Tipo), new("@idInv", sensor.IdInvernadero)
            };
            return DataAccess.ExecQuery(sql, pars);
        }

        public Sensor? GetById(int id)
        {
            var pars = new List<SqlParameter> { new("@id", id) };
            DataTable dt = DataAccess.GetQuery("SELECT * FROM SENSORES WHERE idSensor = @id", pars);
            if (dt.Rows.Count == 0) return null;
            var r = dt.Rows[0];
            return new Sensor
            {
                IdSensor = Convert.ToInt32(r["idSensor"]),
                Tipo = r["tipo"].ToString()!,
                IdInvernadero = Convert.ToInt32(r["idInvernadero"])
            };
        }

        public List<Sensor> GetAll()
        {
            var lista = new List<Sensor>();
            DataTable dt = DataAccess.GetQuery("SELECT * FROM SENSORES");
            foreach (DataRow r in dt.Rows)
                lista.Add(new Sensor
                {
                    IdSensor = Convert.ToInt32(r["idSensor"]),
                    Tipo = r["tipo"].ToString()!,
                    IdInvernadero = Convert.ToInt32(r["idInvernadero"])
                });
            return lista;
        }

        public List<Sensor> GetByGreenhouse(int idInv)
        {
            var lista = new List<Sensor>();
            var pars = new List<SqlParameter> { new("@id", idInv) };
            DataTable dt = DataAccess.GetQuery("SELECT * FROM SENSORES WHERE idInvernadero = @id", pars);
            foreach (DataRow r in dt.Rows)
                lista.Add(new Sensor
                {
                    IdSensor = Convert.ToInt32(r["idSensor"]),
                    Tipo = r["tipo"].ToString()!,
                    IdInvernadero = Convert.ToInt32(r["idInvernadero"])
                });
            return lista;
        }

        public void Delete(int id)
        {
            string sql = @"BEGIN TRY BEGIN TRANSACTION
                DELETE FROM LECTURA WHERE idSensor = @id;
                DELETE FROM SENSORES WHERE idSensor = @id;
            COMMIT TRANSACTION END TRY BEGIN CATCH ROLLBACK TRANSACTION; THROW; END CATCH";
            DataAccess.ExecQuery(sql, new List<SqlParameter> { new("@id", id) });
        }
    }
}
