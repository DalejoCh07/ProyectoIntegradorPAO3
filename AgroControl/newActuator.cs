using AgroControl.Controller.Implementations;
using AgroControl.Controller.Interfaces;
using AgroControl.Model.Entities;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AgroControl
{
    public partial class newActuator : Form
    {
        private readonly IGreenhouseController _greenhouseController = new GreenhouseController();
        private readonly IActuadorController _actuadorController = new ActuadorController();

        public newActuator()
        {
            InitializeComponent();
            CargarGreenhouses();
            CargarTiposActuators();
            iconButton2.Click += BtnSave_Click;
        }

        private void CargarTiposActuators()
        {
            List<string> tiposSQL = new List<string>
            {
                "Bomba",
                "Ventilador",
                "Humidificador",
                "Lampara"
            };

            cmbActuatorTypes.DataSource = tiposSQL;
            cmbActuatorTypes.SelectedIndex = -1;
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
            if (cmbActuatorTypes.SelectedItem == null || cmbGreenhouse.SelectedItem == null)
            {
                MessageBox.Show("Select the type and the greenhouse.", "Incomplete Fields",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string tipo = cmbActuatorTypes.SelectedItem.ToString();
                int idInv = ((Greenhouse)cmbGreenhouse.SelectedItem).IdInvernadero;

                Actuador act = new Actuador { Tipo = tipo, IdInvernadero = idInv, Estado = "OFF" };
                int id = _actuadorController.Agregar(act);

                if (id > 0)
                {
                    MessageBox.Show("Actuator registered successfully.", "Ã‰xito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}


