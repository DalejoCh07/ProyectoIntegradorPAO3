using AgroControl.Controller.Implementations;
using AgroControl.Controller.Interfaces;
using AgroControl.Model.Entities;
using FontAwesome.Sharp;
using System;
using System.Data;
using System.Windows.Forms;

namespace AgroControl
{
    public partial class adminUsers : Form
    {
        private readonly IUsuarioController _usuarioController = new UsuarioController();

        public adminUsers()
        {
            InitializeComponent();

            btnNewUser.Click += BtnNewUser_Click;
            iconButton1.Click += (s, e) => DeleteUsuario();
            iconButton3.Click += (s, e) => BuscarUsuario();

            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void adminUsers_Load(object sender, EventArgs e)
        {
            CargarUsuarios();
        }

        private void CargarUsuarios(string filtro = "")
        {
            try
            {
                DataTable dt = _usuarioController.Listar(filtro);
                dgvUsers.DataSource = dt;

                if (dgvUsers.Columns.Contains("idUsuario"))
                    dgvUsers.Columns["idUsuario"].Visible = false;
                if (dgvUsers.Columns.Contains("nombre"))
                    dgvUsers.Columns["nombre"].HeaderText = "Nombre";
                if (dgvUsers.Columns.Contains("tipoUsuario"))
                    dgvUsers.Columns["tipoUsuario"].HeaderText = "Rol";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading users: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnNewUser_Click(object sender, EventArgs e)
        {
            using (newUser frm = new newUser())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    CargarUsuarios();
                }
            }
        }

        private void DeleteUsuario()
        {
            if (dgvUsers.CurrentRow == null)
            {
                MessageBox.Show("Select a user to delete.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = Convert.ToInt32(dgvUsers.CurrentRow.Cells["idUsuario"].Value);
            string nombre = dgvUsers.CurrentRow.Cells["nombre"].Value.ToString();

            var confirm = MessageBox.Show($"Delete user '{nombre}'?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes) return;

            try
            {
                _usuarioController.Eliminar(id);

                MessageBox.Show("User deleted successfully.", "Ã‰xito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarUsuarios();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BuscarUsuario()
        {
            string filtro = textBox3.Text.Trim();
            if (filtro == "Search user" || string.IsNullOrEmpty(filtro))
                CargarUsuarios();
            else
                CargarUsuarios(filtro);
        }
    }
}




