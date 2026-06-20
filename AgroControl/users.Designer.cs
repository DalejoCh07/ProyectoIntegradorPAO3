namespace AgroControl
{
    partial class users
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(users));
            dgvPlants = new DataGridView();
            label1 = new Label();
            btnDasboard = new FontAwesome.Sharp.IconButton();
            iconButton1 = new FontAwesome.Sharp.IconButton();
            panel1 = new Panel();
            label11 = new Label();
            iconButton2 = new FontAwesome.Sharp.IconButton();
            cmbPlants = new ComboBox();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label5 = new Label();
            iconButton3 = new FontAwesome.Sharp.IconButton();
            textBox3 = new TextBox();
            panel2 = new Panel();
            pictureBox6 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)dgvPlants).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
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
            dgvPlants.Location = new Point(17, 152);
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
            dgvPlants.Size = new Size(464, 394);
            dgvPlants.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(87, 38);
            label1.Name = "label1";
            label1.Size = new Size(168, 28);
            label1.TabIndex = 8;
            label1.Text = "Registered users";
            // 
            // btnDasboard
            // 
            btnDasboard.BackColor = Color.FromArgb(84, 86, 240);
            btnDasboard.FlatAppearance.BorderSize = 0;
            btnDasboard.FlatStyle = FlatStyle.Flat;
            btnDasboard.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDasboard.ForeColor = Color.WhiteSmoke;
            btnDasboard.IconChar = FontAwesome.Sharp.IconChar.PlusSquare;
            btnDasboard.IconColor = Color.WhiteSmoke;
            btnDasboard.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnDasboard.IconSize = 25;
            btnDasboard.ImageAlign = ContentAlignment.MiddleLeft;
            btnDasboard.Location = new Point(498, 89);
            btnDasboard.Margin = new Padding(3, 4, 3, 4);
            btnDasboard.Name = "btnDasboard";
            btnDasboard.Padding = new Padding(11, 0, 0, 0);
            btnDasboard.Size = new Size(143, 43);
            btnDasboard.TabIndex = 9;
            btnDasboard.Text = "New user";
            btnDasboard.TextAlign = ContentAlignment.MiddleLeft;
            btnDasboard.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnDasboard.UseVisualStyleBackColor = false;
            // 
            // iconButton1
            // 
            iconButton1.BackColor = Color.FromArgb(247, 77, 77);
            iconButton1.FlatAppearance.BorderSize = 0;
            iconButton1.FlatStyle = FlatStyle.Flat;
            iconButton1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            iconButton1.ForeColor = Color.WhiteSmoke;
            iconButton1.IconChar = FontAwesome.Sharp.IconChar.MinusCircle;
            iconButton1.IconColor = Color.WhiteSmoke;
            iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton1.IconSize = 25;
            iconButton1.ImageAlign = ContentAlignment.MiddleLeft;
            iconButton1.Location = new Point(657, 89);
            iconButton1.Margin = new Padding(3, 4, 3, 4);
            iconButton1.Name = "iconButton1";
            iconButton1.Padding = new Padding(11, 0, 0, 0);
            iconButton1.Size = new Size(143, 43);
            iconButton1.TabIndex = 10;
            iconButton1.Text = "Delete user";
            iconButton1.TextAlign = ContentAlignment.MiddleLeft;
            iconButton1.TextImageRelation = TextImageRelation.ImageBeforeText;
            iconButton1.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.WhiteSmoke;
            panel1.Controls.Add(label11);
            panel1.Controls.Add(iconButton2);
            panel1.Controls.Add(cmbPlants);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label5);
            panel1.Location = new Point(519, 179);
            panel1.Name = "panel1";
            panel1.Size = new Size(448, 394);
            panel1.TabIndex = 11;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.Location = new Point(28, 28);
            label11.Name = "label11";
            label11.Size = new Size(141, 28);
            label11.TabIndex = 13;
            label11.Text = "Add new user";
            // 
            // iconButton2
            // 
            iconButton2.BackColor = Color.FromArgb(84, 86, 240);
            iconButton2.FlatAppearance.BorderSize = 0;
            iconButton2.FlatStyle = FlatStyle.Flat;
            iconButton2.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            iconButton2.ForeColor = Color.WhiteSmoke;
            iconButton2.IconChar = FontAwesome.Sharp.IconChar.Save;
            iconButton2.IconColor = Color.WhiteSmoke;
            iconButton2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton2.IconSize = 25;
            iconButton2.ImageAlign = ContentAlignment.MiddleLeft;
            iconButton2.Location = new Point(28, 322);
            iconButton2.Margin = new Padding(3, 4, 3, 4);
            iconButton2.Name = "iconButton2";
            iconButton2.Padding = new Padding(11, 0, 0, 0);
            iconButton2.Size = new Size(105, 53);
            iconButton2.TabIndex = 12;
            iconButton2.Text = "Save";
            iconButton2.TextAlign = ContentAlignment.MiddleLeft;
            iconButton2.TextImageRelation = TextImageRelation.ImageBeforeText;
            iconButton2.UseVisualStyleBackColor = false;
            // 
            // cmbPlants
            // 
            cmbPlants.BackColor = Color.WhiteSmoke;
            cmbPlants.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPlants.ForeColor = Color.Black;
            cmbPlants.FormattingEnabled = true;
            cmbPlants.Location = new Point(212, 269);
            cmbPlants.Name = "cmbPlants";
            cmbPlants.Size = new Size(151, 28);
            cmbPlants.TabIndex = 10;
            // 
            // textBox2
            // 
            textBox2.BackColor = Color.WhiteSmoke;
            textBox2.Location = new Point(28, 201);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(386, 27);
            textBox2.TabIndex = 7;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.WhiteSmoke;
            textBox1.Location = new Point(28, 120);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(386, 27);
            textBox1.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(28, 269);
            label3.Name = "label3";
            label3.Size = new Size(44, 23);
            label3.TabIndex = 5;
            label3.Text = "Role";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(28, 162);
            label2.Name = "label2";
            label2.Size = new Size(82, 23);
            label2.TabIndex = 4;
            label2.Text = "Password";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(28, 81);
            label5.Name = "label5";
            label5.Size = new Size(56, 23);
            label5.TabIndex = 3;
            label5.Text = "Name";
            // 
            // iconButton3
            // 
            iconButton3.BackColor = Color.FromArgb(84, 86, 240);
            iconButton3.FlatAppearance.BorderSize = 0;
            iconButton3.FlatStyle = FlatStyle.Flat;
            iconButton3.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            iconButton3.ForeColor = Color.WhiteSmoke;
            iconButton3.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlassArrowRight;
            iconButton3.IconColor = Color.WhiteSmoke;
            iconButton3.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton3.IconSize = 25;
            iconButton3.ImageAlign = ContentAlignment.MiddleLeft;
            iconButton3.Location = new Point(196, 98);
            iconButton3.Margin = new Padding(3, 4, 3, 4);
            iconButton3.Name = "iconButton3";
            iconButton3.Padding = new Padding(11, 0, 0, 0);
            iconButton3.Size = new Size(117, 37);
            iconButton3.TabIndex = 13;
            iconButton3.Text = "Search";
            iconButton3.TextAlign = ContentAlignment.MiddleLeft;
            iconButton3.TextImageRelation = TextImageRelation.ImageBeforeText;
            iconButton3.UseVisualStyleBackColor = false;
            // 
            // textBox3
            // 
            textBox3.BackColor = Color.WhiteSmoke;
            textBox3.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox3.ForeColor = Color.Gray;
            textBox3.Location = new Point(27, 102);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(148, 30);
            textBox3.TabIndex = 12;
            textBox3.Text = "Search user";
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(247, 247, 247);
            panel2.Controls.Add(pictureBox6);
            panel2.Controls.Add(iconButton3);
            panel2.Controls.Add(iconButton1);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(btnDasboard);
            panel2.Controls.Add(textBox3);
            panel2.Controls.Add(dgvPlants);
            panel2.Location = new Point(21, 27);
            panel2.Name = "panel2";
            panel2.Size = new Size(966, 572);
            panel2.TabIndex = 14;
            // 
            // pictureBox6
            // 
            pictureBox6.Image = (Image)resources.GetObject("pictureBox6.Image");
            pictureBox6.Location = new Point(27, 22);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(54, 55);
            pictureBox6.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox6.TabIndex = 15;
            pictureBox6.TabStop = false;
            // 
            // users
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(999, 620);
            Controls.Add(panel1);
            Controls.Add(panel2);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "users";
            Text = "settings";
            Load += settings_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPlants).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvPlants;
        private Label label1;
        private FontAwesome.Sharp.IconButton btnDasboard;
        private FontAwesome.Sharp.IconButton iconButton1;
        private Panel panel1;
        private TextBox textBox2;
        private TextBox textBox1;
        private Label label3;
        private Label label2;
        private Label label5;
        private FontAwesome.Sharp.IconButton iconButton2;
        private ComboBox cmbPlants;
        private Label label11;
        private FontAwesome.Sharp.IconButton iconButton3;
        private TextBox textBox3;
        private Panel panel2;
        private PictureBox pictureBox6;
    }
}