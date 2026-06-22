using BusinessLogic;
using Entities;
using System;
using System.Windows.Forms;

namespace AgroControl
{
    public partial class newGreenhouse : Form
    {
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
                MessageBox.Show("Debes ingresar el nombre y la dirección.", "Campos incompletos",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Greenhouse gh = new Greenhouse(0, nombre, direccion, descripcion);
                int id = GreenhouseBus.insertar(gh);

                if (id > 0)
                {
                    MessageBox.Show("Invernadero registrado correctamente.", "Éxito",
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
