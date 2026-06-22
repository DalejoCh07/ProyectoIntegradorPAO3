using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Entities;

namespace BusinessLogic
{
    public class BatchBus
    {
        // 1. Obtener el lote activo (el que NO tiene fecha de cosecha)
        public static Batch obtenerLoteActivo(int idInvernadero)
        {
            string sql = @"
        SELECT L.idLote, L.cantPlantas, L.fechaSiembra, L.idPlanta, P.nombre AS nombrePlanta 
        FROM LOTES L
        INNER JOIN PLANTA P ON L.idPlanta = P.idPlanta
        WHERE L.idInvernadero = @idInv AND L.fechaCosecha IS NULL"; // Corregido aquí

            List<SqlParameter> parametros = new List<SqlParameter> { new SqlParameter("@idInv", idInvernadero) };
            DataTable dt = DataAccess.DataAccess.getQuery(sql, parametros);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                return new Batch
                {
                    IdLote = Convert.ToInt32(row["idLote"]),
                    CantPlantas = Convert.ToInt32(row["cantPlantas"]),
                    FechaSiembra = Convert.ToDateTime(row["fechaSiembra"]),
                    IdPlanta = Convert.ToInt32(row["idPlanta"]),
                    NombrePlanta = row["nombrePlanta"].ToString()
                };
            }
            return null; // No hay lote activo
        }

        // 2. Insertar un nuevo lote
        public static void insertarLote(Batch lote)
        {
            string sql = "INSERT INTO LOTES (cantPlantas, fechaSiembra, fechaCosecha, idInvernadero, idPlanta) VALUES (@cant, @fechaS, NULL, @idInv, @idPlanta)";

            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@cant", lote.CantPlantas));
            parametros.Add(new SqlParameter("@fechaS", lote.FechaSiembra));
            parametros.Add(new SqlParameter("@idInv", lote.IdInvernadero));
            parametros.Add(new SqlParameter("@idPlanta", lote.IdPlanta));

            DataAccess.DataAccess.execQuery(sql, parametros);
        }

        // 3. Finalizar el lote (Actualiza la fecha de cosecha con la fecha actual)
        public static void finalizarLote(int idLote)
        {
            string sql = "UPDATE LOTES SET fechaCosecha = @fechaC WHERE idLote = @idLote";
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@fechaC", DateTime.Now));
            parametros.Add(new SqlParameter("@idLote", idLote));

            DataAccess.DataAccess.execQuery(sql, parametros);
        }

        // 4. Historial completo de lotes (Para el DataGridView)
        public static DataTable obtenerHistorial(int idInvernadero)
        {
            string sql = @"
                SELECT 
                    L.idLote,
                    P.nombre AS 'Planta',
                    L.cantPlantas AS 'Cantidad',
                    L.fechaSiembra AS 'Fecha de Siembra',
                    L.fechaCosecha AS 'Fecha de Cosecha'
                FROM LOTES L
                INNER JOIN PLANTA P ON L.idPlanta = P.idPlanta
                WHERE L.idInvernadero = @idInv
                ORDER BY L.fechaSiembra DESC";

            List<SqlParameter> parametros = new List<SqlParameter> { new SqlParameter("@idInv", idInvernadero) };
            return DataAccess.DataAccess.getQuery(sql, parametros);
        }
    }
}
