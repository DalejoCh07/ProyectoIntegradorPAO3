using AgroControl.Controller.Implementations;
using AgroControl.Model.Entities;
using System;
using System.Windows.Forms;

namespace AgroControl.View
{
    public partial class newUser : Form
    {
        public newUser()
        {
            InitializeComponent();

            btnSaveUser.Click += BtnSave_Click;
            this.Load += newUser_Load;
        }

        private void newUser_Load(object sender, EventArgs e)
        {
            CargarRoles();
        }

        private void CargarRoles()
        {
            cmbRoles.Items.Clear();
            cmbRoles.Items.Add("Admin");
            cmbRoles.Items.Add("Tecnico");
            cmbRoles.Items.Add("Agricultor");

            cmbRoles.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtPass.Text) ||
                cmbRoles.SelectedItem == null)
            {
                MessageBox.Show("Por favor, completa todos los campos.", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Usuario nuevoUsuario = new Usuario();
                nuevoUsuario.Nombre = txtName.Text.Trim();
                nuevoUsuario.Contrasena = txtPass.Text.Trim();
                nuevoUsuario.TipoUsuario = cmbRoles.SelectedItem.ToString();

                new UsuarioController().Registrar(nuevoUsuario);

                MessageBox.Show("Usuario registrado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
