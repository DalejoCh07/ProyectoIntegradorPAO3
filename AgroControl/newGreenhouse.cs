using AgroControl.Controller.Implementations;
using AgroControl.Controller.Interfaces;
using AgroControl.Model.Entities;
using System;
using System.Windows.Forms;

namespace AgroControl
{
    public partial class newGreenhouse : Form
    {
        private readonly IGreenhouseController _greenhouseController = new GreenhouseController();

        public newGreenhouse()
        {
            InitializeComponent();
            iconButton2.Click += BtnSave_Click;
        }


        private void BtnSave_Click(object sender, EventArgs e)
        {
            string nombre = textBox1.Text.Trim();
            string direccion = textBox2.Text.Trim();
            string descripcion = textBox3.Text.Trim();

            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(direccion))
            {
                MessageBox.Show("You must enter the name and address.", "Incomplete Fields",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Greenhouse gh = new Greenhouse { Nombre = nombre, Ubicacion = direccion, Descripcion = descripcion };
                int id = _greenhouseController.Agregar(gh);

                if (id > 0)
                {
                    MessageBox.Show("Greenhouse registered successfully.", "Ã‰xito",
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


