using BusinessLogic;
using System;
using System.Data;
using System.Windows.Forms;

namespace AgroControl
{
    public partial class filterReadings : Form
    {
        public filterReadings(int idInvernadero, DateTime desde, DateTime hasta)
        {
            InitializeComponent();

            // Llamamos a la función que cargará los datos apenas se inicialice el formulario
            CargarEstadisticas(idInvernadero, desde, hasta);
        }

        private void CargarEstadisticas(int idInvernadero, DateTime desde, DateTime hasta)
        {
            // 1. Obtenemos los datos de la base de datos a través de tu capa de lógica
            DataTable dt = ReadingBus.getEstadisticas(desde, hasta, idInvernadero);

            // 2. Verificamos si la consulta viene vacía para avisar al usuario
            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show("No se encontraron datos registrados para este invernadero en el período seleccionado.",
                                "Sin datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 3. Iteramos por cada fila (sensor) que nos devolvió la base de datos
            foreach (DataRow r in dt.Rows)
            {
                // Convertimos el nombre del sensor a minúsculas para evitar errores por mayúsculas
                string nombreSensor = r["Sensor"].ToString().ToLower();

                // Extraemos los valores como texto
                string valMin = r["Minimo"].ToString();
                string valMax = r["Maximo"].ToString();
                string valProm = r["Promedio"].ToString();

                // 4. Evaluamos qué sensor es y asignamos la información a los Labels de la interfaz
                if (nombreSensor.Contains("suelo") || nombreSensor.Contains("soil"))
                {
                    lblMinSoil.Text = valMin;
                    lblMaxSoil.Text = valMax;
                    lblAvgSoil.Text = valProm;
                }
                else if (nombreSensor.Contains("temperatura") || nombreSensor.Contains("temp"))
                {
                    lblMinTemp.Text = valMin;
                    lblMaxTemp.Text = valMax;
                    lblAvgTemp.Text = valProm;
                }
                else if (nombreSensor.Contains("aire") || nombreSensor.Contains("air"))
                {
                    lblMinAir.Text = valMin;
                    lblMaxAir.Text = valMax;
                    lblAvgAir.Text = valProm;
                }
                else if (nombreSensor.Contains("luz") || nombreSensor.Contains("light"))
                {
                    lblMinLight.Text = valMin;
                    lblMaxLight.Text = valMax;
                    lblAvgLight.Text = valProm;
                }
            }
        }
    }
}