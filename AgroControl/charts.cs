using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DataAccess;

namespace AgroControl
{
    public partial class charts : Form
    {
        private System.Windows.Forms.Timer refreshTimer;

        public charts()
        {
            InitializeComponent();
            CargarGraficos();
            refreshTimer = new System.Windows.Forms.Timer();
            refreshTimer.Interval = 10000;
            refreshTimer.Tick += (s, e) => CargarGraficos();
            refreshTimer.Start();
        }

        private void CargarGraficos()
        {
            try
            {
                CargarGraficoSensor(22, formsPlot1, "Temperatura", "°C", Color.Red);
                CargarGraficoSensor(21, formsPlot2, "Humedad del Aire", "%", Color.DodgerBlue);
                CargarGraficoSensor(20, formsPlot3, "Humedad del Suelo", "%", Color.Orange);
                CargarGraficoSensor(23, formsPlot4, "Luz", "lux", Color.Gold);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar gráficos: " + ex.Message, "Error");
            }
        }

        private void CargarGraficoSensor(int idSensor, ScottPlot.FormsPlot plot, string titulo, string unidad, Color color)
        {
            string sql = @"SELECT TOP 50 valor, fechaHora FROM LECTURA 
                           WHERE idSensor = @id 
                           ORDER BY fechaHora ASC";
            List<SqlParameter> parametros = new List<SqlParameter> { new SqlParameter("@id", idSensor) };
            DataTable dt = DataAccess.DataAccess.getQuery(sql, parametros);

            if (dt.Rows.Count == 0) return;

            double[] valores = dt.AsEnumerable().Select(r => Convert.ToDouble(r["valor"])).ToArray();
            double[] fechas = dt.AsEnumerable().Select(r => Convert.ToDateTime(r["fechaHora"]).ToOADate()).ToArray();

            plot.Plot.Clear();
            plot.Plot.AddScatter(fechas, valores, color);
            plot.Plot.Title(titulo);
            plot.Plot.YLabel(unidad);
            plot.Plot.XAxis.DateTimeFormat(true);
            plot.Plot.SetAxisLimits(xMin: fechas.First(), xMax: fechas.Last());
            plot.Render();
        }
    }
}
