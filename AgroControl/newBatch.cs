using AgroControl.Controller.Implementations;
using AgroControl.Model.Entities;
using System;
using System.Data;
using System.Windows.Forms;

namespace AgroControl
{
    public partial class newBatch : Form
    {
        private int idInvernadero;

        public newBatch(int idInv)
        {
            InitializeComponent();
            idInvernadero = idInv;
            this.Load += newBatch_Load;
            btnSave.Click += btnSave_Click;
        }

        private void newBatch_Load(object sender, EventArgs e)
        {
            string sql = "SELECT idPlanta, nombre FROM PLANTA";
            DataTable dtPlantas = AgroControl.Model.DataAccess.GetQuery(sql);

            cmbPlants.DataSource = dtPlantas;
            cmbPlants.DisplayMember = "nombre";
            cmbPlants.ValueMember = "idPlanta";
            cmbPlants.SelectedIndex = -1;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbPlants.SelectedValue == null || numPlants.Value <= 0)
            {
                MessageBox.Show("Please select a plant and enter a valid quantity.", "Warning");
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

                new BatchController().Insertar(nuevoLote);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving batch: " + ex.Message, "Error");
            }
        }
    }
}



