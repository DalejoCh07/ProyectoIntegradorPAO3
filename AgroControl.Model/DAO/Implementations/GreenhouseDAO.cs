using System.Data;
using System.Data.SqlClient;
using AgroControl.Model.Entities;
using AgroControl.Model.DAO.Interfaces;

namespace AgroControl.Model.DAO.Implementations
{
    public class GreenhouseDAO : IGreenhouseDAO
    {
        public int Insert(Greenhouse gh)
        {
            string sql = "INSERT INTO INVERNADERO (nombre, ubicacion, descripcion) VALUES (@nom, @ubi, @desc)";
            var pars = new List<SqlParameter>
            {
                new("@nom", gh.Nombre),
                new("@ubi", gh.Ubicacion),
                new("@desc", string.IsNullOrEmpty(gh.Descripcion) ? (object)DBNull.Value : gh.Descripcion)
            };
            return DataAccess.ExecQuery(sql, pars);
        }

        public List<Greenhouse> GetAll()
        {
            var lista = new List<Greenhouse>();
            DataTable dt = DataAccess.GetQuery("SELECT * FROM INVERNADERO");
            foreach (DataRow r in dt.Rows)
                lista.Add(new Greenhouse
                {
                    IdInvernadero = (int)r["idInvernadero"],
                    Nombre = r["nombre"].ToString()!,
                    Ubicacion = r["ubicacion"].ToString()!,
                    Descripcion = r["descripcion"].ToString()!
                });
            return lista;
        }

        public List<Greenhouse> Search(string nombre)
        {
            var lista = new List<Greenhouse>();
            var pars = new List<SqlParameter> { new("@nom", "%" + nombre + "%") };
            DataTable dt = DataAccess.GetQuery("SELECT * FROM INVERNADERO WHERE nombre LIKE @nom", pars);
            foreach (DataRow r in dt.Rows)
                lista.Add(new Greenhouse
                {
                    IdInvernadero = (int)r["idInvernadero"],
                    Nombre = r["nombre"].ToString()!,
                    Ubicacion = r["ubicacion"].ToString()!,
                    Descripcion = r["descripcion"].ToString()!
                });
            return lista;
        }

        public void Delete(int id)
        {
            string sql = @"BEGIN TRY BEGIN TRANSACTION
                DELETE FROM ACCION WHERE idActuador IN (SELECT idActuador FROM ACTUADOR WHERE idInvernadero = @id);
                DELETE FROM ACTUADOR WHERE idInvernadero = @id;
                DELETE FROM LECTURA WHERE idSensor IN (SELECT idSensor FROM SENSORES WHERE idInvernadero = @id);
                DELETE FROM SENSORES WHERE idInvernadero = @id;
                DELETE FROM LOTES WHERE idInvernadero = @id;
                DELETE FROM INVERNADERO WHERE idInvernadero = @id;
            COMMIT TRANSACTION END TRY BEGIN CATCH ROLLBACK TRANSACTION; THROW; END CATCH";
            DataAccess.ExecQuery(sql, new List<SqlParameter> { new("@id", id) });
        }
    }
}
