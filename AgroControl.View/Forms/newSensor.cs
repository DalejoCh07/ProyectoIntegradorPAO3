using AgroControl.Controller.Implementations;
using AgroControl.Model.Entities;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AgroControl.View
{
  
    public partial class newSensor : Form
    {
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
                List<Greenhouse> lista = new GreenhouseController().Listar();
                cmbGreenhouse.DataSource = null;
                cmbGreenhouse.DataSource = lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar invernaderos: " + ex.Message);
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (cmbSensorTypes.SelectedItem == null || cmbGreenhouse.SelectedItem == null)
            {
                MessageBox.Show("Selecciona el tipo y el invernadero.", "Campos incompletos",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string tipo = cmbSensorTypes.SelectedItem.ToString();
                int idInv = ((Greenhouse)cmbGreenhouse.SelectedItem).IdInvernadero;

                Sensor sensor = new Sensor { Tipo = tipo, IdInvernadero = idInv };
                int id = new SensorController().Agregar(sensor);

                if (id > 0)
                {
                    MessageBox.Show("Sensor registrado correctamente.", "Éxito",
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
