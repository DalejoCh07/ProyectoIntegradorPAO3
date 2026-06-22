using BusinessLogic;
using Entities;
using FontAwesome.Sharp;
using System;
using System.Data;
using System.Windows.Forms;

namespace AgroControl
{
    public partial class adminUsers : Form
    {
        public adminUsers()
        {
            InitializeComponent();

            btnNewUser.Click += BtnNewUser_Click;
            iconButton1.Click += (s, e) => EliminarUsuario();
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
                // Llamada limpia a la capa de negocio
                DataTable dt = UsuarioBus.getUsuarios(filtro);
                dgvUsers.DataSource = dt;

                // Configuración visual de las columnas
                if (dgvUsers.Columns.Contains("idUsuario"))
                    dgvUsers.Columns["idUsuario"].Visible = false;
                if (dgvUsers.Columns.Contains("nombre"))
                    dgvUsers.Columns["nombre"].HeaderText = "Nombre";
                if (dgvUsers.Columns.Contains("tipoUsuario"))
                    dgvUsers.Columns["tipoUsuario"].HeaderText = "Rol";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los usuarios: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void EliminarUsuario()
        {
            if (dgvUsers.CurrentRow == null)
            {
                MessageBox.Show("Selecciona un usuario para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = Convert.ToInt32(dgvUsers.CurrentRow.Cells["idUsuario"].Value);
            string nombre = dgvUsers.CurrentRow.Cells["nombre"].Value.ToString();

            var confirm = MessageBox.Show($"¿Eliminar usuario '{nombre}'?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes) return;

            try
            {
                // Llamada a la capa de negocio para eliminar
                UsuarioBus.eliminar(id);

                MessageBox.Show("Usuario eliminado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarUsuarios();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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