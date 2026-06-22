using BusinessLogic;
using Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace AgroControl
{
    public partial class technical : Form
    {
        public technical()
        {
            InitializeComponent();

            // Suscripción de eventos corregida
            // Asumo que el botón de buscar se llama btnSearch y no btnDasboard
            btnSearch.Click += BtnSearchGreenhouse_Click;
            btnDeleteGreenhouse.Click += BtnDeleteGreenhouse_Click;
            btnDeleteSensor.Click += BtnDeleteSensor_Click;
            btnDeleteActuator.Click += BtnDeleteActuator_Click;
            textBox1.KeyDown += TxtSearchGreenhouse_KeyDown;
            textBox1.Enter += TxtSearch_Enter;
            textBox1.Leave += TxtSearch_Leave;

            btnNewGreenhouse.Click += BtnNewGreenhouse_Click;
            btnNewSensor.Click += BtnNewSensor_Click;
            btnNewActuator.Click += BtnNewActuator_Click;

            // EL EVENTO ESTRELLA: Se dispara cada vez que seleccionas un invernadero distinto
            dgvPlants.SelectionChanged += DgvPlants_SelectionChanged;

            // Solo cargamos los invernaderos al inicio. 
            // El evento SelectionChanged se encargará de cargar los sensores y actuadores automáticamente.
            CargarGreenhouses();
        }

        // ---- NUEVA LÓGICA DE SINCRONIZACIÓN ----
        private void DgvPlants_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPlants.CurrentRow != null)
            {
                // Si hay un invernadero seleccionado, extraemos su ID y cargamos sus dependencias
                Greenhouse sel = (Greenhouse)dgvPlants.CurrentRow.DataBoundItem;
                CargarSensores(sel.IdInvernadero);
                CargarActuadores(sel.IdInvernadero);
            }
            else
            {
                // Si no hay nada seleccionado (ej. buscaron algo que no existe), vaciamos las tablas
                dataGridView1.DataSource = null;
                dataGridView2.DataSource = null;
            }
        }

        // Resto de los botones "Nuevo" (sin cambios mayores)
        private void BtnNewGreenhouse_Click(object sender, EventArgs e)
        {
            using (newGreenhouse frm = new newGreenhouse())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                    CargarGreenhouses(); // Esto disparará SelectionChanged automáticamente
            }
        }

        private void BtnNewSensor_Click(object sender, EventArgs e)
        {
            // Opcional: Podrías pasar el ID del invernadero seleccionado al formulario nuevo
            using (newSensor frm = new newSensor())
            {
                if (frm.ShowDialog() == DialogResult.OK && dgvPlants.CurrentRow != null)
                {
                    Greenhouse sel = (Greenhouse)dgvPlants.CurrentRow.DataBoundItem;
                    CargarSensores(sel.IdInvernadero);
                }
            }
        }

        private void BtnNewActuator_Click(object sender, EventArgs e)
        {
            using (newActuator frm = new newActuator())
            {
                if (frm.ShowDialog() == DialogResult.OK && dgvPlants.CurrentRow != null)
                {
                    Greenhouse sel = (Greenhouse)dgvPlants.CurrentRow.DataBoundItem;
                    CargarActuadores(sel.IdInvernadero);
                }
            }
        }

        // ---- GREENHOUSES ----

        private void CargarGreenhouses()
        {
            try
            {
                List<Greenhouse> lista = GreenhouseBus.getGreenhouses();
                dgvPlants.DataSource = lista;
                if (dgvPlants.Columns.Contains("IdInvernadero"))
                    dgvPlants.Columns["IdInvernadero"].Visible = false;
                if (dgvPlants.Columns.Contains("Descripcion"))
                    dgvPlants.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar invernaderos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSearchGreenhouse_Click(object sender, EventArgs e)
        {
            string busqueda = textBox1.Text.Trim();
            if (string.IsNullOrEmpty(busqueda) || busqueda == "Search Greenhouse")
            {
                CargarGreenhouses();
            }
            else
            {
                try
                {
                    List<Greenhouse> lista = GreenhouseBus.buscar(busqueda);
                    dgvPlants.DataSource = lista;
                    // Los formatos se mantienen igual
                    if (dgvPlants.Columns.Contains("IdInvernadero"))
                        dgvPlants.Columns["IdInvernadero"].Visible = false;
                    if (dgvPlants.Columns.Contains("Descripcion"))
                        dgvPlants.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al buscar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void TxtSearchGreenhouse_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnSearchGreenhouse_Click(sender, e);
                e.SuppressKeyPress = true;
            }
        }

        private void TxtSearch_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Search Greenhouse")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }

        private void TxtSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text.Trim()))
            {
                textBox1.Text = "Search Greenhouse";
                textBox1.ForeColor = Color.Gray;
            }
        }

        private void BtnDeleteGreenhouse_Click(object sender, EventArgs e)
        {
            if (dgvPlants.CurrentRow == null) return;

            Greenhouse sel = (Greenhouse)dgvPlants.CurrentRow.DataBoundItem;
            DialogResult confirm = MessageBox.Show($"¿Eliminar \"{sel.Nombre}\"?\nSe borrarán también sus sensores y actuadores.",
                "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    GreenhouseBus.eliminar(sel.IdInvernadero);
                    MessageBox.Show("Invernadero eliminado.", "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarGreenhouses();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ---- SENSORS (MODIFICADO) ----

        private void CargarSensores(int idInvernadero)
        {
            try
            {
                // Usamos el nuevo método filtrado
                List<Sensor> lista = SensorBus.getSensoresPorInvernadero(idInvernadero);
                dataGridView1.DataSource = lista;

                if (dataGridView1.Columns.Contains("IdSensor"))
                    dataGridView1.Columns["IdSensor"].Visible = false;
                if (dataGridView1.Columns.Contains("IdInvernadero"))
                    dataGridView1.Columns["IdInvernadero"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar sensores: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDeleteSensor_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;

            Sensor sel = (Sensor)dataGridView1.CurrentRow.DataBoundItem;
            DialogResult confirm = MessageBox.Show($"¿Eliminar sensor \"{sel.Tipo}\"?\nSe borrarán también sus lecturas.",
                "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    SensorBus.eliminar(sel.IdSensor);
                    MessageBox.Show("Sensor eliminado.", "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Recargamos pasándole el ID actual
                    CargarSensores(sel.IdInvernadero);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ---- ACTUATORS (MODIFICADO) ----

        private void CargarActuadores(int idInvernadero)
        {
            try
            {
                // Usamos el nuevo método filtrado
                List<Actuador> lista = ActuadorBus.getActuadoresPorInvernadero(idInvernadero);
                dataGridView2.DataSource = lista;

                if (dataGridView2.Columns.Contains("IdActuador"))
                    dataGridView2.Columns["IdActuador"].Visible = false;
                if (dataGridView2.Columns.Contains("IdInvernadero"))
                    dataGridView2.Columns["IdInvernadero"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar actuadores: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDeleteActuator_Click(object sender, EventArgs e)
        {
            if (dataGridView2.CurrentRow == null) return;

            Actuador sel = (Actuador)dataGridView2.CurrentRow.DataBoundItem;
            DialogResult confirm = MessageBox.Show($"¿Eliminar actuador \"{sel.Tipo}\"?",
                "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    ActuadorBus.eliminar(sel.IdActuador);
                    MessageBox.Show("Actuador eliminado.", "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Recargamos pasándole el ID actual
                    CargarActuadores(sel.IdInvernadero);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
