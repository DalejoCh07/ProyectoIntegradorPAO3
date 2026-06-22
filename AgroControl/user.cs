using Entities;
using System;
using System;
using System.Windows.Forms;

namespace AgroControl
{
    public partial class user : Form
    {
        private Usuario _usuarioActual;

        // 2. Modificamos el constructor para recibir el usuario
        public user(Usuario usuario)
        {
            InitializeComponent();
            _usuarioActual = usuario;

            // 3. Asignamos el nombre al label que tengas en tu diseño (ejemplo: lblNombreUsuario)
            // Asegúrate de usar el nombre real de tu control Label
            lblUser.Text = _usuarioActual.Nombre;
        }

        // Evento para el botón Log out
        private void btnLogOut_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("¿Está seguro que desea cerrar sesión?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Esto reinicia la aplicación completa, limpiando la memoria 
                // y volviendo a cargar el Form1 (Login) desde cero.
                Application.Restart();
            }
        }


        // Evento para el botón Manage users
        private void btnManage_Click(object sender, EventArgs e)
        {
            // 1. Abrimos el formulario de administración
            adminUsers admin = new adminUsers();

            // Usamos ShowDialog para que el usuario deba cerrar la gestión 
            // antes de volver a interactuar con el formulario de usuario
            admin.ShowDialog();
        }
    }
}
