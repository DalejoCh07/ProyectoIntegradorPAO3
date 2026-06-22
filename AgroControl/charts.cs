using BusinessLogic;
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
        private System.Windows.Forms.Timer refreshTimer;
        private int idInvernaderoActual;
        public charts(int idInvernadero)
        {
            InitializeComponent();
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

        private void ConfigurarEstiloGraficos()
        {
            var graficos = new[] { formsPlot1, formsPlot5, formsPlot6, formsPlot3, formsPlot4 };

            foreach (var grafico in graficos)
            {
                // 1. Configuramos los colores de fondo directamente en el estilo
                grafico.Plot.Style(figureBackground: System.Drawing.Color.WhiteSmoke, dataBackground: System.Drawing.Color.WhiteSmoke);

                // 2. Refrescamos el control
                grafico.Refresh();
            }
        }
        private void GraficarModelosMatematicos()
        {
            try
            {
                // 1. Obtenemos las curvas procesadas desde la lógica de negocio
                var datos = BusinessLogic.SimulationBus.GenerarCurvasModelo(idInvernaderoActual);

                if (datos.fechas.Length == 0) return;

                // 2. TEMPERATURA DEL AIRE -> formsPlot6
                formsPlot5.Plot.Clear();
                formsPlot5.Plot.AddScatter(datos.fechas, datos.tempAire, System.Drawing.Color.Red, label: "Modelo Térmico");
                formsPlot5.Plot.Title("Evolución: Temperatura del Aire");
                formsPlot5.Plot.YLabel("°C");
                formsPlot5.Plot.XAxis.DateTimeFormat(true);
                formsPlot5.Refresh();

                // 3. HUMEDAD DEL AIRE -> formsPlot7
                formsPlot6.Plot.Clear();
                formsPlot6.Plot.AddScatter(datos.fechas, datos.humAire, System.Drawing.Color.DodgerBlue, label: "Modelo Humedad Aire");
                formsPlot6.Plot.Title("Evolución: Humedad del Aire");
                formsPlot6.Plot.YLabel("%");
                formsPlot6.Plot.XAxis.DateTimeFormat(true);
                formsPlot6.Refresh();

                // 4. HUMEDAD DEL SUELO -> formsPlot4
                formsPlot4.Plot.Clear();
                formsPlot4.Plot.AddScatter(datos.fechas, datos.humSuelo, System.Drawing.Color.SaddleBrown, label: "Modelo Humedad Suelo");
                formsPlot4.Plot.Title("Evolución: Humedad del Suelo");
                formsPlot4.Plot.YLabel("%");
                formsPlot4.Plot.XAxis.DateTimeFormat(true);
                formsPlot4.Refresh();

                // 5. INTENSIDAD DE LUZ -> formsPlot3
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
        // ---- RENDER 3D GDI+ ----

        private void Panel3D_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            int w = panel3D.ClientSize.Width;
            int h = panel3D.ClientSize.Height;
            if (w < 10 || h < 10) return;

            g.Clear(Color.FromArgb(240, 240, 240));

            // Centro del panel y escala
            float cx = w / 2f;
            float cy = h / 2f;
            float scale = Math.Min(w, h) * 0.35f;

            // Obtener datos desde la BD (últimas 50 lecturas de cada sensor)
            List<Lectura3D> puntos = ObtenerDatos3D();
            if (puntos.Count == 0)
            {
                g.DrawString("Sin datos", new Font("Segoe UI", 14), Brushes.Gray, cx - 40, cy);
                return;
            }

            // Proyectar puntos 3D -> 2D (proyección isométrica)
            var proy = new List<(PointF pf, float valor, int idx)>();
            foreach (var p in puntos)
            {
                float x2d = cx + (p.X - 25) * 0.4f * scale / 30f - (p.Z - 25) * 0.2f * scale / 30f;
                float y2d = cy - (p.Y - 15) * 0.3f * scale / 30f + (p.X - 25) * 0.15f * scale / 30f + (p.Z - 25) * 0.1f * scale / 30f;
                proy.Add((new PointF(x2d, y2d), p.Y, p.Index));
            }

            // Dibujar superficie (triángulos)
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

            // Ejes
            using (var penEje = new Pen(Color.Black, 2))
            {
                float len = scale * 0.7f;
                PointF orig = proy.Count > 0 ? proy[0].pf : new PointF(cx - len * 0.3f, cy + len * 0.2f);

                // Eje X (temp)
                PointF xEnd = new PointF(orig.X + len * 0.4f, orig.Y - len * 0.15f);
                g.DrawLine(penEje, orig, xEnd);
                g.DrawString("Tiempo", new Font("Segoe UI", 8), Brushes.Black, xEnd);

                // Eje Y (valor)
                PointF yEnd = new PointF(orig.X, orig.Y - len * 0.3f);
                g.DrawLine(penEje, orig, yEnd);
                g.DrawString("Valor", new Font("Segoe UI", 8), Brushes.Black, yEnd.X - 10, yEnd.Y - 12);

                // Eje Z (sensor)
                PointF zEnd = new PointF(orig.X - len * 0.2f, orig.Y + len * 0.1f);
                g.DrawLine(penEje, orig, zEnd);
                g.DrawString("Sensor", new Font("Segoe UI", 8), Brushes.Black, zEnd.X - 25, zEnd.Y + 5);
            }

            // Leyenda
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

        // ---- DATOS 3D DESDE BD ----

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
            DataTable dt = DataAccess.DataAccess.getQuery(sql, parametros);
            if (dt.Rows.Count == 0) return lista;

            // Organizar por sensor: temperatura(22)=X, humAire(21)=Z, humSuelo(20)=Z+1, luz(23)=Z+2
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

            // Generar malla: X=índice temporal, Y=valor normalizado, Z=sensor
            float[] sensores = { 22, 21, 20, 23 };  // temp, humAire, humSuelo, luz
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

        // ---- GRÁFICAS 2D (ScottPlot) ----
        private void CargarGraficaComparacion()
        {
            try
            {
                // 1. Llamamos a tu método en simulacionBus para obtener los arreglos
                // Asegúrate de tener el using adecuado o llamar a la clase con su namespace
                var (tiempos, tempReal, tempModelo) = SimulationBus.ObtenerComparacionModelo(idInvernaderoActual);

                // Validamos que existan datos para graficar
                if (tiempos.Length == 0)
                {
                    MessageBox.Show("No hay datos suficientes para generar la comparación.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // 2. Limpiamos el control antes de dibujar (Asegúrate de que 'formsPlotModelo' sea el nombre de tu control en el diseño)
                formsPlot1.Plot.Clear();

                // 3. Graficamos la Temperatura Real (Línea azul, continua)
                var plotReal = formsPlot1.Plot.AddScatter(tiempos, tempReal, System.Drawing.Color.DodgerBlue);
                plotReal.Label = "Temperatura Real medido por sensor";
                plotReal.MarkerSize = 4;
                plotReal.LineWidth = 2;

                // 4. Graficamos la Temperatura del Modelo Matemático (Línea roja, punteada para diferenciarla)
                var plotModelo = formsPlot1.Plot.AddScatter(tiempos, tempModelo, System.Drawing.Color.Red);
                plotModelo.Label = "Temperatura Proyectada (Modelo)";
                plotModelo.MarkerSize = 4;
                plotModelo.LineWidth = 2;
                plotModelo.LineStyle = ScottPlot.LineStyle.Dash; // Estilo punteado

                // 5. Configuramos los aspectos visuales: Título, Ejes y Leyenda
                formsPlot1.Plot.Title("Análisis de Precisión: Realidad vs. Modelo Matemático");
                formsPlot1.Plot.XLabel("Tiempo transcurrido (Minutos)");
                formsPlot1.Plot.YLabel("Temperatura (°C)");

                // Activamos la leyenda para que se entienda qué es cada línea
                formsPlot1.Plot.Legend(true, ScottPlot.Alignment.UpperRight);

                // 6. Refrescamos el control para renderizar la gráfica
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
