using AgroControl.Controller.Implementations;
using AgroControl.Controller.Interfaces;
using AgroControl.Model;
using ScottPlot;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace AgroControl
{
    public partial class charts : Form
    {
        private readonly ISimulationController _simulationController = new SimulationController();
        private System.Windows.Forms.Timer refreshTimer;
        private int idInvernaderoActual;
        public charts(int idInvernadero)
        {
            InitializeComponent();
            this.MouseWheel += BloquearScrollFormulario;
            ConfigurarEstiloGraficos();
            this.idInvernaderoActual = idInvernadero;
            panel3D.Paint += Panel3D_Paint;
            CargarGraficaComparacion();
            GraficarModelosMatematicos();
            refreshTimer = new System.Windows.Forms.Timer();
            refreshTimer.Interval = 5000;
            refreshTimer.Tick += (s, e) => panel3D.Invalidate();
            refreshTimer.Start();
        }
        private void charts_Load(object sender, EventArgs e)
        {
            this.MouseWheel += BloquearScrollFormulario;
            MostrarGradiente();
        }

        private void MostrarGradiente()
        {
            double hs = 40, t = 20;
            double T = MathModel.CalcularT(hs, t);
            double grad = MathModel.Gradiente(hs, t);
            string msg = $"T({hs},{t}) = {T:F3}\n"
                       + $"dT/dHs = {MathModel.dT_dHs}\n"
                       + $"dT/dt  = {MathModel.dT_dt}\n"
                       + $"Gradient magnitude: {grad:F5}";
            MessageBox.Show(msg, "Symbolic Gradient (Analytic Constants)", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BloquearScrollFormulario(object sender, MouseEventArgs e)
        {
            if (e is HandledMouseEventArgs he)
            {
                he.Handled = true;
            }
        }

        private void Panel1_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e is HandledMouseEventArgs he)
            {
                he.Handled = true;
            }
        }
        private void ConfigurarEstiloGraficos()
        {
            var graficos = new[] { formsPlot1, formsPlot5, formsPlot6, formsPlot3, formsPlot4 };

            foreach (var grafico in graficos)
            {
                grafico.Plot.Style(figureBackground: System.Drawing.Color.WhiteSmoke, dataBackground: System.Drawing.Color.WhiteSmoke);

                grafico.Refresh();
            }
        }
        private void GraficarModelosMatematicos()
        {
            try
            {
                var datos = _simulationController.GenerarCurvas(idInvernaderoActual);

                if (datos.fechas.Length == 0) return;

                formsPlot5.Plot.Clear();
                formsPlot5.Plot.AddScatter(datos.fechas, datos.tempAire, System.Drawing.Color.Red, label: "Thermal Model");
                formsPlot5.Plot.Title("Evolution: Air Temperature");
                formsPlot5.Plot.YLabel("°C");
                formsPlot5.Plot.XAxis.DateTimeFormat(true);
                formsPlot5.Refresh();

                formsPlot6.Plot.Clear();
                formsPlot6.Plot.AddScatter(datos.fechas, datos.humAire, System.Drawing.Color.DodgerBlue, label: "Air Humidity Model");
                formsPlot6.Plot.Title("Evolution: Air Humidity");
                formsPlot6.Plot.YLabel("%");
                formsPlot6.Plot.XAxis.DateTimeFormat(true);
                formsPlot6.Refresh();

                formsPlot4.Plot.Clear();
                formsPlot4.Plot.AddScatter(datos.fechas, datos.humSuelo, System.Drawing.Color.SaddleBrown, label: "Soil Moisture Model");
                formsPlot4.Plot.Title("Evolution: Soil Moisture");
                formsPlot4.Plot.YLabel("%");
                formsPlot4.Plot.XAxis.DateTimeFormat(true);
                formsPlot4.Refresh();

                formsPlot3.Plot.Clear();
                formsPlot3.Plot.AddScatter(datos.fechas, datos.luzTotal, System.Drawing.Color.Gold, label: "Total Light (Natural + LED)");
                formsPlot3.Plot.Title("Light Intensity");
                formsPlot3.Plot.YLabel("Lux");
                formsPlot3.Plot.XAxis.DateTimeFormat(true);
                formsPlot3.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error simulating models: " + ex.Message, "Mathematical Error");
            }
        }

        private void Panel3D_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            int w = panel3D.ClientSize.Width;
            int h = panel3D.ClientSize.Height;
            if (w < 10 || h < 10) return;

            g.Clear(Color.FromArgb(240, 240, 240));

            float cx = w / 2f;
            float cy = h / 2f;
            float scale = Math.Min(w, h) * 0.35f;

            int hsSteps = 20, tSteps = 30;
            double hsMin = 30, hsMax = 60;
            double tMin = 0, tMax = 50;

            double[,] T = new double[hsSteps, tSteps];

            for (int i = 0; i < hsSteps; i++)
            {
                for (int j = 0; j < tSteps; j++)
                {
                    double hs = hsMin + (hsMax - hsMin) * i / (hsSteps - 1);
                    double t = tMin + (tMax - tMin) * j / (tSteps - 1);
                    T[i, j] = MathModel.CalcularT(hs, t);
                }
            }

            float[,] px = new float[hsSteps, tSteps];
            float[,] py = new float[hsSteps, tSteps];
            double tRange = tMax - tMin;
            double hsRange = hsMax - hsMin;
            double trange = T.Cast<double>().Max() - T.Cast<double>().Min();
            if (trange < 1) trange = 1;

            float originX = cx - scale * 0.5f;
            float originY = cy + scale * 0.3f;

            for (int i = 0; i < hsSteps; i++)
            {
                for (int j = 0; j < tSteps; j++)
                {
                    double hs = hsMin + hsRange * i / (hsSteps - 1);
                    double t = tMin + tRange * j / (tSteps - 1);
                    double val = T[i, j];

                    float x2d = originX + (float)((hs - hsMin) / hsRange) * scale * 0.7f
                                         - (float)((t - tMin) / tRange) * scale * 0.35f;
                    float y2d = originY - (float)((val - T.Cast<double>().Min()) / trange) * scale * 0.6f
                                         + (float)((hs - hsMin) / hsRange) * scale * 0.15f
                                         + (float)((t - tMin) / tRange) * scale * 0.1f;
                    px[i, j] = x2d;
                    py[i, j] = y2d;
                }
            }

            double tMinVal = T.Cast<double>().Min();
            double tMaxVal = T.Cast<double>().Max();

            for (int i = 0; i < hsSteps - 1; i++)
            {
                for (int j = 0; j < tSteps - 1; j++)
                {
                    var p1 = new PointF(px[i, j], py[i, j]);
                    var p2 = new PointF(px[i + 1, j], py[i + 1, j]);
                    var p3 = new PointF(px[i + 1, j + 1], py[i + 1, j + 1]);
                    var p4 = new PointF(px[i, j + 1], py[i, j + 1]);

                    double avg = (T[i, j] + T[i + 1, j] + T[i + 1, j + 1] + T[i, j + 1]) / 4.0;
                    Color c = ColorDesdeValor((float)avg, (float)tMinVal, (float)tMaxVal);

                    using (var brush = new SolidBrush(c))
                        g.FillPolygon(brush, new[] { p1, p2, p3, p4 });
                    using (var pen = new Pen(Color.FromArgb(40, 80, 80, 80)))
                        g.DrawPolygon(pen, new[] { p1, p2, p3, p4 });
                }
            }

            using (var penEje = new Pen(Color.Black, 2))
            {
                float len = scale * 0.6f;

                PointF orig = new PointF(originX, originY);
                PointF xEnd = new PointF(originX + len * 0.7f, originY - len * 0.15f);
                g.DrawLine(penEje, orig, xEnd);
                g.DrawString("Hs (Soil Moisture)", new Font("Segoe UI", 8), Brushes.Black, xEnd.X, xEnd.Y - 10);

                PointF yEnd = new PointF(originX, originY - len * 0.6f);
                g.DrawLine(penEje, orig, yEnd);
                g.DrawString("T (°C)", new Font("Segoe UI", 8), Brushes.Black, yEnd.X - 5, yEnd.Y - 15);

                PointF zEnd = new PointF(originX - len * 0.35f, originY + len * 0.1f);
                g.DrawLine(penEje, orig, zEnd);
                g.DrawString("t (Time)", new Font("Segoe UI", 8), Brushes.Black, zEnd.X - 25, zEnd.Y + 5);
            }

            using (var font = new Font("Segoe UI", 9, FontStyle.Bold))
            using (var brush = new SolidBrush(Color.DimGray))
                g.DrawString("T = -0.08·Hs + 0.03·t + 30", font, brush, 10, 5);
        }

        private Color ColorDesdeValor(float val, float min, float max)
        {
            float t = Math.Clamp((val - min) / (max - min), 0, 1);
            int r = (int)(255 * t);
            int b = (int)(255 * (1 - t));
            return Color.FromArgb(200, r, 60, b);
        }

        public void CargarGrafico2D(double[] tiempos, double[] tempReal, double[] humedadSuelo)
        {
            try
            {
                if (tiempos.Length == 0)
                {
                    MessageBox.Show("Not enough data to generate the comparison.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                int n = tiempos.Length;
                double[] tempModelo = new double[n];
                double[] errorAbs = new double[n];

                for (int i = 0; i < n; i++)
                {
                    tempModelo[i] = MathModel.CalcularT(humedadSuelo[i], tiempos[i]);
                    errorAbs[i] = Math.Abs(tempReal[i] - tempModelo[i]);
                }

                formsPlot1.Plot.Clear();

                var plotReal = formsPlot1.Plot.AddScatter(tiempos, tempReal, System.Drawing.Color.DodgerBlue);
                plotReal.Label = "Real Temperature (sensor)";
                plotReal.MarkerSize = 4;
                plotReal.LineWidth = 2;

                var plotModelo = formsPlot1.Plot.AddScatter(tiempos, tempModelo, System.Drawing.Color.Red);
                plotModelo.Label = "Model Temperature (T = -0.08·Hs + 0.03·t + 30)";
                plotModelo.MarkerSize = 4;
                plotModelo.LineWidth = 2;
                plotModelo.LineStyle = ScottPlot.LineStyle.Dash;

                var plotError = formsPlot1.Plot.AddScatter(tiempos, errorAbs, System.Drawing.Color.Orange);
                plotError.Label = "Absolute Error |Real - Model|";
                plotError.MarkerSize = 3;
                plotError.LineWidth = 1;
                plotError.YAxisIndex = 1;

                formsPlot1.Plot.Title("Precision Analysis: Reality vs. Mathematical Model");
                formsPlot1.Plot.XLabel("Elapsed Time (Minutes)");
                formsPlot1.Plot.YLabel("Temperature (°C)");

                formsPlot1.Plot.SetAxisLimitsY(0, errorAbs.Max() * 1.2, yAxisIndex: 1);
                formsPlot1.Plot.YAxis2.Label("Absolute Error");

                formsPlot1.Plot.Legend(true, ScottPlot.Alignment.UpperRight);

                formsPlot1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error rendering simulation: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarGraficaComparacion()
        {
            try
            {
                var (tiempos, tempReal, _, humedadSuelo) = _simulationController.ObtenerComparacion(idInvernaderoActual);
                CargarGrafico2D(tiempos, tempReal, humedadSuelo);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error rendering simulation: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
    public static class MathModel
    {
        public const double dT_dHs = -0.08;
        public const double dT_dt = 0.03;

        public static double CalcularT(double Hs, double t)
        {
            return dT_dHs * Hs + dT_dt * t + 30.0;
        }

        public static double Gradiente(double Hs, double t)
        {
            return Math.Sqrt(dT_dHs * dT_dHs + dT_dt * dT_dt);
        }
    }
}



