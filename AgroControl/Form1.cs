using System;
using System.Windows.Forms;
using Entities;
using BusinessLogic;

namespace AgroControl
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Dentro del evento Click del botón "Ingresar" en tu Formulario
        public void ingresar(string txtUsuario, string txtContrasena)
        {
            string nombreIngresado = txtUsuario.Trim();
            string claveIngresada = txtContrasena.Trim();

            // Verificamos que no envíen campos vacíos
            if (string.IsNullOrEmpty(nombreIngresado) || string.IsNullOrEmpty(claveIngresada))
            {
                MessageBox.Show("Por favor, ingrese usuario y contraseña.", "Advertencia");
                return;
            }

            // Llamamos a la capa de negocio
            Usuario usuarioActual = BusinessLogic.UsuarioBus.ValidarLogin(nombreIngresado, claveIngresada);

            if (usuarioActual != null)
            {

            }
            else
            {
                MessageBox.Show("Nombre de usuario o contraseña incorrectos.", "Error de Acceso");
            }
            // 3. Evaluamos la respuesta de la Capa de Negocio
            if (usuarioActual != null)
            {
                MessageBox.Show($"Bienvenido al sistema agroControl, {usuarioActual.Nombre}.\nRol: {usuarioActual.TipoUsuario}", "Acceso Concedido", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // --- CÓDIGO PARA ABRIR LA INTERFAZ PRINCIPAL ---

                // 1. Creamos una "instancia" (una copia en memoria) de tu ventana principal
                Interfaz ventanaPrincipal = new Interfaz(usuarioActual);

                // Opcional pero recomendado: Si quieres que cuando cierren la ventana principal 
                // se cierre todo el programa por completo, agrega esta línea:
                ventanaPrincipal.FormClosed += (s, args) => this.Close();

                // 2. Mostramos la nueva ventana al usuario
                ventanaPrincipal.Show();

                // 3. Ocultamos la ventana actual de Login para que no estorbe
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

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}