using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Entities; // Asegúrate de importar tus entidades

namespace BusinessLogic // O el namespace de tu capa de negocio
{
    public class AccionBus
    {
        // Insertar un nuevo registro de acción
        public static int insertar(Accion accion)
        {
            string sql = "INSERT INTO ACCION (tipoAccion, fechaHora, duracion, idActuador) VALUES (@tipo, @fecha, @duracion, @idActuador)";

            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@tipo", accion.TipoAccion));
            parametros.Add(new SqlParameter("@fecha", accion.FechaHora));
            parametros.Add(new SqlParameter("@duracion", accion.Duracion));
            parametros.Add(new SqlParameter("@idActuador", accion.IdActuador));

            // Utiliza tu método centralizado de DataAccess
            return DataAccess.DataAccess.execQuery(sql, parametros);
        }

        // Obtener el historial completo de acciones (ordenado del más reciente al más antiguo)
        public static List<Accion> getAcciones()
        {
            List<Accion> lista = new List<Accion>();
            string sql = "SELECT * FROM ACCION ORDER BY fechaHora DESC";

            DataTable tabla = DataAccess.DataAccess.getQuery(sql);

            foreach (DataRow row in tabla.Rows)
            {
                Accion accion = new Accion();
                accion.IdAccion = Convert.ToInt32(row["idAccion"]);
                accion.TipoAccion = row["tipoAccion"].ToString();
                accion.FechaHora = Convert.ToDateTime(row["fechaHora"]);
                accion.Duracion = Convert.ToInt32(row["duracion"]);
                accion.IdActuador = Convert.ToInt32(row["idActuador"]);

                lista.Add(accion);
            }
            return lista;
        }

        public static List<Accion> getAccionesPorInvernadero(int idInvernadero)
        {
            List<Accion> lista = new List<Accion>();
            string sql = @"
                SELECT A.* FROM ACCION A
                INNER JOIN ACTUADOR AD ON A.idActuador = AD.idActuador
                WHERE AD.idInvernadero = @idInv
                ORDER BY A.fechaHora DESC";

            List<SqlParameter> parametros = new List<SqlParameter> { new SqlParameter("@idInv", idInvernadero) };

            DataTable tabla = DataAccess.DataAccess.getQuery(sql, parametros);

            foreach (DataRow row in tabla.Rows)
            {
                Accion accion = new Accion();
                accion.IdAccion = Convert.ToInt32(row["idAccion"]);
                accion.TipoAccion = row["tipoAccion"].ToString();
                accion.FechaHora = Convert.ToDateTime(row["fechaHora"]);
                accion.Duracion = Convert.ToInt32(row["duracion"]);
                accion.IdActuador = Convert.ToInt32(row["idActuador"]);
                lista.Add(accion);
            }
            return lista;
        }

        // Obtener historial filtrado por un actuador específico
        public static List<Accion> getAccionesPorActuador(int idActuador)
        {
            List<Accion> lista = new List<Accion>();
            string sql = "SELECT * FROM ACCION WHERE idActuador = @idActuador ORDER BY fechaHora DESC";

            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@idActuador", idActuador));

            DataTable tabla = DataAccess.DataAccess.getQuery(sql, parametros);

            foreach (DataRow row in tabla.Rows)
            {
                Accion accion = new Accion();
                accion.IdAccion = Convert.ToInt32(row["idAccion"]);
                accion.TipoAccion = row["tipoAccion"].ToString();
                accion.FechaHora = Convert.ToDateTime(row["fechaHora"]);
                accion.Duracion = Convert.ToInt32(row["duracion"]);
                accion.IdActuador = Convert.ToInt32(row["idActuador"]);

                lista.Add(accion);
            }
            return lista;
        }
    }
}
