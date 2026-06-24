using AgroControl.Controller.Implementations;
using AgroControl.Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgroControl.View
{
    public partial class readingLog : Form
    {
        private int _idInvernadero;

        public readingLog(int idInvernadero)
        {
            InitializeComponent();
            _idInvernadero = idInvernadero;
            ConfigurarDatePickers();
            CargarHistorialLecturas();
            CargarRegistroAcciones();
        }

        private void ConfigurarDatePickers()
        {
            dateTimePicker1.BackColor = Color.White;
            dateTimePicker1.ForeColor = Color.Black;

            dateTimePicker2.BackColor = Color.White;
            dateTimePicker2.ForeColor = Color.Black;

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";

            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "dd/MM/yyyy";
        }

        private void BtnFiltrar_Click(object sender, EventArgs e)
        {
            DateTime desde = dateTimePicker1.Value.Date;
            DateTime hasta = dateTimePicker2.Value.Date.AddDays(1).AddSeconds(-1);

            if (desde > hasta)
            {
                MessageBox.Show("La fecha 'Desde' no puede ser mayor que 'Hasta'.", "Fechas inválidas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (filterReadings filtro = new filterReadings(_idInvernadero, desde, hasta))
            {
                filtro.ShowDialog();
            }
        }

        private void CargarHistorialLecturas()
        {
            try
            {
                DataTable dtLecturas = new ReadingController().HistorialPivot(_idInvernadero);

                dgvReadings.DataSource = dtLecturas;

                if (dgvReadings.Columns.Contains("Fecha y hora"))
                    dgvReadings.Columns["Fecha y hora"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";

                if (dgvReadings.Columns.Contains("Humedad del suelo"))
                    dgvReadings.Columns["Humedad del suelo"].DefaultCellStyle.Format = "0' %'";

                if (dgvReadings.Columns.Contains("Temperatura"))
                    dgvReadings.Columns["Temperatura"].DefaultCellStyle.Format = "0.0' °C'";

                if (dgvReadings.Columns.Contains("Humedad del aire"))
                    dgvReadings.Columns["Humedad del aire"].DefaultCellStyle.Format = "0' %'";

                if (dgvReadings.Columns.Contains("Intensidad de luz"))
                    dgvReadings.Columns["Intensidad de luz"].DefaultCellStyle.Format = "0.0' lx'";

                dgvReadings.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos en el sistema: " + ex.Message, "Error de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void CargarRegistroAcciones()
        {
            try
            {
                List<Accion> historial = new AccionController().ListarPorInvernadero(_idInvernadero);

                dgvActions.DataSource = historial;

                if (dgvActions.Columns.Contains("IdAccion"))
                    dgvActions.Columns["IdAccion"].Visible = false;

                if (dgvActions.Columns.Contains("IdActuador"))
                    dgvActions.Columns["IdActuador"].Visible = false;

                if (dgvActions.Columns.Contains("TipoAccion"))
                    dgvActions.Columns["TipoAccion"].HeaderText = "Acción Realizada";

                if (dgvActions.Columns.Contains("Duracion"))
                    dgvActions.Columns["Duracion"].HeaderText = "Duración";

                if (dgvActions.Columns.Contains("FechaHora"))
                {
                    dgvActions.Columns["FechaHora"].HeaderText = "Fecha y Hora";
                    dgvActions.Columns["FechaHora"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
                }

                dgvActions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el registro de acciones: " + ex.Message, "Error de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDatosSensores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
