using AgroControl.Controller.Implementations;
using AgroControl.Model.Entities;
using System;
using System.Windows.Forms;

namespace AgroControl.View
{
    public partial class newPlant : Form
    {
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
                MessageBox.Show("Debes ingresar el nombre y el nombre científico de la planta.", "Campos incompletos",
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
                MessageBox.Show("Todos los campos de requerimientos deben ser valores numéricos.", "Campos incompletos",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (hsMin >= hsMax || taMin >= taMax || haMin >= haMax || lMin >= lMax)
            {
                MessageBox.Show("El valor mínimo debe ser menor que el máximo en cada rango.", "Rangos inválidos",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string desc = string.IsNullOrEmpty(descripcion) ? null : descripcion;

                Plant planta = new Plant { Nombre = nombre, NombreCien = nombreCien, Descripcion = desc };
                Requirements req = new Requirements { TempAireMin = taMin, TempAireMax = taMax, HumAireMin = haMin, HumAireMax = haMax, HumSueloMin = hsMin, HumSueloMax = hsMax, LuzMin = lMin, LuzMax = lMax };

                new PlantController().GuardarConRequerimientos(planta, req);

                MessageBox.Show("Planta y requerimientos registrados correctamente.", "Éxito",
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
