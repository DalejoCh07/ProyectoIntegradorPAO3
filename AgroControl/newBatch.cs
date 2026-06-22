using Entities;
using BusinessLogic;
using System;
using System.Data;
using System.Windows.Forms;

namespace AgroControl
{
    public partial class newBatch : Form
    {
        private int idInvernadero;

        // Constructor modificado para recibir el ID del invernadero
        public newBatch(int idInv)
        {
            InitializeComponent();
            idInvernadero = idInv;
            this.Load += newBatch_Load;
            btnSave.Click += btnSave_Click;
        }

        private void newBatch_Load(object sender, EventArgs e)
        {
            // Asumiendo que tienes un método que retorna las plantas
            // Si no lo tienes, puedes hacer un "SELECT idPlanta, nombre FROM PLANTAS" directo en PlantaBus
            string sql = "SELECT idPlanta, nombre FROM PLANTA";
            DataTable dtPlantas = DataAccess.DataAccess.getQuery(sql);

            cmbPlants.DataSource = dtPlantas;
            cmbPlants.DisplayMember = "nombre"; // Lo que ve el usuario
            cmbPlants.ValueMember = "idPlanta"; // Lo que guardamos en la DB
            cmbPlants.SelectedIndex = -1;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbPlants.SelectedValue == null || numPlants.Value <= 0)
            {
                MessageBox.Show("Por favor seleccione una planta e ingrese una cantidad válida.", "Advertencia");
                return;
            }

            try
            {
                Batch nuevoLote = new Batch
                {
                    IdPlanta = Convert.ToInt32(cmbPlants.SelectedValue),
                    CantPlantas = (int)numPlants.Value,
                    FechaSiembra = DateTime.Now,
                    IdInvernadero = idInvernadero
                };

                BatchBus.insertarLote(nuevoLote);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el lote: " + ex.Message, "Error");
            }
        }
    }
}