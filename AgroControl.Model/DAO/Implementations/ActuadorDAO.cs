using System.Data;
using System.Data.SqlClient;
using AgroControl.Model.Entities;
using AgroControl.Model.DAO.Interfaces;

namespace AgroControl.Model.DAO.Implementations
{
    public class ActuadorDAO : IActuadorDAO
    {
        public int Insert(Actuador act)
        {
            string sql = "INSERT INTO ACTUADOR (tipo, idInvernadero, estado) VALUES (@tipo, @idInv, @estado)";
            var pars = new List<SqlParameter>
            {
                new("@tipo", act.Tipo),
                new("@idInv", act.IdInvernadero),
                new("@estado", act.Estado ?? "OFF")
            };
            return DataAccess.ExecQuery(sql, pars);
        }

        public List<Actuador> GetAll()
        {
            var lista = new List<Actuador>();
            DataTable dt = DataAccess.GetQuery("SELECT * FROM ACTUADOR");
            foreach (DataRow r in dt.Rows)
                lista.Add(new Actuador
                {
                    IdActuador = (int)r["idActuador"],
                    Tipo = r["tipo"].ToString()!,
                    IdInvernadero = (int)r["idInvernadero"],
                    Estado = r["estado"].ToString()!
                });
            return lista;
        }

        public List<Actuador> GetByGreenhouse(int idInv)
        {
            var lista = new List<Actuador>();
            var pars = new List<SqlParameter> { new("@id", idInv) };
            DataTable dt = DataAccess.GetQuery("SELECT * FROM ACTUADOR WHERE idInvernadero = @id", pars);
            foreach (DataRow r in dt.Rows)
                lista.Add(new Actuador
                {
                    IdActuador = (int)r["idActuador"],
                    Tipo = r["tipo"].ToString()!,
                    IdInvernadero = (int)r["idInvernadero"],
                    Estado = r["estado"].ToString()!
                });
            return lista;
        }

        public void Delete(int id)
        {
            var pars = new List<SqlParameter> { new("@id", id) };
            DataAccess.ExecQuery("DELETE FROM ACTUADOR WHERE idActuador = @id", pars);
        }

        public string GetEstado(int idActuador, int idInv)
        {
            string sql = "SELECT estado FROM ACTUADOR WHERE idActuador = @id AND idInvernadero = @idInv";
            var pars = new List<SqlParameter>
            {
                new("@id", idActuador), new("@idInv", idInv)
            };
            DataTable dt = DataAccess.GetQuery(sql, pars);
            if (dt.Rows.Count > 0) return dt.Rows[0]["estado"].ToString()!.ToLower();
            return "off";
        }

        public void SetEstado(int idActuador, int idInv, string estado)
        {
            string sql = "UPDATE ACTUADOR SET estado = @estado WHERE idActuador = @id AND idInvernadero = @idInv";
            var pars = new List<SqlParameter>
            {
                new("@estado", estado), new("@id", idActuador), new("@idInv", idInv)
            };
            DataAccess.ExecQuery(sql, pars);
        }
    }
}
