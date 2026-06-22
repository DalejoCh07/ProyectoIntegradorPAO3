using BusinessLogic;
using Entities;
using System;
using System.Windows.Forms;
using System.Xml.Linq;

namespace AgroControl
{
    public partial class newUser : Form
    {
        public newUser()
        {
            InitializeComponent();

            // Asignación de eventos
            btnSaveUser.Click += BtnSave_Click;
            this.Load += newUser_Load; // Vinculamos el evento Load
        }

        // Evento Load: Se ejecuta justo antes de mostrar la ventana
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

            // Evita que el usuario escriba texto libre en el ComboBox
            cmbRoles.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            // 1. Validación de campos vacíos
            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtPass.Text) ||
                cmbRoles.SelectedItem == null)
            {
                MessageBox.Show("Por favor, completa todos los campos.", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 2. Llenamos el objeto Entidad
                Usuario nuevoUsuario = new Usuario();
                nuevoUsuario.Nombre = txtName.Text.Trim();
                nuevoUsuario.Contrasena = txtPass.Text.Trim();
                nuevoUsuario.TipoUsuario = cmbRoles.SelectedItem.ToString();

                // 3. Enviamos el objeto a la capa de negocio
                UsuarioBus.insertar(nuevoUsuario);

                // 4. Cerramos y confirmamos éxito
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