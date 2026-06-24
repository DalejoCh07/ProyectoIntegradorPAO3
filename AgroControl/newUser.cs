using AgroControl.Controller.Implementations;
using AgroControl.Controller.Interfaces;
using AgroControl.Model.Entities;
using System;
using System.Windows.Forms;

namespace AgroControl
{
    public partial class newUser : Form
    {
        private readonly IUsuarioController _usuarioController = new UsuarioController();

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
                MessageBox.Show("Please fill in all fields.", "Incomplete Fields", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Usuario nuevoUsuario = new Usuario
                {
                    Nombre = txtName.Text.Trim(),
                    Contrasena = txtPass.Text.Trim(),
                    TipoUsuario = cmbRoles.SelectedItem.ToString()
                };

                _usuarioController.Registrar(nuevoUsuario);

                MessageBox.Show("User registered successfully.", "Ã‰xito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving user: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}



