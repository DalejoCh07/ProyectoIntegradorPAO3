using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using DataAccess;
using BusinessLogic;
using Entities;

namespace AgroControl
{
    public partial class dashboard : Form
    {
        private System.Windows.Forms.Timer refreshTimer;
        private int _idInvernadero;
        private Batch loteActivoActual;

        public dashboard(int idInvernadero)
        {
            InitializeComponent();
            _idInvernadero = idInvernadero;
            CargarLecturas();
            CargarEstadoActuadores();
            CargarLoteActivo();

            iconButton4.Click += (s, e) => ToggleActuador(1, "Bomba de Riego");
            iconButton5.Click += (s, e) => ToggleActuador(2, "Ventilador");
            iconButton2.Click += (s, e) => ToggleActuador(3, "Humidificador");
            iconButton1.Click += (s, e) => ToggleActuador(4, "Lámpara");

            refreshTimer = new System.Windows.Forms.Timer();
            refreshTimer.Interval = 5000;
            refreshTimer.Tick += (s, e) => { CargarLecturas(); CargarEstadoActuadores(); CargarLoteActivo(); };
            refreshTimer.Start();
        }

        private void CargarLoteActivo()
        {
            loteActivoActual = BatchBus.obtenerLoteActivo(_idInvernadero);

            if (loteActivoActual != null)
            {
                lblBatchId.Text = loteActivoActual.IdLote.ToString();
                lblPlantingDate.Text = loteActivoActual.FechaSiembra.ToString("dd/MM/yyyy");
                lblPlantValue.Text = loteActivoActual.NombrePlanta;
                lblNumPlantsValue.Text = loteActivoActual.CantPlantas.ToString();
                btnNewBatch.Enabled = true;
                btnFinishBatch.Enabled = true;
            }
            else
            {
                lblBatchId.Text = "-";
                lblPlantingDate.Text = "N/A";
                lblPlantValue.Text = "N/A";
                lblNumPlantsValue.Text = "N/A";
                btnNewBatch.Enabled = true;
                btnFinishBatch.Enabled = false;
            }
        }

        private void btnNewBatch_Click(object sender, EventArgs e)
        {
            if (loteActivoActual != null)
            {
                MessageBox.Show("Primero debe finalizar el lote actual antes de crear uno nuevo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (newBatch frm = new newBatch(_idInvernadero))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    CargarLoteActivo();
                }
            }
        }

        private void btnFinishBatch_Click(object sender, EventArgs e)
        {
            if (loteActivoActual != null)
            {
                DialogResult result = MessageBox.Show("¿Está seguro de finalizar el lote actual? Se registrará la cosecha con la fecha de hoy.", "Confirmar Cosecha", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        BatchBus.finalizarLote(loteActivoActual.IdLote);
                        MessageBox.Show("Lote finalizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarLoteActivo();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al finalizar el lote: " + ex.Message, "Error");
                    }
                }
            }
        }

        private void btnBatchHistory_Click(object sender, EventArgs e)
        {
            using (historyBatch frm = new historyBatch(_idInvernadero))
            {
                frm.ShowDialog();
            }
        }

        private void CargarLecturas()
        {
            try
            {
                decimal humSuelo = ObtenerUltimaLectura(20);
                decimal humAire = ObtenerUltimaLectura(21);
                decimal tempAire = ObtenerUltimaLectura(22);
                decimal luz = ObtenerUltimaLectura(23);

                label6.Text = humSuelo.ToString("F0");
                label15.Text = humSuelo > 0 ? "Normal" : "Sin datos";
                label4.Text = humAire.ToString("F0");
                label2.Text = humAire > 0 ? "Normal" : "Sin datos";
                label11.Text = tempAire.ToString("F1");
                label9.Text = tempAire > 0 ? "Normal" : "Sin datos";
                label16.Text = luz.ToString("F0");
                label13.Text = luz > 0 ? "Normal" : "Sin datos";
            }
            catch
            {
                label6.Text = "--"; label15.Text = "Error";
                label4.Text = "--"; label2.Text = "Error";
                label11.Text = "--"; label9.Text = "Error";
                label16.Text = "--"; label13.Text = "Error";
            }
        }

        private decimal ObtenerUltimaLectura(int idSensor)
        {
            string sql = @"
                SELECT TOP 1 L.valor
                FROM LECTURA L
                INNER JOIN SENSOR S ON L.idSensor = S.idSensor
                WHERE S.idInvernadero = @idInv AND L.idSensor = @idSensor
                ORDER BY L.fechaHora DESC";
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@idInv", _idInvernadero),
                new SqlParameter("@idSensor", idSensor)
            };
            DataTable dt = DataAccess.DataAccess.getQuery(sql, parametros);
            if (dt.Rows.Count > 0)
                return Convert.ToDecimal(dt.Rows[0]["valor"]);
            return 0;
        }

        private void CargarEstadoActuadores()
        {
            label25.Text = ObtenerEstadoActuador(1);
            label24.Text = ObtenerEstadoActuador(2);
            label23.Text = ObtenerEstadoActuador(3);
            label26.Text = ObtenerEstadoActuador(4);
        }

        private string ObtenerEstadoActuador(int idActuador)
        {
            string sql = "SELECT estado FROM ACTUADOR WHERE idActuador = @id AND idInvernadero = @idInv";
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@id", idActuador),
                new SqlParameter("@idInv", _idInvernadero)
            };
            DataTable dt = DataAccess.DataAccess.getQuery(sql, parametros);
            if (dt.Rows.Count > 0)
                return dt.Rows[0]["estado"].ToString().ToLower();
            return "off";
        }

        private void label1_Click_1(object sender, EventArgs e) { }
        private void label5_Click(object sender, EventArgs e) { }
        private void label6_Click(object sender, EventArgs e) { }
        private void label8_Click(object sender, EventArgs e) { }
        private void label11_Click(object sender, EventArgs e) { }
        private void label20_Click(object sender, EventArgs e) { }
        private void formsPlot1_Load(object sender, EventArgs e) { }

        private void ToggleActuador(int idActuador, string nombre)
        {
            try
            {
                string estadoActual = ObtenerEstadoActuador(idActuador);
                string nuevoEstado = estadoActual == "on" ? "OFF" : "ON";
                string sql = "UPDATE ACTUADOR SET estado = @estado WHERE idActuador = @id AND idInvernadero = @idInv";
                List<SqlParameter> parametros = new List<SqlParameter>
                {
                    new SqlParameter("@estado", nuevoEstado),
                    new SqlParameter("@id", idActuador),
                    new SqlParameter("@idInv", _idInvernadero)
                };
                DataAccess.DataAccess.execQuery(sql, parametros);
                CargarEstadoActuadores();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cambiar {nombre}: {ex.Message}", "Error");
            }
        }
    }
}
