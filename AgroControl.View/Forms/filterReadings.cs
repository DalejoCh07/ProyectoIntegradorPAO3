using AgroControl.Controller.Implementations;
using System;
using System.Data;
using System.Windows.Forms;

namespace AgroControl.View
{
    public partial class filterReadings : Form
    {
        public filterReadings(int idInvernadero, DateTime desde, DateTime hasta)
        {
            InitializeComponent();

            CargarEstadisticas(idInvernadero, desde, hasta);
        }

        private void CargarEstadisticas(int idInvernadero, DateTime desde, DateTime hasta)
        {
            DataTable dt = new ReadingController().Estadisticas(desde, hasta, idInvernadero);

            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show("No se encontraron datos registrados para este invernadero en el período seleccionado.",
                                "Sin datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            foreach (DataRow r in dt.Rows)
            {
                string nombreSensor = r["Sensor"].ToString().ToLower();

                string valMin = r["Minimo"].ToString();
                string valMax = r["Maximo"].ToString();
                string valProm = r["Promedio"].ToString();

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
