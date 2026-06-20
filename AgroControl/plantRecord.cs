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
        /*
        // 3. Botón para guardar un nuevo requerimiento
        private void btnGuardarRequerimiento_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbPlantas.SelectedItem == null)
                {
                    MessageBox.Show("Seleccione una planta primero.");
                    return;
                }

                Planta plantaSeleccionada = (Planta)cmbPlantas.SelectedItem;

                Requerimiento nuevoReq = new Requerimiento();
                nuevoReq.IdPlanta = plantaSeleccionada.IdPlanta; // Toma el ID directo del ComboBox
                nuevoReq.Tipo = txtTipoReq.Text.Trim(); // Ej: 'humSuelo'
                nuevoReq.ValorMinimo = Convert.ToDecimal(txtMinimo.Text);
                nuevoReq.ValorMaximo = Convert.ToDecimal(txtMaximo.Text);

                int resultado = FRequerimiento.insertar(nuevoReq);

                if (resultado > 0)
                {
                    MessageBox.Show("Requerimiento asignado a la planta correctamente.");
                    // Refrescamos la tabla para ver el nuevo registro
                    CargarTablaRequerimientos(plantaSeleccionada.IdPlanta);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Verifique los datos numéricos ingresados. " + ex.Message, "Error");
            }
        }
        */

        /*
        // Evento click del botón para registrar
        private void btnIngresarPlanta_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar que los campos obligatorios contengan texto
                if (string.IsNullOrEmpty(txtNombre.Text.Trim()) || string.IsNullOrEmpty(txtNombreCien.Text.Trim()))
                {
                    MessageBox.Show("El nombre común y el nombre científico son requeridos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Mapeo del contenido de los controles a la entidad
                Planta nuevaPlanta = new Planta();
                nuevaPlanta.Nombre = txtNombre.Text.Trim();
                nuevaPlanta.NombreCien = txtNombreCien.Text.Trim();
                nuevaPlanta.Descripcion = txtDescripcion.Text.Trim();

                // Envío a la capa de negocio
                int resultado = FPlanta.insertar(nuevaPlanta);

                if (resultado > 0)
                {
                    MessageBox.Show("Planta registrada correctamente en el catálogo.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Limpieza básica de las cajas de texto
                    txtNombre.Clear();
                    txtNombreCien.Clear();
                    txtDescripcion.Clear();

                    // Actualización automática de los datos en pantalla
                    CargarContenidoPlantas();
                }
                else
                {
                    MessageBox.Show("No se pudo completar el registro.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al procesar el registro: " + ex.Message, "Error General", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        */
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
