using System.Data;
using System.Data.SqlClient;
using AgroControl.Model.Entities;
using AgroControl.Model.DAO.Interfaces;

namespace AgroControl.Model.DAO.Implementations
{
    public class AccionDAO : IAccionDAO
    {
        public int Insert(Accion accion)
        {
            string sql = "INSERT INTO ACCION (tipoAccion, fechaHora, duracion, idActuador) VALUES (@tipo, @fecha, @duracion, @idActuador)";
            var pars = new List<SqlParameter>
            {
                new("@tipo", accion.TipoAccion),
                new("@fecha", accion.FechaHora),
                new("@duracion", accion.Duracion),
                new("@idActuador", accion.IdActuador)
            };
            return DataAccess.ExecQuery(sql, pars);
        }

        public List<Accion> GetAll()
        {
            var lista = new List<Accion>();
            DataTable dt = DataAccess.GetQuery("SELECT * FROM ACCION ORDER BY fechaHora DESC");
            foreach (DataRow r in dt.Rows)
                lista.Add(new Accion
                {
                    IdAccion = Convert.ToInt32(r["idAccion"]),
                    TipoAccion = r["tipoAccion"].ToString()!,
                    FechaHora = Convert.ToDateTime(r["fechaHora"]),
                    Duracion = Convert.ToInt32(r["duracion"]),
                    IdActuador = Convert.ToInt32(r["idActuador"])
                });
            return lista;
        }

        public List<Accion> GetByGreenhouse(int idInv)
        {
            var lista = new List<Accion>();
            string sql = @"SELECT A.* FROM ACCION A INNER JOIN ACTUADOR AD ON A.idActuador = AD.idActuador
                WHERE AD.idInvernadero = @idInv ORDER BY A.fechaHora DESC";
            DataTable dt = DataAccess.GetQuery(sql, new List<SqlParameter> { new("@idInv", idInv) });
            foreach (DataRow r in dt.Rows)
                lista.Add(new Accion
                {
                    IdAccion = Convert.ToInt32(r["idAccion"]),
                    TipoAccion = r["tipoAccion"].ToString()!,
                    FechaHora = Convert.ToDateTime(r["fechaHora"]),
                    Duracion = Convert.ToInt32(r["duracion"]),
                    IdActuador = Convert.ToInt32(r["idActuador"])
                });
            return lista;
        }

        public List<Accion> GetByActuador(int idActuador)
        {
            var lista = new List<Accion>();
            var pars = new List<SqlParameter> { new("@idActuador", idActuador) };
            DataTable dt = DataAccess.GetQuery("SELECT * FROM ACCION WHERE idActuador = @idActuador ORDER BY fechaHora DESC", pars);
            foreach (DataRow r in dt.Rows)
                lista.Add(new Accion
                {
                    IdAccion = Convert.ToInt32(r["idAccion"]),
                    TipoAccion = r["tipoAccion"].ToString()!,
                    FechaHora = Convert.ToDateTime(r["fechaHora"]),
                    Duracion = Convert.ToInt32(r["duracion"]),
                    IdActuador = Convert.ToInt32(r["idActuador"])
                });
            return lista;
        }
    }
}
