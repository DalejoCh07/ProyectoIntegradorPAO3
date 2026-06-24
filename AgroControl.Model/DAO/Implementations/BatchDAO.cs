using System.Data;
using System.Data.SqlClient;
using AgroControl.Model.Entities;
using AgroControl.Model.DAO.Interfaces;

namespace AgroControl.Model.DAO.Implementations
{
    public class BatchDAO : IBatchDAO
    {
        public Batch? GetActivo(int idInv)
        {
            string sql = @"SELECT L.idLote, L.cantPlantas, L.fechaSiembra, L.idPlanta, P.nombre AS nombrePlanta
                FROM LOTES L INNER JOIN PLANTA P ON L.idPlanta = P.idPlanta
                WHERE L.idInvernadero = @idInv AND L.fechaCosecha IS NULL";
            DataTable dt = DataAccess.GetQuery(sql, new List<SqlParameter> { new("@idInv", idInv) });
            if (dt.Rows.Count == 0) return null;
            var r = dt.Rows[0];
            return new Batch
            {
                IdLote = Convert.ToInt32(r["idLote"]),
                CantPlantas = Convert.ToInt32(r["cantPlantas"]),
                FechaSiembra = Convert.ToDateTime(r["fechaSiembra"]),
                IdPlanta = Convert.ToInt32(r["idPlanta"]),
                NombrePlanta = r["nombrePlanta"].ToString()!
            };
        }

        public void Insert(Batch lote)
        {
            string sql = "INSERT INTO LOTES (cantPlantas, fechaSiembra, fechaCosecha, idInvernadero, idPlanta) VALUES (@cant, @fechaS, NULL, @idInv, @idPlanta)";
            var pars = new List<SqlParameter>
            {
                new("@cant", lote.CantPlantas), new("@fechaS", lote.FechaSiembra),
                new("@idInv", lote.IdInvernadero), new("@idPlanta", lote.IdPlanta)
            };
            DataAccess.ExecQuery(sql, pars);
        }

        public void Finalizar(int idLote)
        {
            var pars = new List<SqlParameter> { new("@fechaC", DateTime.Now), new("@idLote", idLote) };
            DataAccess.ExecQuery("UPDATE LOTES SET fechaCosecha = @fechaC WHERE idLote = @idLote", pars);
        }

        public DataTable GetHistorial(int idInv)
        {
            string sql = @"SELECT L.idLote, P.nombre AS 'Planta', L.cantPlantas AS 'Cantidad',
                L.fechaSiembra AS 'Fecha de Siembra', L.fechaCosecha AS 'Fecha de Cosecha'
                FROM LOTES L INNER JOIN PLANTA P ON L.idPlanta = P.idPlanta
                WHERE L.idInvernadero = @idInv ORDER BY L.fechaSiembra DESC";
            return DataAccess.GetQuery(sql, new List<SqlParameter> { new("@idInv", idInv) });
        }
    }
}
