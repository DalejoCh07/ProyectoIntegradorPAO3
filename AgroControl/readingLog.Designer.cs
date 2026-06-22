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
            DataGridViewCellStyle dataGridViewCellStyle11 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle12 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle13 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle14 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle15 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(readingLog));
            DataGridViewCellStyle dataGridViewCellStyle16 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle17 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle18 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle19 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle20 = new DataGridViewCellStyle();
            dgvReadings = new DataGridView();
            panel1 = new Panel();
            pictureBox6 = new PictureBox();
            label1 = new Label();
            panel2 = new Panel();
            pictureBox1 = new PictureBox();
            dgvActions = new DataGridView();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvReadings).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvActions).BeginInit();
            SuspendLayout();
            // 
            // dgvReadings
            // 
            dataGridViewCellStyle11.BackColor = Color.WhiteSmoke;
            dgvReadings.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle11;
            dgvReadings.BackgroundColor = SystemColors.Control;
            dgvReadings.BorderStyle = BorderStyle.None;
            dgvReadings.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvReadings.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle12.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = Color.WhiteSmoke;
            dataGridViewCellStyle12.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle12.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = DataGridViewTriState.True;
            dgvReadings.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle12;
            dgvReadings.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle13.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = Color.WhiteSmoke;
            dataGridViewCellStyle13.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle13.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle13.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = Color.Black;
            dataGridViewCellStyle13.WrapMode = DataGridViewTriState.False;
            dgvReadings.DefaultCellStyle = dataGridViewCellStyle13;
            dgvReadings.EnableHeadersVisualStyles = false;
            dgvReadings.GridColor = Color.LightGray;
            dgvReadings.Location = new Point(24, 72);
            dgvReadings.Name = "dgvReadings";
            dataGridViewCellStyle14.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = Color.LightGray;
            dataGridViewCellStyle14.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle14.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle14.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = DataGridViewTriState.True;
            dgvReadings.RowHeadersDefaultCellStyle = dataGridViewCellStyle14;
            dgvReadings.RowHeadersVisible = false;
            dgvReadings.RowHeadersWidth = 51;
            dataGridViewCellStyle15.BackColor = Color.WhiteSmoke;
            dgvReadings.RowsDefaultCellStyle = dataGridViewCellStyle15;
            dgvReadings.Size = new Size(903, 187);
            dgvReadings.TabIndex = 4;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(247, 247, 247);
            panel1.Controls.Add(pictureBox6);
            panel1.Controls.Add(dgvReadings);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(22, 27);
            panel1.Name = "panel1";
            panel1.Size = new Size(947, 283);
            panel1.TabIndex = 5;
            // 
            // pictureBox6
            // 
            pictureBox6.Image = (Image)resources.GetObject("pictureBox6.Image");
            pictureBox6.Location = new Point(24, 17);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(44, 40);
            pictureBox6.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox6.TabIndex = 16;
            pictureBox6.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(74, 17);
            label1.Name = "label1";
            label1.Size = new Size(188, 28);
            label1.TabIndex = 6;
            label1.Text = "Recorded readings";
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(247, 247, 247);
            panel2.Controls.Add(pictureBox1);
            panel2.Controls.Add(dgvActions);
            panel2.Controls.Add(label2);
            panel2.Location = new Point(22, 325);
            panel2.Name = "panel2";
            panel2.Size = new Size(947, 283);
            panel2.TabIndex = 17;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(24, 17);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(44, 40);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 16;
            pictureBox1.TabStop = false;
            // 
            // dgvActions
            // 
            dataGridViewCellStyle16.BackColor = Color.WhiteSmoke;
            dgvActions.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle16;
            dgvActions.BackgroundColor = SystemColors.Control;
            dgvActions.BorderStyle = BorderStyle.None;
            dgvActions.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvActions.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle17.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle17.BackColor = Color.WhiteSmoke;
            dataGridViewCellStyle17.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle17.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle17.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle17.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle17.WrapMode = DataGridViewTriState.True;
            dgvActions.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle17;
            dgvActions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle18.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.BackColor = Color.WhiteSmoke;
            dataGridViewCellStyle18.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle18.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle18.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle18.SelectionForeColor = Color.Black;
            dataGridViewCellStyle18.WrapMode = DataGridViewTriState.False;
            dgvActions.DefaultCellStyle = dataGridViewCellStyle18;
            dgvActions.EnableHeadersVisualStyles = false;
            dgvActions.GridColor = Color.LightGray;
            dgvActions.Location = new Point(24, 72);
            dgvActions.Name = "dgvActions";
            dataGridViewCellStyle19.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle19.BackColor = Color.LightGray;
            dataGridViewCellStyle19.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle19.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle19.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle19.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle19.WrapMode = DataGridViewTriState.True;
            dgvActions.RowHeadersDefaultCellStyle = dataGridViewCellStyle19;
            dgvActions.RowHeadersVisible = false;
            dgvActions.RowHeadersWidth = 51;
            dataGridViewCellStyle20.BackColor = Color.WhiteSmoke;
            dgvActions.RowsDefaultCellStyle = dataGridViewCellStyle20;
            dgvActions.Size = new Size(903, 187);
            dgvActions.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(74, 17);
            label2.Name = "label2";
            label2.Size = new Size(175, 28);
            label2.TabIndex = 6;
            label2.Text = "Recorded actions";
            // 
            // readingLog
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(999, 620);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "readingLog";
            Text = "readingTag";
            ((System.ComponentModel.ISupportInitialize)dgvReadings).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvActions).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private DataGridView dgvReadings;
        private Panel panel1;
        private Label label1;
        private PictureBox pictureBox6;
        private Panel panel2;
        private PictureBox pictureBox1;
        private DataGridView dgvActions;
        private Label label2;
    }
}