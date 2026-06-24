using AgroControl.Controller.Implementations;
using System;
using System.Data;
using System.Windows.Forms;

namespace AgroControl
{
    public partial class historyBatch : Form
    {
        private int idInvernadero;

        public historyBatch(int idInv)
        {
            InitializeComponent();
            idInvernadero = idInv;
            this.Load += historyBatch_Load;
        }

        private void historyBatch_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dtHistorial = new BatchController().Historial(idInvernadero);
                dgvHistory.DataSource = dtHistorial;

                if (dgvHistory.Columns.Contains("idLote"))
                    dgvHistory.Columns["idLote"].Visible = false;

                if (dgvHistory.Columns.Contains("Harvest Date"))
                    dgvHistory.Columns["Harvest Date"].DefaultCellStyle.NullValue = "In progress";

                dgvHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading history: " + ex.Message, "Error");
            }
        }
    }
}


