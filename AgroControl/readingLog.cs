using AgroControl.Controller.Implementations;
using AgroControl.Controller.Interfaces;
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

namespace AgroControl
{
    public partial class readingLog : Form
    {
        private readonly IReadingController _readingController = new ReadingController();
        private readonly IAccionController _accionController = new AccionController();
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
                MessageBox.Show("The 'From' date cannot be later than 'To'.", "Invalid Dates", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                DataTable dtLecturas = _readingController.HistorialPivot(_idInvernadero);

                dgvReadings.DataSource = dtLecturas;

                if (dgvReadings.Columns.Contains("Fecha y hora"))
                    dgvReadings.Columns["Fecha y hora"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";

                if (dgvReadings.Columns.Contains("Soil Moisture"))
                    dgvReadings.Columns["Soil Moisture"].DefaultCellStyle.Format = "0' %'";

                if (dgvReadings.Columns.Contains("Temperature"))
                    dgvReadings.Columns["Temperature"].DefaultCellStyle.Format = "0.0' °C'";

                if (dgvReadings.Columns.Contains("Air Humidity"))
                    dgvReadings.Columns["Air Humidity"].DefaultCellStyle.Format = "0' %'";

                if (dgvReadings.Columns.Contains("Light Intensity"))
                    dgvReadings.Columns["Light Intensity"].DefaultCellStyle.Format = "0.0' lx'";

                dgvReadings.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message, "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void CargarRegistroAcciones()
        {
            try
            {
                List<Accion> historial = _accionController.ListarPorInvernadero(_idInvernadero);

                dgvActions.DataSource = historial;

                if (dgvActions.Columns.Contains("IdAccion"))
                    dgvActions.Columns["IdAccion"].Visible = false;

                if (dgvActions.Columns.Contains("IdActuador"))
                    dgvActions.Columns["IdActuador"].Visible = false;

                if (dgvActions.Columns.Contains("TipoAccion"))
                    dgvActions.Columns["TipoAccion"].HeaderText = "Action Performed";

                if (dgvActions.Columns.Contains("Duracion"))
                    dgvActions.Columns["Duracion"].HeaderText = "Duration";

                if (dgvActions.Columns.Contains("FechaHora"))
                {
                    dgvActions.Columns["FechaHora"].HeaderText = "Fecha y Hora";
                    dgvActions.Columns["FechaHora"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
                }

                dgvActions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading action log: " + ex.Message, "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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



