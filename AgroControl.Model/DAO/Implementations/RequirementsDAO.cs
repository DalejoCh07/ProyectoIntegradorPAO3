using System.Data;
using System.Data.SqlClient;
using AgroControl.Model.Entities;
using AgroControl.Model.DAO.Interfaces;

namespace AgroControl.Model.DAO.Implementations
{
    public class RequirementsDAO : IRequirementsDAO
    {
        public int Insert(Requirements req)
        {
            string sql = @"INSERT INTO REQUERIMIENTOS (tempAireMin, tempAireMax, humAireMin, humAireMax, humSueloMin, humSueloMax, luzMin, luzMax, idPlanta)
                VALUES (@tMin, @tMax, @haMin, @haMax, @hsMin, @hsMax, @lMin, @lMax, @idPlanta)";
            var pars = new List<SqlParameter>
            {
                new("@tMin", req.TempAireMin), new("@tMax", req.TempAireMax),
                new("@haMin", req.HumAireMin), new("@haMax", req.HumAireMax),
                new("@hsMin", req.HumSueloMin), new("@hsMax", req.HumSueloMax),
                new("@lMin", req.LuzMin), new("@lMax", req.LuzMax),
                new("@idPlanta", req.IdPlanta)
            };
            return DataAccess.ExecQuery(sql, pars);
        }

        public List<Requirements> GetByPlant(int idPlanta)
        {
            var lista = new List<Requirements>();
            var pars = new List<SqlParameter> { new("@idPlanta", idPlanta) };
            DataTable dt = DataAccess.GetQuery("SELECT * FROM REQUERIMIENTOS WHERE idPlanta = @idPlanta", pars);
            foreach (DataRow r in dt.Rows)
                lista.Add(new Requirements
                {
                    IdRequerimientos = Convert.ToInt32(r["idRequerimientos"]),
                    TempAireMin = Convert.ToDecimal(r["tempAireMin"]),
                    TempAireMax = Convert.ToDecimal(r["tempAireMax"]),
                    HumAireMin = Convert.ToDecimal(r["humAireMin"]),
                    HumAireMax = Convert.ToDecimal(r["humAireMax"]),
                    HumSueloMin = Convert.ToDecimal(r["humSueloMin"]),
                    HumSueloMax = Convert.ToDecimal(r["humSueloMax"]),
                    LuzMin = Convert.ToDecimal(r["luzMin"]),
                    LuzMax = Convert.ToDecimal(r["luzMax"]),
                    IdPlanta = Convert.ToInt32(r["idPlanta"])
                });
            return lista;
        }
    }
}
