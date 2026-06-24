using AgroControl.Model.Entities;
using System;
using System.Windows.Forms;

namespace AgroControl
{
    public partial class user : Form
    {
        private Usuario _usuarioActual;

        public user(Usuario usuario)
        {
            InitializeComponent();
            _usuarioActual = usuario;

            lblUser.Text = _usuarioActual.Nombre;
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to log out?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Restart();
            }
        }

        private void btnManage_Click(object sender, EventArgs e)
        {
            if (_usuarioActual.TipoUsuario != "Admin")
            {
                MessageBox.Show("You do not have permission to manage users.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            adminUsers admin = new adminUsers();

            admin.ShowDialog();
        }
    }
}


