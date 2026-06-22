using Entities;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BusinessLogic
{
    public class PlantBus
    {
        public static int insertar(Plant planta)
        {
            string sql = "INSERT INTO PLANTA (nombre, nombreCien, descripcion) VALUES (@nombre, @nombreCien, @descripcion)";
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@nombre", planta.Nombre));
            parametros.Add(new SqlParameter("@nombreCien", planta.NombreCien));
            parametros.Add(new SqlParameter("@descripcion", string.IsNullOrEmpty(planta.Descripcion) ? (object)DBNull.Value : planta.Descripcion));
            return DataAccess.DataAccess.execQuery(sql, parametros);
        }

        public static Plant getPlanta(int idPlanta)
        {
            Plant planta = null;
            string sql = "SELECT * FROM PLANTA WHERE idPlanta = @id";
            List<SqlParameter> parametros = new List<SqlParameter> { new SqlParameter("@id", idPlanta) };
            DataTable tabla = DataAccess.DataAccess.getQuery(sql, parametros);
            if (tabla.Rows.Count > 0)
            {
                DataRow row = tabla.Rows[0];
                planta = new Plant();
                planta.IdPlanta = Convert.ToInt32(row["idPlanta"]);
                planta.Nombre = row["nombre"].ToString();
                planta.NombreCien = row["nombreCien"].ToString();
                planta.Descripcion = row["descripcion"].ToString();
            }
            return planta;
        }

        public static List<Plant> getPlantas()
        {
            List<Plant> lista = new List<Plant>();
            DataTable tabla = DataAccess.DataAccess.getQuery("SELECT * FROM PLANTA");
            foreach (DataRow row in tabla.Rows)
            {
                Plant planta = new Plant();
                planta.IdPlanta = Convert.ToInt32(row["idPlanta"]);
                planta.Nombre = row["nombre"].ToString();
                planta.NombreCien = row["nombreCien"].ToString();
                planta.Descripcion = row["descripcion"].ToString();
                lista.Add(planta);
            }
            return lista;
        }

        public static List<Plant> buscar(string nombre)
        {
            List<Plant> lista = new List<Plant>();
            string sql = "SELECT * FROM PLANTA WHERE nombre LIKE @nombre";
            List<SqlParameter> parametros = new List<SqlParameter> { new SqlParameter("@nombre", "%" + nombre + "%") };
            DataTable tabla = DataAccess.DataAccess.getQuery(sql, parametros);
            foreach (DataRow row in tabla.Rows)
            {
                Plant planta = new Plant();
                planta.IdPlanta = Convert.ToInt32(row["idPlanta"]);
                planta.Nombre = row["nombre"].ToString();
                planta.NombreCien = row["nombreCien"].ToString();
                planta.Descripcion = row["descripcion"].ToString();
                lista.Add(planta);
            }
            return lista;
        }

        public static void eliminar(int idPlanta)
        {
            string sql = @"
                BEGIN TRY
                    BEGIN TRANSACTION
                        DELETE FROM REQUERIMIENTOS WHERE idPlanta = @id;
                        DELETE FROM PLANTA WHERE idPlanta = @id;
                    COMMIT TRANSACTION
                END TRY
                BEGIN CATCH
                    ROLLBACK TRANSACTION;
                    THROW;
                END CATCH";
            List<SqlParameter> parametros = new List<SqlParameter> { new SqlParameter("@id", idPlanta) };
            DataAccess.DataAccess.execQuery(sql, parametros);
        }
    }
}
