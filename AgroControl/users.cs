using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using DataAccess;

namespace AgroControl
{
    public partial class users : Form
    {
        public users()
        {
            InitializeComponent();
            btnDasboard.Click += (s, e) => LimpiarFormulario();
            iconButton2.Click += (s, e) => GuardarUsuario();
            iconButton1.Click += (s, e) => EliminarUsuario();
            iconButton3.Click += (s, e) => BuscarUsuario();
        }

        private void settings_Load(object sender, EventArgs e)
        {
            CargarRoles();
            CargarUsuarios();
        }

        private void CargarRoles()
        {
            cmbPlants.Items.Clear();
            cmbPlants.Items.Add("Admin");
            cmbPlants.Items.Add("Tecnico");
            cmbPlants.Items.Add("Agricultor");
            if (cmbPlants.Items.Count > 0) cmbPlants.SelectedIndex = 0;
        }

        private void CargarUsuarios(string filtro = "")
        {
            string sql;
            List<SqlParameter> parametros = new List<SqlParameter>();

            if (string.IsNullOrEmpty(filtro))
            {
                sql = "SELECT idUsuario, nombre, tipoUsuario FROM USUARIOS ORDER BY nombre";
            }
            else
            {
                sql = "SELECT idUsuario, nombre, tipoUsuario FROM USUARIOS WHERE nombre LIKE @filtro ORDER BY nombre";
                parametros.Add(new SqlParameter("@filtro", "%" + filtro + "%"));
            }

            DataTable dt = parametros.Count > 0
                ? DataAccess.DataAccess.getQuery(sql, parametros)
                : DataAccess.DataAccess.getQuery(sql);

            dgvPlants.DataSource = dt;
            if (dgvPlants.Columns.Contains("idUsuario"))
                dgvPlants.Columns["idUsuario"].Visible = false;
            if (dgvPlants.Columns.Contains("nombre"))
                dgvPlants.Columns["nombre"].HeaderText = "Nombre";
            if (dgvPlants.Columns.Contains("tipoUsuario"))
                dgvPlants.Columns["tipoUsuario"].HeaderText = "Rol";
        }

        private void GuardarUsuario()
        {
            string nombre = textBox1.Text.Trim();
            string contrasena = textBox2.Text.Trim();
            string rol = cmbPlants.SelectedItem?.ToString() ?? "Agricultor";

            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(contrasena))
            {
                MessageBox.Show("Ingrese nombre y contraseña.", "Advertencia");
                return;
            }

            string sql = "INSERT INTO USUARIOS (nombre, contrasena, tipoUsuario) VALUES (@nombre, @contrasena, @tipo)";
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@nombre", nombre),
                new SqlParameter("@contrasena", contrasena),
                new SqlParameter("@tipo", rol)
            };

            try
            {
                DataAccess.DataAccess.execQuery(sql, parametros);
                MessageBox.Show("Usuario guardado correctamente.", "Éxito");
                LimpiarFormulario();
                CargarUsuarios();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message, "Error");
            }
        }

        private void EliminarUsuario()
        {
            if (dgvPlants.CurrentRow == null) return;

            int id = Convert.ToInt32(dgvPlants.CurrentRow.Cells["idUsuario"].Value);
            string nombre = dgvPlants.CurrentRow.Cells["nombre"].Value.ToString();

            var confirm = MessageBox.Show($"¿Eliminar usuario '{nombre}'?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes) return;

            string sql = "DELETE FROM USUARIOS WHERE idUsuario = @id";
            List<SqlParameter> parametros = new List<SqlParameter> { new SqlParameter("@id", id) };

            try
            {
                DataAccess.DataAccess.execQuery(sql, parametros);
                CargarUsuarios();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar: " + ex.Message, "Error");
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

        private void LimpiarFormulario()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Text = "Search user";
            if (cmbPlants.Items.Count > 0) cmbPlants.SelectedIndex = 0;
            CargarUsuarios();
        }
    }
}
