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
    public class SensorBus
    {
        // MÉTODO 1: Insertar un nuevo sensor
        public static int insertar(Sensor sensor)
        {
            int filasAfectadas = -1;

            // OMITIMOS el idSensor en el INSERT porque es IDENTITY en tu base de datos
            String sql = "INSERT INTO SENSOR (tipo, idInvernadero) VALUES ('" + sensor.Tipo + "', " + sensor.IdInvernadero + ");";

            filasAfectadas = DataAccess.DataAccess.execQuery(sql);
            return filasAfectadas;
        }

        // MÉTODO 2: Obtener un solo sensor por su ID
        public static Sensor getSensor(int idSensor)
        {
            Sensor sensor = null;
            String sql = "SELECT * FROM SENSOR WHERE idSensor=@id";

            List<SqlParameter> lstPar = new List<SqlParameter>();
            lstPar.Add(new SqlParameter("@id", idSensor));

            DataTable tabla = DataAccess.DataAccess.getQuery(sql, lstPar);

            foreach (DataRow row in tabla.Rows)
            {
                sensor = new Sensor();

                // Usamos Convert para evitar errores de casteo directo
                sensor.IdSensor = Convert.ToInt32(row[0]);
                sensor.Tipo = row[1].ToString();
                sensor.IdInvernadero = Convert.ToInt32(row[2]);
            }
            return sensor;
        }

        // MÉTODO 3: Obtener la lista completa de sensores
        public static List<Sensor> getSensores()
        {
            List<Sensor> lista = new List<Sensor>();
            DataTable tabla = null;
            String sql = "SELECT * FROM SENSOR";

            tabla = DataAccess.DataAccess.getQuery(sql);

            foreach (DataRow row in tabla.Rows)
            {
                Sensor sensor = new Sensor();
                sensor.IdSensor = Convert.ToInt32(row[0]);
                sensor.Tipo = row[1].ToString();
                sensor.IdInvernadero = Convert.ToInt32(row[2]);

                lista.Add(sensor);
            }
            return lista;
        }
    }
}
