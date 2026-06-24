using AgroControl.Controller.Implementations;
using System;
using System.Data;
using System.Windows.Forms;

namespace AgroControl.View
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

                if (dgvHistory.Columns.Contains("Fecha de Cosecha"))
                    dgvHistory.Columns["Fecha de Cosecha"].DefaultCellStyle.NullValue = "En proceso";

                dgvHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el historial: " + ex.Message, "Error");
            }
        }
    }
}
