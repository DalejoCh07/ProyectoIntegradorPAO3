using AgroControl.Controller.Implementations;
using AgroControl.Model.Entities;
using System;
using System.Data;
using System.Windows.Forms;

namespace AgroControl.View
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void ingresar(string txtUsuario, string txtContrasena)
        {
            string nombreIngresado = txtUsuario.Trim();
            string claveIngresada = txtContrasena.Trim();

            if (string.IsNullOrEmpty(nombreIngresado) || string.IsNullOrEmpty(claveIngresada))
            {
                MessageBox.Show("Por favor, ingrese usuario y contraseña.", "Advertencia");
                return;
            }

            Usuario usuarioActual = new UsuarioController().Login(nombreIngresado, claveIngresada);

            if (usuarioActual != null)
            {

            }
            else
            {
                MessageBox.Show("Nombre de usuario o contraseña incorrectos.", "Error de Acceso");
            }
            if (usuarioActual != null)
            {
                MessageBox.Show($"Bienvenido al sistema agroControl, {usuarioActual.Nombre}.\nRol: {usuarioActual.TipoUsuario}", "Acceso Concedido", MessageBoxButtons.OK, MessageBoxIcon.Information);

                int idInvernaderoSeleccionado = Convert.ToInt32(cmbGreenhouse.SelectedValue);
                string nombreInvernaderoSeleccionado = cmbGreenhouse.Text;
                Interfaz ventanaPrincipal = new Interfaz(usuarioActual, idInvernaderoSeleccionado, nombreInvernaderoSeleccionado);

                ventanaPrincipal.FormClosed += (s, args) => this.Close();

                ventanaPrincipal.Show();

                this.Hide();
            }
            else
            {
                MessageBox.Show("Nombre de usuario o contraseña incorrectos.", "Error de Acceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ingresar(this.textBox1.Text, this.textBox2.Text);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string sql = "SELECT idInvernadero, nombre FROM INVERNADERO";
            DataTable dt = AgroControl.Model.DataAccess.GetQuery(sql);

            cmbGreenhouse.DataSource = dt;
            cmbGreenhouse.DisplayMember = "nombre";
            cmbGreenhouse.ValueMember = "idInvernadero";
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
