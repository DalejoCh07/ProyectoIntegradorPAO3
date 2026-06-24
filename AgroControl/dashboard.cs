using AgroControl.Controller.Implementations;
using AgroControl.Controller.Interfaces;
using AgroControl.Model.Entities;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace AgroControl
{
    public partial class dashboard : Form
    {
        private System.Windows.Forms.Timer refreshTimer;
        private int _idInvernadero;
        private Batch loteActivoActual;
        private DateTime _ultimaLecturaValida = DateTime.MinValue;

        private readonly IReadingController _readingController = new ReadingController();
        private readonly IActuadorController _actuadorController = new ActuadorController();
        private readonly IBatchController _batchController = new BatchController();
        private Label lblSerialStatus;

        public dashboard(int idInvernadero)
        {
            InitializeComponent();
            _idInvernadero = idInvernadero;

            lblSerialStatus = new Label { AutoSize = true, ForeColor = Color.Gray, Location = new Point(12, this.Height - 30) };
            this.Controls.Add(lblSerialStatus);

            CargarLecturas();
            CargarEstadoActuadores();
            CargarLoteActivo();

            iconButton4.Click += (s, e) => ToggleActuador(1, "Bomba de Riego");
            iconButton5.Click += (s, e) => ToggleActuador(2, "Ventilador");
            iconButton2.Click += (s, e) => ToggleActuador(3, "Humidificador");
            iconButton1.Click += (s, e) => ToggleActuador(4, "Lamp");

            refreshTimer = new System.Windows.Forms.Timer();
            refreshTimer.Interval = 5000;
            refreshTimer.Tick += (s, e) => { CargarLecturas(); CargarEstadoActuadores(); CargarLoteActivo(); MostrarEstadoSerial(); };
            refreshTimer.Start();
        }

        private void MostrarEstadoSerial()
        {
            var sr = Interfaz.SerialReader;
            if (sr == null)
                lblSerialStatus.Text = "SerialReader: not started";
            else
                lblSerialStatus.Text = $"SerialReader: {sr.Status}";
        }

        private void CargarLoteActivo()
        {
            loteActivoActual = _batchController.ObtenerActivo(_idInvernadero);

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
                MessageBox.Show("You must finish the current batch before creating a new one.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                DialogResult result = MessageBox.Show("Are you sure you want to finish the current batch? The harvest will be recorded with today date.", "Confirm Harvest", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        new BatchController().Finalizar(loteActivoActual.IdLote);
                        MessageBox.Show("Batch completed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarLoteActivo();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error finishing batch: " + ex.Message, "Error");
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
                decimal humSuelo = _readingController.UltimaLectura(20, _idInvernadero);
                decimal humAire = _readingController.UltimaLectura(21, _idInvernadero);
                decimal tempAire = _readingController.UltimaLectura(22, _idInvernadero);
                decimal luz = _readingController.UltimaLectura(23, _idInvernadero);

                bool hayAlgunDato = humSuelo > 0 || humAire > 0 || tempAire > 0 || luz > 0;
                if (hayAlgunDato)
                    _ultimaLecturaValida = DateTime.Now;

                bool datosRecientes = (DateTime.Now - _ultimaLecturaValida).TotalSeconds < 30;
                string estado = datosRecientes ? "Normal" : "No data";

                label6.Text = humSuelo.ToString("F0");
                label15.Text = hayAlgunDato ? estado : "No data";
                label4.Text = humAire.ToString("F0");
                label2.Text = hayAlgunDato ? estado : "No data";
                label11.Text = tempAire.ToString("F1");
                label9.Text = hayAlgunDato ? estado : "No data";
                label16.Text = luz.ToString("F0");
                label13.Text = hayAlgunDato ? estado : "No data";
            }
            catch
            {
                bool datosRecientes = (DateTime.Now - _ultimaLecturaValida).TotalSeconds < 30;
                if (datosRecientes)
                {
                    label15.Text = "No data";
                    label2.Text = "No data";
                    label9.Text = "No data";
                    label13.Text = "No data";
                }
                else
                {
                    label6.Text = "--"; label15.Text = "Error";
                    label4.Text = "--"; label2.Text = "Error";
                    label11.Text = "--"; label9.Text = "Error";
                    label16.Text = "--"; label13.Text = "Error";
                }
            }
        }

        private void CargarEstadoActuadores()
        {
            label25.Text = _actuadorController.ObtenerEstado(1, _idInvernadero);
            label24.Text = _actuadorController.ObtenerEstado(2, _idInvernadero);
            label23.Text = _actuadorController.ObtenerEstado(3, _idInvernadero);
            label26.Text = _actuadorController.ObtenerEstado(4, _idInvernadero);
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
                string estadoActual = _actuadorController.ObtenerEstado(idActuador, _idInvernadero);
                string nuevoEstado = estadoActual == "on" ? "OFF" : "ON";
                _actuadorController.CambiarEstado(idActuador, _idInvernadero, nuevoEstado);
                CargarEstadoActuadores();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cambiar {nombre}: {ex.Message}", "Error");
            }
        }
    }
}


