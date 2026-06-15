namespace AgroControl
{
    partial class readingLog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            label1 = new Label();
            dgvDatosSensores = new DataGridView();
            label2 = new Label();
            dgvGrid = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvDatosSensores).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvGrid).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Bahnschrift SemiBold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(39, 30);
            label1.Name = "label1";
            label1.Size = new Size(158, 21);
            label1.TabIndex = 1;
            label1.Text = "Registered sensors";
            // 
            // dgvDatosSensores
            // 
            dataGridViewCellStyle1.BackColor = Color.WhiteSmoke;
            dgvDatosSensores.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvDatosSensores.BackgroundColor = SystemColors.Control;
            dgvDatosSensores.BorderStyle = BorderStyle.None;
            dgvDatosSensores.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvDatosSensores.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.WhiteSmoke;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvDatosSensores.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvDatosSensores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.WhiteSmoke;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = Color.Black;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvDatosSensores.DefaultCellStyle = dataGridViewCellStyle3;
            dgvDatosSensores.EnableHeadersVisualStyles = false;
            dgvDatosSensores.GridColor = Color.LightGray;
            dgvDatosSensores.Location = new Point(39, 64);
            dgvDatosSensores.Name = "dgvDatosSensores";
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.LightGray;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvDatosSensores.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvDatosSensores.RowHeadersVisible = false;
            dgvDatosSensores.RowHeadersWidth = 51;
            dataGridViewCellStyle5.BackColor = Color.WhiteSmoke;
            dgvDatosSensores.RowsDefaultCellStyle = dataGridViewCellStyle5;
            dgvDatosSensores.Size = new Size(433, 188);
            dgvDatosSensores.TabIndex = 2;
            dgvDatosSensores.CellContentClick += dgvDatosSensores_CellContentClick;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Bahnschrift SemiBold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(39, 269);
            label2.Name = "label2";
            label2.Size = new Size(151, 21);
            label2.TabIndex = 3;
            label2.Text = "Recorded readings";
            // 
            // dgvGrid
            // 
            dataGridViewCellStyle6.BackColor = Color.WhiteSmoke;
            dgvGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            dgvGrid.BackgroundColor = SystemColors.Control;
            dgvGrid.BorderStyle = BorderStyle.None;
            dgvGrid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvGrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = Color.WhiteSmoke;
            dataGridViewCellStyle7.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle7.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.True;
            dgvGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            dgvGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = Color.WhiteSmoke;
            dataGridViewCellStyle8.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle8.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = Color.Black;
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.False;
            dgvGrid.DefaultCellStyle = dataGridViewCellStyle8;
            dgvGrid.EnableHeadersVisualStyles = false;
            dgvGrid.GridColor = Color.LightGray;
            dgvGrid.Location = new Point(39, 310);
            dgvGrid.Name = "dgvGrid";
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = Color.LightGray;
            dataGridViewCellStyle9.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle9.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = DataGridViewTriState.True;
            dgvGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            dgvGrid.RowHeadersVisible = false;
            dgvGrid.RowHeadersWidth = 51;
            dataGridViewCellStyle10.BackColor = Color.WhiteSmoke;
            dgvGrid.RowsDefaultCellStyle = dataGridViewCellStyle10;
            dgvGrid.Size = new Size(851, 188);
            dgvGrid.TabIndex = 4;
            // 
            // readingLog
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(976, 761);
            Controls.Add(dgvGrid);
            Controls.Add(label2);
            Controls.Add(dgvDatosSensores);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "readingLog";
            Text = "readingTag";
            ((System.ComponentModel.ISupportInitialize)dgvDatosSensores).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private DataGridView dgvDatosSensores;
        private Label label2;
        private DataGridView dgvGrid;
    }
}