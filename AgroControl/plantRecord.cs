using BusinessLogic;
using Entities;
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
        public plantRecord()
        {
            InitializeComponent();
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
                List<Plant> lista = PlantBus.getPlantas();
                dgvPlants.DataSource = lista;

                // --- CÓDIGO PARA OCULTAR LA COLUMNA ID ---
                // Verificamos que la columna exista para evitar errores
                if (dgvPlants.Columns.Contains("IdPlanta"))
                {
                    // Apagamos la visibilidad de la columna
                    dgvPlants.Columns["IdPlanta"].Visible = false;
                }

                // (Aquí también iría el código que te di antes para alargar la columna Descripción)
                if (dgvPlants.Columns.Contains("Descripcion"))
                {
                    dgvPlants.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvPlants.Columns["Descripcion"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                    dgvPlants.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el catálogo de plantas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarSelectorDePlantas()
        {
            try
            {
                // Reutilizamos el método que ya tienes en FPlanta
                List<Plant> listaPlantas = PlantBus.getPlantas();

                // Limpiamos y asignamos los datos al ComboBox
                cmbPlants.DataSource = null;
                cmbPlants.DataSource = listaPlantas;

                // ¡Importante! Como en la clase Planta hiciste el "override string ToString()", 
                // el ComboBox mostrará el nombre automáticamente.
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las plantas: " + ex.Message);
            }
        }

        // 2. ESTE EVENTO SE DISPARA CUANDO EL USUARIO ELIGE OTRA PLANTA
        private void cmbPlants_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verificamos que realmente haya una planta seleccionada
            if (cmbPlants.SelectedItem != null)
            {
                // Extraemos la planta seleccionada del ComboBox
                Plant plantaSeleccionada = (Plant)cmbPlants.SelectedItem;

                // Llamamos al método que filtra la tabla pasándole el ID de la planta
                MostrarRequerimientosPlanta(plantaSeleccionada.IdPlanta);
            }
        }

        // Método para llenar el DataGridView con los datos filtrados
        private void MostrarRequerimientosPlanta(int idPlanta)
        {
            try
            {
                // 1. Obtenemos la lista desde la capa de Negocio
                List<Requirements> reqsFiltrados = RequirementsBus.getRequerimientosPorPlanta(idPlanta);

                // 2. Verificamos si la planta tiene parámetros registrados
                if (reqsFiltrados.Count > 0)
                {
                    // Tomamos el primer registro de la lista (ya que una planta tiene 1 fila de requerimientos)
                    Requirements req = reqsFiltrados[0];

                    // 3. Formateamos el texto inyectando los valores y sus respectivas unidades
                    // El ":0" quita los decimales innecesarios, y ":0.0" deja un decimal si lo prefieres
                    lblAirTemp.Text = $"{req.TempAireMin:0.0} - {req.TempAireMax:0.0}";
                    lblAirHum.Text = $"{req.HumAireMin:0} - {req.HumAireMax:0}";
                    lblSoilHum.Text = $"{req.HumSueloMin:0} - {req.HumSueloMax:0}";
                    lblLight.Text = $"{req.LuzMin:0} - {req.LuzMax:0}";
                }
                else
                {
                    // Si la planta es nueva y aún no tiene requerimientos, dejamos los campos vacíos o con un aviso
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
            if (string.IsNullOrEmpty(busqueda) || busqueda == "Buscar planta")
            {
                CargarContenidoPlantas();
            }
            else
            {
                try
                {
                    List<Plant> lista = PlantBus.buscar(busqueda);
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
            if (textBox1.Text == "Buscar planta")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }

        private void TxtSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text.Trim()))
            {
                textBox1.Text = "Buscar planta";
                textBox1.ForeColor = Color.Gray;
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvPlants.CurrentRow == null)
            {
                MessageBox.Show("Selecciona una planta en la tabla.", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Plant seleccionada = (Plant)dgvPlants.CurrentRow.DataBoundItem;

            DialogResult confirm = MessageBox.Show($"¿Eliminar \"{seleccionada.Nombre}\"?\nSe borrarán también sus requerimientos.",
                "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    PlantBus.eliminar(seleccionada.IdPlanta);
                    MessageBox.Show("Planta eliminada correctamente.", "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CargarContenidoPlantas();
                    CargarSelectorDePlantas();

                    lblAirTemp.Text = "No data";
                    lblAirHum.Text = "No data";
                    lblSoilHum.Text = "No data";
                    lblLight.Text = "No data";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
