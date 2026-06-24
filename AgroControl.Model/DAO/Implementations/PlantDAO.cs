using System.Data;
using System.Data.SqlClient;
using AgroControl.Model.Entities;
using AgroControl.Model.DAO.Interfaces;

namespace AgroControl.Model.DAO.Implementations
{
    public class PlantDAO : IPlantDAO
    {
        public int Insert(Plant plant)
        {
            string sql = "INSERT INTO PLANTA (nombre, nombreCien, descripcion) VALUES (@nombre, @nombreCien, @descripcion)";
            var pars = new List<SqlParameter>
            {
                new("@nombre", plant.Nombre),
                new("@nombreCien", plant.NombreCien),
                new("@descripcion", string.IsNullOrEmpty(plant.Descripcion) ? (object)DBNull.Value : plant.Descripcion)
            };
            return DataAccess.ExecQuery(sql, pars);
        }

        public Plant? GetById(int id)
        {
            var pars = new List<SqlParameter> { new("@id", id) };
            DataTable dt = DataAccess.GetQuery("SELECT * FROM PLANTA WHERE idPlanta = @id", pars);
            if (dt.Rows.Count == 0) return null;
            var r = dt.Rows[0];
            return new Plant
            {
                IdPlanta = Convert.ToInt32(r["idPlanta"]),
                Nombre = r["nombre"].ToString()!,
                NombreCien = r["nombreCien"].ToString()!,
                Descripcion = r["descripcion"].ToString()!
            };
        }

        public List<Plant> GetAll()
        {
            var lista = new List<Plant>();
            DataTable dt = DataAccess.GetQuery("SELECT * FROM PLANTA");
            foreach (DataRow r in dt.Rows)
                lista.Add(new Plant
                {
                    IdPlanta = Convert.ToInt32(r["idPlanta"]),
                    Nombre = r["nombre"].ToString()!,
                    NombreCien = r["nombreCien"].ToString()!,
                    Descripcion = r["descripcion"].ToString()!
                });
            return lista;
        }

        public List<Plant> Search(string nombre)
        {
            var lista = new List<Plant>();
            var pars = new List<SqlParameter> { new("@nombre", "%" + nombre + "%") };
            DataTable dt = DataAccess.GetQuery("SELECT * FROM PLANTA WHERE nombre LIKE @nombre", pars);
            foreach (DataRow r in dt.Rows)
                lista.Add(new Plant
                {
                    IdPlanta = Convert.ToInt32(r["idPlanta"]),
                    Nombre = r["nombre"].ToString()!,
                    NombreCien = r["nombreCien"].ToString()!,
                    Descripcion = r["descripcion"].ToString()!
                });
            return lista;
        }

        public void Delete(int id)
        {
            string sql = @"BEGIN TRY BEGIN TRANSACTION
                DELETE FROM REQUERIMIENTOS WHERE idPlanta = @id;
                DELETE FROM PLANTA WHERE idPlanta = @id;
            COMMIT TRANSACTION END TRY BEGIN CATCH ROLLBACK TRANSACTION; THROW; END CATCH";
            DataAccess.ExecQuery(sql, new List<SqlParameter> { new("@id", id) });
        }
    }
}
