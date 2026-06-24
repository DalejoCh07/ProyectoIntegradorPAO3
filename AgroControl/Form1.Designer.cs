namespace AgroControl
{
    partial class Form1
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
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            cmbGreenhouse = new ComboBox();
            panel1 = new Panel();
            panel3 = new Panel();
            button1 = new FontAwesome.Sharp.IconButton();
            pictureBox2 = new PictureBox();
            label2 = new Label();
            label1 = new Label();
            label20 = new Label();
            label28 = new Label();
            label3 = new Label();
            panel2 = new Panel();
            pictureBox1 = new PictureBox();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(23, 134);
            textBox1.Margin = new Padding(3, 4, 3, 4);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(326, 27);
            textBox1.TabIndex = 3;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(23, 219);
            textBox2.Margin = new Padding(3, 4, 3, 4);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(326, 27);
            textBox2.TabIndex = 4;
            // 
            // cmbGreenhouse
            // 
            cmbGreenhouse.BackColor = Color.WhiteSmoke;
            cmbGreenhouse.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGreenhouse.ForeColor = Color.Black;
            cmbGreenhouse.FormattingEnabled = true;
            cmbGreenhouse.Location = new Point(23, 306);
            cmbGreenhouse.Name = "cmbGreenhouse";
            cmbGreenhouse.Size = new Size(326, 28);
            cmbGreenhouse.TabIndex = 11;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Control;
            panel1.Controls.Add(panel3);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(265, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(409, 473);
            panel1.TabIndex = 13;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(247, 247, 247);
            panel3.Controls.Add(button1);
            panel3.Controls.Add(pictureBox2);
            panel3.Controls.Add(cmbGreenhouse);
            panel3.Controls.Add(textBox2);
            panel3.Controls.Add(textBox1);
            panel3.Controls.Add(label2);
            panel3.Controls.Add(label1);
            panel3.Controls.Add(label20);
            panel3.Controls.Add(label28);
            panel3.Controls.Add(label3);
            panel3.Location = new Point(15, 20);
            panel3.Name = "panel3";
            panel3.Size = new Size(379, 441);
            panel3.TabIndex = 13;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(84, 86, 240);
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.WhiteSmoke;
            button1.IconChar = FontAwesome.Sharp.IconChar.Save;
            button1.IconColor = Color.WhiteSmoke;
            button1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            button1.IconSize = 25;
            button1.ImageAlign = ContentAlignment.MiddleLeft;
            button1.Location = new Point(136, 356);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Padding = new Padding(11, 0, 0, 0);
            button1.Size = new Size(105, 40);
            button1.TabIndex = 28;
            button1.Text = "Log in";
            button1.TextAlign = ContentAlignment.MiddleLeft;
            button1.TextImageRelation = TextImageRelation.ImageBeforeText;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.Screenshot_2026_06_22_143714;
            pictureBox2.Location = new Point(14, 12);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(83, 69);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 27;
            pictureBox2.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(23, 270);
            label2.Name = "label2";
            label2.Size = new Size(102, 23);
            label2.TabIndex = 26;
            label2.Text = "Greenhouse";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(23, 182);
            label1.Name = "label1";
            label1.Size = new Size(86, 23);
            label1.TabIndex = 25;
            label1.Text = "Password:";
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label20.Location = new Point(23, 98);
            label20.Name = "label20";
            label20.Size = new Size(49, 23);
            label20.TabIndex = 24;
            label20.Text = "User:";
            // 
            // label28
            // 
            label28.AutoSize = true;
            label28.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label28.ForeColor = Color.Gray;
            label28.Location = new Point(92, 54);
            label28.Name = "label28";
            label28.Size = new Size(270, 23);
            label28.TabIndex = 17;
            label28.Text = "Enter your credentials to continue";
            // 
            // label3
            // 
            label3.Font = new Font("Bahnschrift SemiBold", 16F, FontStyle.Bold);
            label3.Location = new Point(92, 21);
            label3.Name = "label3";
            label3.Size = new Size(201, 42);
            label3.TabIndex = 14;
            label3.Text = "Login!";
            // 
            // panel2
            // 
            panel2.Controls.Add(pictureBox1);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(265, 473);
            panel2.TabIndex = 14;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = Properties.Resources.Screenshot_2026_06_22_130902;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(265, 473);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(674, 473);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            Click += button1_Click;
            panel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private TextBox textBox1;
        private TextBox textBox2;
        private ComboBox cmbGreenhouse;
        private Panel panel1;
        private Panel panel3;
        private Panel panel2;
        private PictureBox pictureBox1;
        private Label label3;
        private Label label28;
        private Label label2;
        private Label label1;
        private Label label20;
        private PictureBox pictureBox2;
        private FontAwesome.Sharp.IconButton button1;
    }
}

