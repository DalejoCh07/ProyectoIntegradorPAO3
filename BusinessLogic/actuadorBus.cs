using Entities;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BusinessLogic
{
    public class ActuadorBus
    {
        public static int insertar(Actuador act)
        {
            string sql = "INSERT INTO ACTUADOR (tipo, idInvernadero, estado) VALUES (@tipo, @idInv, @estado)";
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@tipo", act.Tipo));
            parametros.Add(new SqlParameter("@idInv", act.IdInvernadero));
            parametros.Add(new SqlParameter("@estado", act.Estado ?? "OFF"));
            return DataAccess.DataAccess.execQuery(sql, parametros);
        }

        public static List<Actuador> getActuadores()
        {
            List<Actuador> lista = new List<Actuador>();
            DataTable dt = DataAccess.DataAccess.getQuery("SELECT * FROM ACTUADOR");
            foreach (DataRow r in dt.Rows)
            {
                lista.Add(new Actuador(
                    (int)r["idActuador"],
                    r["tipo"].ToString(),
                    (int)r["idInvernadero"],
                    r["estado"].ToString()
                ));
            }
            return lista;
        }

        public static List<Actuador> getActuadoresPorInvernadero(int idInvernadero)
        {
            List<Actuador> lista = new List<Actuador>();
            string sql = "SELECT * FROM ACTUADOR WHERE idInvernadero = @id";
            List<SqlParameter> pars = new List<SqlParameter> { new SqlParameter("@id", idInvernadero) };
            DataTable dt = DataAccess.DataAccess.getQuery(sql, pars);
            foreach (DataRow r in dt.Rows)
            {
                lista.Add(new Actuador(
                    (int)r["idActuador"],
                    r["tipo"].ToString(),
                    (int)r["idInvernadero"],
                    r["estado"].ToString()
                ));
            }
            return lista;
        }

        public static void eliminar(int id)
        {
            List<SqlParameter> pars = new List<SqlParameter> { new SqlParameter("@id", id) };
            DataAccess.DataAccess.execQuery("DELETE FROM ACTUADOR WHERE idActuador = @id", pars);
        }
    }
}
