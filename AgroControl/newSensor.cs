using AgroControl.Controller.Implementations;
using AgroControl.Controller.Interfaces;
using AgroControl.Model.Entities;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AgroControl
{
  
    public partial class newSensor : Form
    {
        private readonly IGreenhouseController _greenhouseController = new GreenhouseController();
        private readonly ISensorController _sensorController = new SensorController();

        public newSensor()
        {
            InitializeComponent();
            CargarGreenhouses();
            CargarTiposDeSensores();
            iconButton2.Click += BtnSave_Click;
        }

        private void CargarTiposDeSensores()
        {
            List<string> tiposSQL = new List<string>
            {
                "humSuelo",
                "tempAire",
                "humAire",
                "luz"
            };

            cmbSensorTypes.DataSource = tiposSQL;
            cmbSensorTypes.SelectedIndex = -1;
        }

        private void CargarGreenhouses()
        {
            try
            {
                List<Greenhouse> lista = _greenhouseController.Listar();
                cmbGreenhouse.DataSource = null;
                cmbGreenhouse.DataSource = lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading greenhouses: " + ex.Message);
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (cmbSensorTypes.SelectedItem == null || cmbGreenhouse.SelectedItem == null)
            {
                MessageBox.Show("Select the type and the greenhouse.", "Incomplete Fields",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string tipo = cmbSensorTypes.SelectedItem.ToString();
                int idInv = ((Greenhouse)cmbGreenhouse.SelectedItem).IdInvernadero;

                Sensor sensor = new Sensor { Tipo = tipo, IdInvernadero = idInv };
                int id = _sensorController.Agregar(sensor);

                if (id > 0)
                {
                    MessageBox.Show("Sensor registered successfully.", "Ã‰xito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(cmbSensorTypes.SelectedItem.ToString() + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}


