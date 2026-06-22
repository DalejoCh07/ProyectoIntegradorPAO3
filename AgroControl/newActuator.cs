using BusinessLogic;
using Entities;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AgroControl
{
    public partial class newActuator : Form
    {
        public newActuator()
        {
            InitializeComponent();
            CargarGreenhouses();
            CargarTiposActuators();
            iconButton2.Click += BtnSave_Click;
        }

        private void CargarTiposActuators()
        {
            // Lista directa con los valores exactos que exige tu regla en SQL Server
            List<string> tiposSQL = new List<string>
            {
                "Bomba",
                "Ventilador",
                "Humidificador",
                "Lampara"
            };

            cmbActuatorTypes.DataSource = tiposSQL;
            cmbActuatorTypes.SelectedIndex = -1; // Para que inicie vacío
        }

        private void CargarGreenhouses()
        {
            try
            {
                List<Greenhouse> lista = GreenhouseBus.getGreenhouses();
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
            if (cmbActuatorTypes.SelectedItem == null || cmbGreenhouse.SelectedItem == null)
            {
                MessageBox.Show("Selecciona el tipo y el invernadero.", "Campos incompletos",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string tipo = cmbActuatorTypes.SelectedItem.ToString();
                int idInv = ((Greenhouse)cmbGreenhouse.SelectedItem).IdInvernadero;

                Actuador act = new Actuador(0, tipo, idInv, "OFF");
                int id = ActuadorBus.insertar(act);

                if (id > 0)
                {
                    MessageBox.Show("Actuador registrado correctamente.", "Éxito",
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
