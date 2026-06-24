using AgroControl.Controller.Implementations;
using AgroControl.Model;
using ScottPlot;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace AgroControl.View
{
    public partial class charts : Form
    {
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
                var datos = new SimulationController().GenerarCurvas(idInvernaderoActual);

                if (datos.fechas.Length == 0) return;

                formsPlot5.Plot.Clear();
                formsPlot5.Plot.AddScatter(datos.fechas, datos.tempAire, System.Drawing.Color.Red, label: "Modelo Térmico");
                formsPlot5.Plot.Title("Evolución: Temperatura del Aire");
                formsPlot5.Plot.YLabel("°C");
                formsPlot5.Plot.XAxis.DateTimeFormat(true);
                formsPlot5.Refresh();

                formsPlot6.Plot.Clear();
                formsPlot6.Plot.AddScatter(datos.fechas, datos.humAire, System.Drawing.Color.DodgerBlue, label: "Modelo Humedad Aire");
                formsPlot6.Plot.Title("Evolución: Humedad del Aire");
                formsPlot6.Plot.YLabel("%");
                formsPlot6.Plot.XAxis.DateTimeFormat(true);
                formsPlot6.Refresh();

                formsPlot4.Plot.Clear();
                formsPlot4.Plot.AddScatter(datos.fechas, datos.humSuelo, System.Drawing.Color.SaddleBrown, label: "Modelo Humedad Suelo");
                formsPlot4.Plot.Title("Evolución: Humedad del Suelo");
                formsPlot4.Plot.YLabel("%");
                formsPlot4.Plot.XAxis.DateTimeFormat(true);
                formsPlot4.Refresh();

                formsPlot3.Plot.Clear();
                formsPlot3.Plot.AddScatter(datos.fechas, datos.luzTotal, System.Drawing.Color.Gold, label: "Luz Total (Natural + LED)");
                formsPlot3.Plot.Title("Iluminación para Fotosíntesis");
                formsPlot3.Plot.YLabel("Lux");
                formsPlot3.Plot.XAxis.DateTimeFormat(true);
                formsPlot3.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al simular modelos: " + ex.Message, "Error Matemático");
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

            List<Lectura3D> puntos = ObtenerDatos3D();
            if (puntos.Count == 0)
            {
                g.DrawString("Sin datos", new Font("Segoe UI", 14), Brushes.Gray, cx - 40, cy);
                return;
            }

            var proy = new List<(PointF pf, float valor, int idx)>();
            foreach (var p in puntos)
            {
                float x2d = cx + (p.X - 25) * 0.4f * scale / 30f - (p.Z - 25) * 0.2f * scale / 30f;
                float y2d = cy - (p.Y - 15) * 0.3f * scale / 30f + (p.X - 25) * 0.15f * scale / 30f + (p.Z - 25) * 0.1f * scale / 30f;
                proy.Add((new PointF(x2d, y2d), p.Y, p.Index));
            }

            int cols = 10;
            for (int i = 0; i < proy.Count - cols - 1; i++)
            {
                if ((i + 1) % cols == 0) continue;
                var p1 = proy[i];
                var p2 = proy[i + 1];
                var p3 = proy[i + cols];
                var p4 = proy[i + cols + 1];

                Color c1 = ColorDesdeValor(p1.valor, 0, 30);
                Color c2 = ColorDesdeValor(p2.valor, 0, 30);
                Color c3 = ColorDesdeValor(p3.valor, 0, 30);
                Color c4 = ColorDesdeValor(p4.valor, 0, 30);

                using (var brush = new LinearGradientBrush(p1.pf, p4.pf, c1, c4))
                {
                    PointF[] pts = { p1.pf, p2.pf, p4.pf, p3.pf };
                    g.FillPolygon(brush, pts);
                }
                using (var pen = new Pen(Color.FromArgb(40, 80, 80, 80)))
                    g.DrawPolygon(pen, new[] { p1.pf, p2.pf, p4.pf, p3.pf });
            }

            using (var penEje = new Pen(Color.Black, 2))
            {
                float len = scale * 0.7f;
                PointF orig = proy.Count > 0 ? proy[0].pf : new PointF(cx - len * 0.3f, cy + len * 0.2f);

                PointF xEnd = new PointF(orig.X + len * 0.4f, orig.Y - len * 0.15f);
                g.DrawLine(penEje, orig, xEnd);
                g.DrawString("Tiempo", new Font("Segoe UI", 8), Brushes.Black, xEnd);

                PointF yEnd = new PointF(orig.X, orig.Y - len * 0.3f);
                g.DrawLine(penEje, orig, yEnd);
                g.DrawString("Valor", new Font("Segoe UI", 8), Brushes.Black, yEnd.X - 10, yEnd.Y - 12);

                PointF zEnd = new PointF(orig.X - len * 0.2f, orig.Y + len * 0.1f);
                g.DrawLine(penEje, orig, zEnd);
                g.DrawString("Sensor", new Font("Segoe UI", 8), Brushes.Black, zEnd.X - 25, zEnd.Y + 5);
            }

            g.DrawString("Temperatura  Hum.Aire  Hum.Suelo  Luz",
                new Font("Segoe UI", 9, FontStyle.Bold), Brushes.DimGray, 10, 5);
        }

        private Color ColorDesdeValor(float val, float min, float max)
        {
            float t = Math.Clamp((val - min) / (max - min), 0, 1);
            int r = (int)(255 * t);
            int b = (int)(255 * (1 - t));
            return Color.FromArgb(200, r, 60, b);
        }

        private List<Lectura3D> ObtenerDatos3D()
        {
            var lista = new List<Lectura3D>();
            string sql = @"
                SELECT TOP 50 L.valor, S.tipo, L.fechaHora, L.idSensor
                FROM LECTURA L
                INNER JOIN SENSORES S ON L.idSensor = S.idSensor
                WHERE S.idInvernadero = @idInv
                ORDER BY L.fechaHora DESC";

            List<SqlParameter> parametros = new List<SqlParameter> { new SqlParameter("@idInv", idInvernaderoActual) };
            DataTable dt = AgroControl.Model.DataAccess.GetQuery(sql, parametros);
            if (dt.Rows.Count == 0) return lista;

            var dict = new Dictionary<int, List<(DateTime fecha, double valor)>>();
            foreach (DataRow r in dt.Rows)
            {
                int id = Convert.ToInt32(r["idSensor"]);
                if (!dict.ContainsKey(id)) dict[id] = new List<(DateTime, double)>();
                dict[id].Add((Convert.ToDateTime(r["fechaHora"]), Convert.ToDouble(r["valor"])));
            }

            int idx = 0;
            int maxCount = 0;
            foreach (var kv in dict) maxCount = Math.Max(maxCount, kv.Value.Count);

            float[] sensores = { 22, 21, 20, 23 };
            for (int t = 0; t < maxCount; t++)
            {
                for (int s = 0; s < sensores.Length; s++)
                {
                    int id = (int)sensores[s];
                    float val = 15f;
                    if (dict.ContainsKey(id) && t < dict[id].Count)
                        val = (float)dict[id][t].valor;

                    lista.Add(new Lectura3D
                    {
                        X = (float)t / maxCount * 50f,
                        Y = val / 100f * 30f,
                        Z = s * 15f + 5f,
                        Valor = val,
                        Index = idx++
                    });
                }
            }
            return lista;
        }

        private void CargarGraficaComparacion()
        {
            try
            {
                var (tiempos, tempReal, tempModelo) = new SimulationController().ObtenerComparacion(idInvernaderoActual);

                if (tiempos.Length == 0)
                {
                    MessageBox.Show("No hay datos suficientes para generar la comparación.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                formsPlot1.Plot.Clear();

                var plotReal = formsPlot1.Plot.AddScatter(tiempos, tempReal, System.Drawing.Color.DodgerBlue);
                plotReal.Label = "Temperatura Real medido por sensor";
                plotReal.MarkerSize = 4;
                plotReal.LineWidth = 2;

                var plotModelo = formsPlot1.Plot.AddScatter(tiempos, tempModelo, System.Drawing.Color.Red);
                plotModelo.Label = "Temperatura Proyectada (Modelo)";
                plotModelo.MarkerSize = 4;
                plotModelo.LineWidth = 2;
                plotModelo.LineStyle = ScottPlot.LineStyle.Dash;

                formsPlot1.Plot.Title("Análisis de Precisión: Realidad vs. Modelo Matemático");
                formsPlot1.Plot.XLabel("Tiempo transcurrido (Minutos)");
                formsPlot1.Plot.YLabel("Temperatura (°C)");

                formsPlot1.Plot.Legend(true, ScottPlot.Alignment.UpperRight);

                formsPlot1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al renderizar la simulación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private class Lectura3D
        {
            public float X { get; set; }
            public float Y { get; set; }
            public float Z { get; set; }
            public float Valor { get; set; }
            public int Index { get; set; }
        }
    }
}
