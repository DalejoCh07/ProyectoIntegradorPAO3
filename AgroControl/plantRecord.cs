using AgroControl.Controller.Implementations;
using AgroControl.Controller.Interfaces;
using AgroControl.Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgroControl
{
    public partial class plantRecord : Form
    {
        private readonly IPlantController _plantController = new PlantController();
        private readonly IRequirementsController _requirementsController = new RequirementsController();
        private Usuario _usuarioActual;

        public plantRecord(Usuario usuario)
        {
            InitializeComponent();
            _usuarioActual = usuario;
            CargarContenidoPlantas();
            CargarSelectorDePlantas();
            btnDasboard.Click += BtnSearch_Click;
            iconButton2.Click += BtnDelete_Click;
            textBox1.KeyDown += TxtSearch_KeyDown;
            textBox1.Enter += TxtSearch_Enter;
            textBox1.Leave += TxtSearch_Leave;
        }
        private void CargarContenidoPlantas()
        {
            try
            {
                List<Plant> lista = _plantController.Listar();
                dgvPlants.DataSource = lista;

                if (dgvPlants.Columns.Contains("IdPlanta"))
                {
                    dgvPlants.Columns["IdPlanta"].Visible = false;
                }

                if (dgvPlants.Columns.Contains("Descripcion"))
                {
                    dgvPlants.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvPlants.Columns["Descripcion"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                    dgvPlants.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading plant catalog: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarSelectorDePlantas()
        {
            try
            {
                List<Plant> listaPlantas = _plantController.Listar();

                cmbPlants.DataSource = null;
                cmbPlants.DataSource = listaPlantas;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading plants: " + ex.Message);
            }
        }

        private void cmbPlants_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPlants.SelectedItem != null)
            {
                Plant plantaSeleccionada = (Plant)cmbPlants.SelectedItem;

                MostrarRequerimientosPlanta(plantaSeleccionada.IdPlanta);
            }
        }

        private void MostrarRequerimientosPlanta(int idPlanta)
        {
            try
            {
                List<Requirements> reqsFiltrados = _requirementsController.ObtenerPorPlanta(idPlanta);

                if (reqsFiltrados.Count > 0)
                {
                    Requirements req = reqsFiltrados[0];

                    lblAirTemp.Text = $"{req.TempAireMin:0.0} - {req.TempAireMax:0.0}";
                    lblAirHum.Text = $"{req.HumAireMin:0} - {req.HumAireMax:0}";
                    lblSoilHum.Text = $"{req.HumSueloMin:0} - {req.HumSueloMax:0}";
                    lblLight.Text = $"{req.LuzMin:0} - {req.LuzMax:0}";
                }
                else
                {
                    lblAirTemp.Text = "No data";
                    lblAirHum.Text = "No data";
                    lblSoilHum.Text = "No data";
                    lblLight.Text = "No data";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading requirements: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNewPlant_Click(object sender, EventArgs e)
        {
            if (_usuarioActual.TipoUsuario != "Admin" && _usuarioActual.TipoUsuario != "Tecnico")
            {
                MessageBox.Show("You do not have permission to add plants.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            using (newPlant ventanaConfig = new newPlant())
            {
                if (ventanaConfig.ShowDialog() == DialogResult.OK)
                {
                    CargarContenidoPlantas();
                    CargarSelectorDePlantas();
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            string busqueda = textBox1.Text.Trim();
            if (string.IsNullOrEmpty(busqueda) || busqueda == "Search plant")
            {
                CargarContenidoPlantas();
            }
            else
            {
                try
                {
                    List<Plant> lista = _plantController.Buscar(busqueda);
                    dgvPlants.DataSource = lista;
                    if (dgvPlants.Columns.Contains("IdPlanta"))
                        dgvPlants.Columns["IdPlanta"].Visible = false;
                    if (dgvPlants.Columns.Contains("Descripcion"))
                        dgvPlants.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al buscar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void TxtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnSearch_Click(sender, e);
                e.SuppressKeyPress = true;
            }
        }

        private void TxtSearch_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Search plant")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }

        private void TxtSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text.Trim()))
            {
                textBox1.Text = "Search plant";
                textBox1.ForeColor = Color.Gray;
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (_usuarioActual.TipoUsuario != "Admin" && _usuarioActual.TipoUsuario != "Tecnico")
            {
                MessageBox.Show("You do not have permission to delete plants.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (dgvPlants.CurrentRow == null)
            {
                MessageBox.Show("Select a plant from the table.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Plant seleccionada = (Plant)dgvPlants.CurrentRow.DataBoundItem;

            DialogResult confirm = MessageBox.Show($"Delete \"{seleccionada.Nombre}\"?\nIts requirements will also be deleted.",
                "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    _plantController.Eliminar(seleccionada.IdPlanta);
                    MessageBox.Show("Plant deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CargarContenidoPlantas();
                    CargarSelectorDePlantas();

                    lblAirTemp.Text = "No data";
                    lblAirHum.Text = "No data";
                    lblSoilHum.Text = "No data";
                    lblLight.Text = "No data";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}




