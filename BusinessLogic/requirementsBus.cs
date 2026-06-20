using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class RequirementsBus
    {
        // 1. Insertar un nuevo requerimiento para una planta
        public static int insertar(Requirements req)
        {
            string sql = @"INSERT INTO REQUERIMIENTOS 
                           (tempAireMin, tempAireMax, humAireMin, humAireMax, humSueloMin, humSueloMax, luzMin, luzMax, idPlanta) 
                           VALUES 
                           (@tMin, @tMax, @haMin, @haMax, @hsMin, @hsMax, @lMin, @lMax, @idPlanta)";

            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@tMin", req.TempAireMin));
            parametros.Add(new SqlParameter("@tMax", req.TempAireMax));
            parametros.Add(new SqlParameter("@haMin", req.HumAireMin));
            parametros.Add(new SqlParameter("@haMax", req.HumAireMax));
            parametros.Add(new SqlParameter("@hsMin", req.HumSueloMin));
            parametros.Add(new SqlParameter("@hsMax", req.HumSueloMax));
            parametros.Add(new SqlParameter("@lMin", req.LuzMin));
            parametros.Add(new SqlParameter("@lMax", req.LuzMax));
            parametros.Add(new SqlParameter("@idPlanta", req.IdPlanta));

            return DataAccess.DataAccess.execQuery(sql, parametros);
        }

        // 2. Traer el requerimiento específico de la planta elegida
        public static List<Requirements> getRequerimientosPorPlanta(int idPlanta)
        {
            List<Requirements> lista = new List<Requirements>();
            string sql = "SELECT * FROM REQUERIMIENTOS WHERE idPlanta = @idPlanta";

            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@idPlanta", idPlanta));

            DataTable tabla = DataAccess.DataAccess.getQuery(sql, parametros);

            foreach (DataRow row in tabla.Rows)
            {
                Requirements req = new Requirements();
                req.IdRequerimientos = Convert.ToInt32(row["idRequerimientos"]);
                req.TempAireMin = Convert.ToDecimal(row["tempAireMin"]);
                req.TempAireMax = Convert.ToDecimal(row["tempAireMax"]);
                req.HumAireMin = Convert.ToDecimal(row["humAireMin"]);
                req.HumAireMax = Convert.ToDecimal(row["humAireMax"]);
                req.HumSueloMin = Convert.ToDecimal(row["humSueloMin"]);
                req.HumSueloMax = Convert.ToDecimal(row["humSueloMax"]);
                req.LuzMin = Convert.ToDecimal(row["luzMin"]);
                req.LuzMax = Convert.ToDecimal(row["luzMax"]);
                req.IdPlanta = Convert.ToInt32(row["idPlanta"]);

                lista.Add(req);
            }
            return lista;
        }
    }
}
