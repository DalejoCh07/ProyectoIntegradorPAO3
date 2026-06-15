using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class PlantBus
    {
        // Insertar una nueva planta (idPlanta se omite por ser IDENTITY)
        public static int insertar(Plant planta)
        {
            string sql = "INSERT INTO PLANTA (nombre, nombreCien, descripcion) VALUES (@nombre, @nombreCien, @descripcion)";

            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@nombre", planta.Nombre));
            parametros.Add(new SqlParameter("@nombreCien", planta.NombreCien));
            parametros.Add(new SqlParameter("@descripcion", string.IsNullOrEmpty(planta.Descripcion) ? (object)DBNull.Value : planta.Descripcion));

            return DataAccess.DataAccess.execQuery(sql, parametros);
        }

        // Obtener una sola planta por su ID
        public static PlantBus getPlanta(int idPlanta)
        {
            PlantBus planta = null;
            string sql = "SELECT * FROM PLANTA WHERE idPlanta = @id";

            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@id", idPlanta));

            DataTable tabla = DataAccess.DataAccess.getQuery(sql, parametros);

            if (tabla.Rows.Count > 0)
            {
                DataRow row = tabla.Rows[0];
                planta = new PlantBus();
                planta.IdPlanta = Convert.ToInt32(row["idPlanta"]);
                planta.Nombre = row["nombre"].ToString();
                planta.NombreCien = row["nombreCien"].ToString();
                planta.Descripcion = row["descripcion"].ToString();
            }
            return planta;
        }

        // Obtener la lista completa de plantas
        public static List<PlantBus> getPlantas()
        {
            List<PlantBus> lista = new List<PlantBus>();
            string sql = "SELECT * FROM PLANTA";

            DataTable tabla = DataAccess.DataAccess.getQuery(sql);

            foreach (DataRow row in tabla.Rows)
            {
                PlantBus planta = new PlantBus();
                planta.IdPlanta = Convert.ToInt32(row["idPlanta"]);
                planta.Nombre = row["nombre"].ToString();
                planta.NombreCien = row["nombreCien"].ToString();
                planta.Descripcion = row["descripcion"].ToString();

                lista.Add(planta);
            }
            return lista;
        }
    }
}
