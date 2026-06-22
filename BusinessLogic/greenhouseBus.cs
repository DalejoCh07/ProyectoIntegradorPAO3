using Entities;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BusinessLogic
{
    public class GreenhouseBus
    {
        public static int insertar(Greenhouse gh)
        {
            string sql = "INSERT INTO INVERNADERO (nombre, ubicacion, descripcion) VALUES (@nom, @ubi, @desc)";
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@nom", gh.Nombre));
            parametros.Add(new SqlParameter("@ubi", gh.Ubicacion));
            parametros.Add(new SqlParameter("@desc", string.IsNullOrEmpty(gh.Descripcion) ? (object)DBNull.Value : gh.Descripcion));
            return DataAccess.DataAccess.execQuery(sql, parametros);
        }

        public static List<Greenhouse> getGreenhouses()
        {
            List<Greenhouse> lista = new List<Greenhouse>();
            DataTable dt = DataAccess.DataAccess.getQuery("SELECT * FROM INVERNADERO");
            foreach (DataRow r in dt.Rows)
            {
                lista.Add(new Greenhouse(
                    (int)r["idInvernadero"],
                    r["nombre"].ToString(),
                    r["ubicacion"].ToString(),
                    r["descripcion"].ToString()
                ));
            }
            return lista;
        }

        public static List<Greenhouse> buscar(string nombre)
        {
            List<Greenhouse> lista = new List<Greenhouse>();
            List<SqlParameter> pars = new List<SqlParameter> { new SqlParameter("@nom", "%" + nombre + "%") };
            DataTable dt = DataAccess.DataAccess.getQuery("SELECT * FROM INVERNADERO WHERE nombre LIKE @nom", pars);
            foreach (DataRow r in dt.Rows)
            {
                lista.Add(new Greenhouse(
                    (int)r["idInvernadero"],
                    r["nombre"].ToString(),
                    r["ubicacion"].ToString(),
                    r["descripcion"].ToString()
                ));
            }
            return lista;
        }

        public static void eliminar(int id)
        {
            string sql = @"
                BEGIN TRY
                    BEGIN TRANSACTION
                        DELETE FROM SENSOR WHERE idInvernadero = @id;
                        DELETE FROM ACTUADOR WHERE idInvernadero = @id;
                        DELETE FROM INVERNADERO WHERE idInvernadero = @id;
                    COMMIT TRANSACTION
                END TRY
                BEGIN CATCH
                    ROLLBACK TRANSACTION;
                    THROW;
                END CATCH";
            List<SqlParameter> parametros = new List<SqlParameter> { new SqlParameter("@id", id) };
            DataAccess.DataAccess.execQuery(sql, parametros);
        }
    }
}
