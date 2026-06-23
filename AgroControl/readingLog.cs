using BusinessLogic;
using Entities;
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
        private int _idInvernadero;

        public readingLog(int idInvernadero)
        {
            InitializeComponent();
            _idInvernadero = idInvernadero;
            CargarHistorialLecturas();
            CargarRegistroAcciones();
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
                // 1. Llamamos directamente a la capa de negocio (Cero SQL en la interfaz)
                DataTable dtLecturas = ReadingBus.getHistorialPivot(_idInvernadero);

                // 2. Inyectamos los datos limpios al DataGridView
                dgvReadings.DataSource = dtLecturas;

                // 3. Aplicamos los formatos visuales específicos a cada columna
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

                // Truco de simetría: Mismo comportamiento de llenado elástico que el registro de acciones
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
                // 1. Llamamos a la capa de negocio para obtener la lista de objetos
                List<Accion> historial = AccionBus.getAccionesPorInvernadero(_idInvernadero);

                // 2. Inyectamos la lista directamente al DataGridView
                dgvActions.DataSource = historial;

                // 3. Ajustamos la estética de las columnas generadas automáticamente

                // Ocultamos los IDs internos para que el usuario final no los vea
                if (dgvActions.Columns.Contains("IdAccion"))
                    dgvActions.Columns["IdAccion"].Visible = false;

                if (dgvActions.Columns.Contains("IdActuador"))
                    dgvActions.Columns["IdActuador"].Visible = false;

                // Renombramos las cabeceras para que se vean amigables
                if (dgvActions.Columns.Contains("TipoAccion"))
                    dgvActions.Columns["TipoAccion"].HeaderText = "Acción Realizada";

                if (dgvActions.Columns.Contains("Duracion"))
                    dgvActions.Columns["Duracion"].HeaderText = "Duración";

                // Formateamos la fecha y renombramos la cabecera
                if (dgvActions.Columns.Contains("FechaHora"))
                {
                    dgvActions.Columns["FechaHora"].HeaderText = "Fecha y Hora";
                    dgvActions.Columns["FechaHora"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
                }

                // Hacemos que las columnas visibles se estiren para llenar el espacio
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

        /*
        // 4. AL ELIMINAR O INSERTAR UN NUEVO SENSOR
        private void btnIngresarSensor_Click(object sender, EventArgs e)
        {
            Sensor sensor = new Sensor();
            sensor.Tipo = txtTipo.Text.Trim();
            sensor.IdInvernadero = Convert.ToInt32(txtIdInvernadero.Text);

            int rowAff = FSensor.insertar(sensor);

            if (rowAff > 0)
            {
                MessageBox.Show("¡Sensor ingresado correctamente!");

                // ¡Aquí también llamamos al método! 
                // Así la tabla se actualiza sola y muestra el nuevo sensor de inmediato.
                CargarContenidoSensores();
            }
        }
        */
    }
}
