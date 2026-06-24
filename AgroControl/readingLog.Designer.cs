namespace AgroControl
{
    partial class readingLog
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(readingLog));
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            dgvReadings = new DataGridView();
            panel1 = new Panel();
            label28 = new Label();
            btnSave = new FontAwesome.Sharp.IconButton();
            label3 = new Label();
            label5 = new Label();
            dateTimePicker2 = new DateTimePicker();
            dateTimePicker1 = new DateTimePicker();
            pictureBox6 = new PictureBox();
            label1 = new Label();
            panel2 = new Panel();
            label2 = new Label();
            label4 = new Label();
            pictureBox1 = new PictureBox();
            dgvActions = new DataGridView();
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
            dataGridViewCellStyle1.BackColor = Color.WhiteSmoke;
            dgvReadings.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvReadings.BackgroundColor = SystemColors.Control;
            dgvReadings.BorderStyle = BorderStyle.None;
            dgvReadings.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvReadings.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.WhiteSmoke;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvReadings.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvReadings.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.WhiteSmoke;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = Color.Black;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvReadings.DefaultCellStyle = dataGridViewCellStyle3;
            dgvReadings.EnableHeadersVisualStyles = false;
            dgvReadings.GridColor = Color.LightGray;
            dgvReadings.Location = new Point(24, 96);
            dgvReadings.Name = "dgvReadings";
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.LightGray;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvReadings.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvReadings.RowHeadersVisible = false;
            dgvReadings.RowHeadersWidth = 51;
            dataGridViewCellStyle5.BackColor = Color.WhiteSmoke;
            dgvReadings.RowsDefaultCellStyle = dataGridViewCellStyle5;
            dgvReadings.Size = new Size(903, 260);
            dgvReadings.TabIndex = 4;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(247, 247, 247);
            panel1.Controls.Add(label28);
            panel1.Controls.Add(btnSave);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(dateTimePicker2);
            panel1.Controls.Add(dateTimePicker1);
            panel1.Controls.Add(pictureBox6);
            panel1.Controls.Add(dgvReadings);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(22, 27);
            panel1.Name = "panel1";
            panel1.Size = new Size(947, 379);
            panel1.TabIndex = 5;
            // 
            // label28
            // 
            label28.AutoSize = true;
            label28.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label28.ForeColor = Color.Gray;
            label28.Location = new Point(88, 48);
            label28.Name = "label28";
            label28.Size = new Size(252, 23);
            label28.TabIndex = 22;
            label28.Text = "Check the greenhouse readings";
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(84, 86, 240);
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSave.ForeColor = Color.WhiteSmoke;
            btnSave.IconChar = FontAwesome.Sharp.IconChar.Filter;
            btnSave.IconColor = Color.WhiteSmoke;
            btnSave.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnSave.IconSize = 25;
            btnSave.ImageAlign = ContentAlignment.MiddleLeft;
            btnSave.Location = new Point(800, 34);
            btnSave.Margin = new Padding(3, 4, 3, 4);
            btnSave.Name = "btnSave";
            btnSave.Padding = new Padding(11, 0, 0, 0);
            btnSave.Size = new Size(105, 33);
            btnSave.TabIndex = 21;
            btnSave.Text = "Filter";
            btnSave.TextAlign = ContentAlignment.MiddleLeft;
            btnSave.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += BtnFiltrar_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(603, 21);
            label3.Name = "label3";
            label3.Size = new Size(54, 23);
            label3.TabIndex = 20;
            label3.Text = "Hasta";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(409, 21);
            label5.Name = "label5";
            label5.Size = new Size(57, 23);
            label5.TabIndex = 19;
            label5.Text = "Desde";
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.CalendarMonthBackground = Color.WhiteSmoke;
            dateTimePicker2.Location = new Point(603, 48);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(162, 27);
            dateTimePicker2.TabIndex = 18;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CalendarMonthBackground = Color.WhiteSmoke;
            dateTimePicker1.Location = new Point(409, 48);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(162, 27);
            dateTimePicker1.TabIndex = 17;
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // pictureBox6
            // 
            pictureBox6.Image = (Image)resources.GetObject("pictureBox6.Image");
            pictureBox6.Location = new Point(24, 18);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(58, 49);
            pictureBox6.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox6.TabIndex = 16;
            pictureBox6.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label1.Location = new Point(88, 16);
            label1.Name = "label1";
            label1.Size = new Size(228, 32);
            label1.TabIndex = 6;
            label1.Text = "Recorded readings";
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(247, 247, 247);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(pictureBox1);
            panel2.Controls.Add(dgvActions);
            panel2.Location = new Point(22, 430);
            panel2.Name = "panel2";
            panel2.Size = new Size(947, 379);
            panel2.TabIndex = 17;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Gray;
            label2.Location = new Point(88, 49);
            label2.Name = "label2";
            label2.Size = new Size(241, 23);
            label2.TabIndex = 24;
            label2.Text = "Check the greenhouse actions";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label4.Location = new Point(88, 17);
            label4.Name = "label4";
            label4.Size = new Size(215, 32);
            label4.TabIndex = 23;
            label4.Text = "Recorded Actions";
            label4.Click += label4_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(24, 17);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(58, 55);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 16;
            pictureBox1.TabStop = false;
            // 
            // dgvActions
            // 
            dataGridViewCellStyle6.BackColor = Color.WhiteSmoke;
            dgvActions.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            dgvActions.BackgroundColor = SystemColors.Control;
            dgvActions.BorderStyle = BorderStyle.None;
            dgvActions.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvActions.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = Color.WhiteSmoke;
            dataGridViewCellStyle7.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle7.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.True;
            dgvActions.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            dgvActions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = Color.WhiteSmoke;
            dataGridViewCellStyle8.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle8.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = Color.Black;
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.False;
            dgvActions.DefaultCellStyle = dataGridViewCellStyle8;
            dgvActions.EnableHeadersVisualStyles = false;
            dgvActions.GridColor = Color.LightGray;
            dgvActions.Location = new Point(24, 96);
            dgvActions.Name = "dgvActions";
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = Color.LightGray;
            dataGridViewCellStyle9.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle9.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = DataGridViewTriState.True;
            dgvActions.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            dgvActions.RowHeadersVisible = false;
            dgvActions.RowHeadersWidth = 51;
            dataGridViewCellStyle10.BackColor = Color.WhiteSmoke;
            dgvActions.RowsDefaultCellStyle = dataGridViewCellStyle10;
            dgvActions.Size = new Size(903, 260);
            dgvActions.TabIndex = 4;
            // 
            // readingLog
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            AutoScrollMargin = new Size(0, 30);
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
        private DateTimePicker dateTimePicker1;
        private DateTimePicker dateTimePicker2;
        private Label label3;
        private Label label5;
        private FontAwesome.Sharp.IconButton btnSave;
        private Label label28;
        private Label label2;
        private Label label4;
    }
}

