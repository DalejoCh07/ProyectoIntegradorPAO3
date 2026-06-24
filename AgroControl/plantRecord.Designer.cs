namespace AgroControl
{
    partial class plantRecord
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(plantRecord));
            dgvPlants = new DataGridView();
            label1 = new Label();
            cmbPlants = new ComboBox();
            label5 = new Label();
            lblAirHum = new Label();
            label3 = new Label();
            lblAirTemp = new Label();
            label4 = new Label();
            lblSoilHum = new Label();
            lblLight = new Label();
            label6 = new Label();
            label2 = new Label();
            panel6 = new Panel();
            pictureBox5 = new PictureBox();
            label7 = new Label();
            panel2 = new Panel();
            label8 = new Label();
            pictureBox2 = new PictureBox();
            panel3 = new Panel();
            label9 = new Label();
            pictureBox3 = new PictureBox();
            panel4 = new Panel();
            label10 = new Label();
            pictureBox4 = new PictureBox();
            panel1 = new Panel();
            label13 = new Label();
            pictureBox1 = new PictureBox();
            panel5 = new Panel();
            pictureBox6 = new PictureBox();
            iconButton2 = new FontAwesome.Sharp.IconButton();
            btnNewPlant = new FontAwesome.Sharp.IconButton();
            btnDasboard = new FontAwesome.Sharp.IconButton();
            textBox1 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvPlants).BeginInit();
            panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            SuspendLayout();
            // 
            // dgvPlants
            // 
            dataGridViewCellStyle1.BackColor = Color.WhiteSmoke;
            dgvPlants.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvPlants.BackgroundColor = SystemColors.Control;
            dgvPlants.BorderStyle = BorderStyle.None;
            dgvPlants.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvPlants.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.WhiteSmoke;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvPlants.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvPlants.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.WhiteSmoke;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = Color.WhiteSmoke;
            dataGridViewCellStyle3.SelectionForeColor = Color.Black;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvPlants.DefaultCellStyle = dataGridViewCellStyle3;
            dgvPlants.EnableHeadersVisualStyles = false;
            dgvPlants.GridColor = Color.LightGray;
            dgvPlants.Location = new Point(9, 59);
            dgvPlants.Name = "dgvPlants";
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.LightGray;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvPlants.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvPlants.RowHeadersVisible = false;
            dgvPlants.RowHeadersWidth = 51;
            dataGridViewCellStyle5.BackColor = Color.WhiteSmoke;
            dgvPlants.RowsDefaultCellStyle = dataGridViewCellStyle5;
            dgvPlants.Size = new Size(580, 172);
            dgvPlants.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(52, 11);
            label1.Name = "label1";
            label1.Size = new Size(177, 28);
            label1.TabIndex = 5;
            label1.Text = "Registered plants";
            
            // 
            // cmbPlants
            // 
            cmbPlants.BackColor = Color.WhiteSmoke;
            cmbPlants.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPlants.ForeColor = Color.Black;
            cmbPlants.FormattingEnabled = true;
            cmbPlants.Location = new Point(26, 118);
            cmbPlants.Name = "cmbPlants";
            cmbPlants.Size = new Size(151, 28);
            cmbPlants.TabIndex = 9;
            cmbPlants.SelectedValueChanged += cmbPlants_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(72, 13);
            label5.Name = "label5";
            label5.Size = new Size(110, 23);
            label5.TabIndex = 2;
            label5.Text = "Soil humidity";
            
            // 
            // lblAirHum
            // 
            lblAirHum.AutoSize = true;
            lblAirHum.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAirHum.ForeColor = Color.LimeGreen;
            lblAirHum.Location = new Point(72, 59);
            lblAirHum.Name = "lblAirHum";
            lblAirHum.Size = new Size(51, 23);
            lblAirHum.TabIndex = 7;
            lblAirHum.Text = "value";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(72, 13);
            label3.Name = "label3";
            label3.Size = new Size(131, 23);
            label3.TabIndex = 0;
            label3.Text = "Air temperature";
            // 
            // lblAirTemp
            // 
            lblAirTemp.AutoSize = true;
            lblAirTemp.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAirTemp.ForeColor = Color.Red;
            lblAirTemp.Location = new Point(72, 59);
            lblAirTemp.Name = "lblAirTemp";
            lblAirTemp.Size = new Size(51, 23);
            lblAirTemp.TabIndex = 4;
            lblAirTemp.Text = "value";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(74, 13);
            label4.Name = "label4";
            label4.Size = new Size(104, 23);
            label4.TabIndex = 1;
            label4.Text = "Air humidity";
            // 
            // lblSoilHum
            // 
            lblSoilHum.AutoSize = true;
            lblSoilHum.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSoilHum.ForeColor = SystemColors.Highlight;
            lblSoilHum.Location = new Point(74, 59);
            lblSoilHum.Name = "lblSoilHum";
            lblSoilHum.Size = new Size(51, 23);
            lblSoilHum.TabIndex = 6;
            lblSoilHum.Text = "value";
            // 
            // lblLight
            // 
            lblLight.AutoSize = true;
            lblLight.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLight.ForeColor = Color.Orange;
            lblLight.Location = new Point(74, 59);
            lblLight.Name = "lblLight";
            lblLight.Size = new Size(51, 23);
            lblLight.TabIndex = 5;
            lblLight.Text = "value";
            
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(69, 13);
            label6.Name = "label6";
            label6.Size = new Size(118, 23);
            label6.TabIndex = 3;
            label6.Text = "Light intensity";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(69, 29);
            label2.Name = "label2";
            label2.Size = new Size(235, 28);
            label2.TabIndex = 7;
            label2.Text = "Requirements per plant";
            // 
            // panel6
            // 
            panel6.BackColor = Color.FromArgb(247, 247, 247);
            panel6.Controls.Add(pictureBox5);
            panel6.Controls.Add(label7);
            panel6.Controls.Add(panel2);
            panel6.Controls.Add(panel3);
            panel6.Controls.Add(panel4);
            panel6.Controls.Add(panel1);
            panel6.Controls.Add(label2);
            panel6.Controls.Add(cmbPlants);
            panel6.Location = new Point(24, 287);
            panel6.Name = "panel6";
            panel6.Size = new Size(951, 321);
            panel6.TabIndex = 11;
            // 
            // pictureBox5
            // 
            pictureBox5.Image = Properties.Resources.checklist;
            pictureBox5.Location = new Point(9, 38);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(54, 52);
            pictureBox5.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox5.TabIndex = 8;
            pictureBox5.TabStop = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(69, 67);
            label7.Name = "label7";
            label7.Size = new Size(274, 23);
            label7.TabIndex = 12;
            label7.Text = "Select a plant to observe its needs.";
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(252, 252, 252);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(pictureBox2);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(lblAirTemp);
            panel2.Location = new Point(257, 167);
            panel2.Name = "panel2";
            panel2.Size = new Size(210, 136);
            panel2.TabIndex = 9;
            // 
            // label8
            // 
            label8.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.Gray;
            label8.Location = new Point(72, 98);
            label8.Name = "label8";
            label8.Size = new Size(71, 29);
            label8.TabIndex = 14;
            label8.Text = "Â°C";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.termometer;
            pictureBox2.Location = new Point(12, 49);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(54, 52);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 8;
            pictureBox2.TabStop = false;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(252, 252, 252);
            panel3.Controls.Add(label9);
            panel3.Controls.Add(pictureBox3);
            panel3.Controls.Add(label4);
            panel3.Controls.Add(lblSoilHum);
            panel3.Location = new Point(488, 167);
            panel3.Name = "panel3";
            panel3.Size = new Size(210, 136);
            panel3.TabIndex = 9;
            // 
            // label9
            // 
            label9.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.Gray;
            label9.Location = new Point(74, 98);
            label9.Name = "label9";
            label9.Size = new Size(71, 29);
            label9.TabIndex = 15;
            label9.Text = "%";
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.drop;
            pictureBox3.Location = new Point(14, 48);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(54, 52);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 9;
            pictureBox3.TabStop = false;
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(252, 252, 252);
            panel4.Controls.Add(label10);
            panel4.Controls.Add(pictureBox4);
            panel4.Controls.Add(lblLight);
            panel4.Controls.Add(label6);
            panel4.Location = new Point(719, 167);
            panel4.Name = "panel4";
            panel4.Size = new Size(210, 136);
            panel4.TabIndex = 9;
            // 
            // label10
            // 
            label10.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.ForeColor = Color.Gray;
            label10.Location = new Point(74, 98);
            label10.Name = "label10";
            label10.Size = new Size(71, 29);
            label10.TabIndex = 16;
            label10.Text = "lx";
            // 
            // pictureBox4
            // 
            pictureBox4.Image = Properties.Resources.contrast;
            pictureBox4.Location = new Point(14, 47);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(54, 52);
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox4.TabIndex = 10;
            pictureBox4.TabStop = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(252, 252, 252);
            panel1.Controls.Add(label13);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(lblAirHum);
            panel1.Location = new Point(26, 167);
            panel1.Name = "panel1";
            panel1.Size = new Size(210, 136);
            panel1.TabIndex = 8;
            // 
            // label13
            // 
            label13.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label13.ForeColor = Color.Gray;
            label13.Location = new Point(72, 98);
            label13.Name = "label13";
            label13.Size = new Size(71, 29);
            label13.TabIndex = 13;
            label13.Text = "%";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.plant;
            pictureBox1.Location = new Point(12, 49);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(54, 52);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            // 
            // panel5
            // 
            panel5.BackColor = Color.FromArgb(247, 247, 247);
            panel5.Controls.Add(pictureBox6);
            panel5.Controls.Add(label1);
            panel5.Controls.Add(iconButton2);
            panel5.Controls.Add(btnNewPlant);
            panel5.Controls.Add(btnDasboard);
            panel5.Controls.Add(textBox1);
            panel5.Controls.Add(dgvPlants);
            panel5.Location = new Point(24, 21);
            panel5.Name = "panel5";
            panel5.Size = new Size(951, 250);
            panel5.TabIndex = 12;
            // 
            // pictureBox6
            // 
            pictureBox6.Image = (Image)resources.GetObject("pictureBox6.Image");
            pictureBox6.Location = new Point(9, 11);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(37, 42);
            pictureBox6.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox6.TabIndex = 14;
            pictureBox6.TabStop = false;
            // 
            // iconButton2
            // 
            iconButton2.BackColor = Color.FromArgb(247, 77, 77);
            iconButton2.FlatAppearance.BorderSize = 0;
            iconButton2.FlatStyle = FlatStyle.Flat;
            iconButton2.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            iconButton2.ForeColor = Color.WhiteSmoke;
            iconButton2.IconChar = FontAwesome.Sharp.IconChar.MinusCircle;
            iconButton2.IconColor = Color.WhiteSmoke;
            iconButton2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton2.IconSize = 25;
            iconButton2.ImageAlign = ContentAlignment.MiddleLeft;
            iconButton2.Location = new Point(621, 161);
            iconButton2.Margin = new Padding(3, 4, 3, 4);
            iconButton2.Name = "iconButton2";
            iconButton2.Padding = new Padding(11, 0, 0, 0);
            iconButton2.Size = new Size(148, 38);
            iconButton2.TabIndex = 12;
            iconButton2.Text = "Delete plant";
            iconButton2.TextAlign = ContentAlignment.MiddleLeft;
            iconButton2.TextImageRelation = TextImageRelation.ImageBeforeText;
            iconButton2.UseVisualStyleBackColor = false;
            // 
            // btnNewPlant
            // 
            btnNewPlant.BackColor = Color.FromArgb(84, 86, 240);
            btnNewPlant.FlatAppearance.BorderSize = 0;
            btnNewPlant.FlatStyle = FlatStyle.Flat;
            btnNewPlant.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNewPlant.ForeColor = Color.WhiteSmoke;
            btnNewPlant.IconChar = FontAwesome.Sharp.IconChar.PlusSquare;
            btnNewPlant.IconColor = Color.WhiteSmoke;
            btnNewPlant.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnNewPlant.IconSize = 25;
            btnNewPlant.ImageAlign = ContentAlignment.MiddleLeft;
            btnNewPlant.Location = new Point(621, 116);
            btnNewPlant.Margin = new Padding(3, 4, 3, 4);
            btnNewPlant.Name = "btnNewPlant";
            btnNewPlant.Padding = new Padding(11, 0, 0, 0);
            btnNewPlant.Size = new Size(148, 37);
            btnNewPlant.TabIndex = 11;
            btnNewPlant.Text = "New plant";
            btnNewPlant.TextAlign = ContentAlignment.MiddleLeft;
            btnNewPlant.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnNewPlant.UseVisualStyleBackColor = false;
            btnNewPlant.Click += btnNewPlant_Click;
            // 
            // btnDasboard
            // 
            btnDasboard.BackColor = Color.FromArgb(84, 86, 240);
            btnDasboard.FlatAppearance.BorderSize = 0;
            btnDasboard.FlatStyle = FlatStyle.Flat;
            btnDasboard.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDasboard.ForeColor = Color.WhiteSmoke;
            btnDasboard.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlassArrowRight;
            btnDasboard.IconColor = Color.WhiteSmoke;
            btnDasboard.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnDasboard.IconSize = 25;
            btnDasboard.ImageAlign = ContentAlignment.MiddleLeft;
            btnDasboard.Location = new Point(788, 55);
            btnDasboard.Margin = new Padding(3, 4, 3, 4);
            btnDasboard.Name = "btnDasboard";
            btnDasboard.Padding = new Padding(11, 0, 0, 0);
            btnDasboard.Size = new Size(117, 37);
            btnDasboard.TabIndex = 10;
            btnDasboard.Text = "Search";
            btnDasboard.TextAlign = ContentAlignment.MiddleLeft;
            btnDasboard.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnDasboard.UseVisualStyleBackColor = false;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.WhiteSmoke;
            textBox1.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.ForeColor = Color.Gray;
            textBox1.Location = new Point(621, 59);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(148, 30);
            textBox1.TabIndex = 7;
            textBox1.Text = "Search plant";
            // 
            // plantRecord
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(999, 620);
            Controls.Add(panel6);
            Controls.Add(panel5);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "plantRecord";
            Text = "plantRecord";
            ((System.ComponentModel.ISupportInitialize)dgvPlants).EndInit();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private DataGridView dgvPlants;
        private Label label1;
        private ComboBox cmbPlants;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label lblAirHum;
        private Label lblSoilHum;
        private Label lblLight;
        private Label lblAirTemp;
        private Label label2;
        private Panel panel6;
        private Label label7;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Panel panel1;
        private PictureBox pictureBox1;
        private PictureBox pictureBox5;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private PictureBox pictureBox4;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label13;
        private Panel panel5;
        private TextBox textBox1;
        private FontAwesome.Sharp.IconButton btnNewPlant;
        private FontAwesome.Sharp.IconButton btnDasboard;
        private FontAwesome.Sharp.IconButton iconButton2;
        private PictureBox pictureBox6;
    }
}


