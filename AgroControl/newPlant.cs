using AgroControl.Controller.Implementations;
using AgroControl.Controller.Interfaces;
using AgroControl.Model.Entities;
using System;
using System.Windows.Forms;

namespace AgroControl
{
    public partial class newPlant : Form
    {
        private readonly IPlantController _plantController = new PlantController();

        public newPlant()
        {
            InitializeComponent();
            iconButton1.Click += iconButton1_Click;
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            string nombre = textBox5.Text.Trim();
            string nombreCien = textBox4.Text.Trim();
            string descripcion = textBox3.Text.Trim();

            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(nombreCien))
            {
                MessageBox.Show("You must enter the name and scientific name of the plant.", "Incomplete Fields",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(textBox6.Text.Trim(), out decimal hsMin) ||
                !decimal.TryParse(textBox7.Text.Trim(), out decimal hsMax) ||
                !decimal.TryParse(textBox11.Text.Trim(), out decimal taMin) ||
                !decimal.TryParse(textBox8.Text.Trim(), out decimal taMax) ||
                !decimal.TryParse(textBox10.Text.Trim(), out decimal haMin) ||
                !decimal.TryParse(textBox19.Text.Trim(), out decimal haMax) ||
                !decimal.TryParse(textBox9.Text.Trim(), out decimal lMin) ||
                !decimal.TryParse(textBox20.Text.Trim(), out decimal lMax))
            {
                MessageBox.Show("All requirement fields must be numeric values.", "Incomplete Fields",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (hsMin >= hsMax || taMin >= taMax || haMin >= haMax || lMin >= lMax)
            {
                MessageBox.Show("The minimum value must be less than the maximum in each range.", "Invalid Ranges",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string desc = string.IsNullOrEmpty(descripcion) ? null : descripcion;

                Plant planta = new Plant { Nombre = nombre, NombreCien = nombreCien, Descripcion = desc };
                Requirements req = new Requirements { TempAireMin = taMin, TempAireMax = taMax, HumAireMin = haMin, HumAireMax = haMax, HumSueloMin = hsMin, HumSueloMax = hsMax, LuzMin = lMin, LuzMax = lMax };

                _plantController.GuardarConRequerimientos(planta, req);

                MessageBox.Show("Plant and requirements registered successfully.", "Ã‰xito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}


