using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BusinessLogic
{
    public class SensorBus
    {
        public static int insertar(Sensor sensor)
        {
            string sql = "INSERT INTO SENSORES (tipo, idInvernadero) VALUES (@tipo, @idInv)";
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@tipo", sensor.Tipo));
            parametros.Add(new SqlParameter("@idInv", sensor.IdInvernadero));
            return DataAccess.DataAccess.execQuery(sql, parametros);
        }

        public static Sensor getSensor(int idSensor)
        {
            Sensor sensor = null;
            string sql = "SELECT * FROM SENSORES WHERE idSensor = @id";
            List<SqlParameter> lstPar = new List<SqlParameter> { new SqlParameter("@id", idSensor) };
            DataTable tabla = DataAccess.DataAccess.getQuery(sql, lstPar);
            foreach (DataRow row in tabla.Rows)
            {
                sensor = new Sensor();
                sensor.IdSensor = Convert.ToInt32(row[0]);
                sensor.Tipo = row[1].ToString();
                sensor.IdInvernadero = Convert.ToInt32(row[2]);
            }
            return sensor;
        }

        public static List<Sensor> getSensores()
        {
            List<Sensor> lista = new List<Sensor>();
            DataTable tabla = DataAccess.DataAccess.getQuery("SELECT * FROM SENSORES");
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

        public static List<Sensor> getSensoresPorInvernadero(int idInv)
        {
            List<Sensor> lista = new List<Sensor>();
            string sql = "SELECT * FROM SENSORES WHERE idInvernadero = @id";

            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@id", idInv));

            DataTable tabla = DataAccess.DataAccess.getQuery(sql, parametros);
            foreach (DataRow row in tabla.Rows)
            {
                Sensor sensor = new Sensor();
                sensor.IdSensor = Convert.ToInt32(row["idSensor"]);
                sensor.Tipo = row["tipo"].ToString();
                sensor.IdInvernadero = Convert.ToInt32(row["idInvernadero"]);
                lista.Add(sensor);
            }
            return lista;
        }

        public static void eliminar(int id)
        {
            string sql = @"
                BEGIN TRY
                    BEGIN TRANSACTION
                        DELETE FROM LECTURA WHERE idSensor = @id;
                        DELETE FROM SENSORES WHERE idSensor = @id;
                    COMMIT TRANSACTION
                END TRY
                BEGIN CATCH
                    ROLLBACK TRANSACTION;
                    THROW;
                END CATCH";
            List<SqlParameter> parametros = new List<SqlParameter> { new SqlParameter("@id", id) };
            DataAccess.DataAccess.execQuery(sql, parametros);
        }
    }
}
