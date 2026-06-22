using BusinessLogic;
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
                DataTable dtHistorial = BatchBus.obtenerHistorial(idInvernadero);
                dgvHistory.DataSource = dtHistorial;

                // Configuraciones visuales del DataGridView
                if (dgvHistory.Columns.Contains("idLote"))
                    dgvHistory.Columns["idLote"].Visible = false;

                // Formato para mostrar campos nulos en las fechas si se da el caso
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