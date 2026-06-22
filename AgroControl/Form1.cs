using BusinessLogic;
using Entities;
using System;
using System.Data;
using System.Windows.Forms;

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
                int idInvernaderoSeleccionado = Convert.ToInt32(cmbGreenhouse.SelectedValue);
                string nombreInvernaderoSeleccionado = cmbGreenhouse.Text;
                // 1. Creamos una "instancia" (una copia en memoria) de tu ventana principal
                Interfaz ventanaPrincipal = new Interfaz(usuarioActual, idInvernaderoSeleccionado, nombreInvernaderoSeleccionado);

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
            // 1. Cargar el ComboBox al abrir el login
            // Asegúrate de que los nombres de tabla y columnas coincidan con tu base de datos SQL
            string sql = "SELECT idInvernadero, nombre FROM INVERNADERO";
            DataTable dt = DataAccess.DataAccess.getQuery(sql);

            cmbGreenhouse.DataSource = dt;
            cmbGreenhouse.DisplayMember = "nombre";      // Lo que ve el usuario
            cmbGreenhouse.ValueMember = "idInvernadero"; // El ID oculto que usaremos en código
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}