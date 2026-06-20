namespace AgroControl
{
    partial class dashboard
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
            panel3 = new Panel();
            pictureBox1 = new PictureBox();
            label15 = new Label();
            label7 = new Label();
            label6 = new Label();
            label1 = new Label();
            label5 = new Label();
            panel5 = new Panel();
            panel1 = new Panel();
            panel2 = new Panel();
            pictureBox2 = new PictureBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label8 = new Label();
            panel4 = new Panel();
            panel6 = new Panel();
            pictureBox3 = new PictureBox();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            panel7 = new Panel();
            panel8 = new Panel();
            pictureBox4 = new PictureBox();
            label13 = new Label();
            label14 = new Label();
            label16 = new Label();
            label17 = new Label();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            panel9 = new Panel();
            panel13 = new Panel();
            label25 = new Label();
            label22 = new Label();
            iconButton4 = new FontAwesome.Sharp.IconButton();
            panel14 = new Panel();
            label24 = new Label();
            label20 = new Label();
            iconButton5 = new FontAwesome.Sharp.IconButton();
            panel12 = new Panel();
            label23 = new Label();
            label19 = new Label();
            iconButton2 = new FontAwesome.Sharp.IconButton();
            label18 = new Label();
            panel10 = new Panel();
            panel11 = new Panel();
            iconButton1 = new FontAwesome.Sharp.IconButton();
            label26 = new Label();
            label21 = new Label();
            iconButton3 = new FontAwesome.Sharp.IconButton();
            label27 = new Label();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel5.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel4.SuspendLayout();
            panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            panel7.SuspendLayout();
            panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            panel9.SuspendLayout();
            panel13.SuspendLayout();
            panel14.SuspendLayout();
            panel12.SuspendLayout();
            panel10.SuspendLayout();
            panel11.SuspendLayout();
            SuspendLayout();
            // 
            // panel3
            // 
            panel3.BackColor = Color.WhiteSmoke;
            panel3.BackgroundImageLayout = ImageLayout.None;
            panel3.Controls.Add(pictureBox1);
            panel3.Controls.Add(label15);
            panel3.Controls.Add(label7);
            panel3.Controls.Add(label6);
            panel3.Controls.Add(label1);
            panel3.Location = new Point(3, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(224, 145);
            panel3.TabIndex = 1;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.soil;
            pictureBox1.Location = new Point(12, 16);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(60, 72);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 10;
            pictureBox1.TabStop = false;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label15.Location = new Point(70, 104);
            label15.Name = "label15";
            label15.Size = new Size(46, 20);
            label15.TabIndex = 7;
            label15.Text = "value";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(12, 104);
            label7.Name = "label7";
            label7.Size = new Size(52, 20);
            label7.TabIndex = 6;
            label7.Text = "Status:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(78, 50);
            label6.Name = "label6";
            label6.Size = new Size(87, 38);
            label6.TabIndex = 4;
            label6.Text = "value";
            label6.Click += label6_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(78, 13);
            label1.Name = "label1";
            label1.Size = new Size(132, 23);
            label1.TabIndex = 2;
            label1.Text = "SOIL HUMIDITY";
            label1.Click += label1_Click_1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Bahnschrift SemiBold", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(10, 22);
            label5.Name = "label5";
            label5.Size = new Size(230, 34);
            label5.TabIndex = 3;
            label5.Text = "Live Sensor Data";
            label5.Click += label5_Click;
            // 
            // panel5
            // 
            panel5.BackColor = Color.Olive;
            panel5.BackgroundImageLayout = ImageLayout.None;
            panel5.Controls.Add(panel3);
            panel5.Location = new Point(13, 73);
            panel5.Name = "panel5";
            panel5.Size = new Size(230, 151);
            panel5.TabIndex = 8;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Turquoise;
            panel1.BackgroundImageLayout = ImageLayout.None;
            panel1.Controls.Add(panel2);
            panel1.Location = new Point(262, 75);
            panel1.Name = "panel1";
            panel1.Size = new Size(230, 151);
            panel1.TabIndex = 9;
            // 
            // panel2
            // 
            panel2.BackColor = Color.WhiteSmoke;
            panel2.BackgroundImageLayout = ImageLayout.None;
            panel2.Controls.Add(pictureBox2);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label8);
            panel2.Location = new Point(3, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(224, 145);
            panel2.TabIndex = 1;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.humidity;
            pictureBox2.Location = new Point(12, 14);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(60, 72);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 10;
            pictureBox2.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(70, 104);
            label2.Name = "label2";
            label2.Size = new Size(46, 20);
            label2.TabIndex = 7;
            label2.Text = "value";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 104);
            label3.Name = "label3";
            label3.Size = new Size(52, 20);
            label3.TabIndex = 6;
            label3.Text = "Status:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(78, 48);
            label4.Name = "label4";
            label4.Size = new Size(87, 38);
            label4.TabIndex = 4;
            label4.Text = "value";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(78, 13);
            label8.Name = "label8";
            label8.Size = new Size(124, 23);
            label8.TabIndex = 2;
            label8.Text = "AIR HUMIDITY";
            label8.Click += label8_Click;
            // 
            // panel4
            // 
            panel4.BackColor = Color.SkyBlue;
            panel4.BackgroundImageLayout = ImageLayout.None;
            panel4.Controls.Add(panel6);
            panel4.Location = new Point(509, 76);
            panel4.Name = "panel4";
            panel4.Size = new Size(230, 151);
            panel4.TabIndex = 9;
            // 
            // panel6
            // 
            panel6.BackColor = Color.WhiteSmoke;
            panel6.BackgroundImageLayout = ImageLayout.None;
            panel6.Controls.Add(pictureBox3);
            panel6.Controls.Add(label9);
            panel6.Controls.Add(label10);
            panel6.Controls.Add(label11);
            panel6.Controls.Add(label12);
            panel6.Location = new Point(3, 3);
            panel6.Name = "panel6";
            panel6.Size = new Size(224, 145);
            panel6.TabIndex = 1;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.air;
            pictureBox3.Location = new Point(12, 13);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(60, 74);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 11;
            pictureBox3.TabStop = false;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(70, 104);
            label9.Name = "label9";
            label9.Size = new Size(46, 20);
            label9.TabIndex = 7;
            label9.Text = "value";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(12, 104);
            label10.Name = "label10";
            label10.Size = new Size(52, 20);
            label10.TabIndex = 6;
            label10.Text = "Status:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.Location = new Point(78, 47);
            label11.Name = "label11";
            label11.Size = new Size(87, 38);
            label11.TabIndex = 4;
            label11.Text = "value";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.Location = new Point(82, 13);
            label12.Name = "label12";
            label12.Size = new Size(137, 20);
            label12.TabIndex = 2;
            label12.Text = "AIR TEMPERATURE";
            // 
            // panel7
            // 
            panel7.BackColor = Color.Gold;
            panel7.BackgroundImageLayout = ImageLayout.None;
            panel7.Controls.Add(panel8);
            panel7.Location = new Point(757, 76);
            panel7.Name = "panel7";
            panel7.Size = new Size(230, 151);
            panel7.TabIndex = 9;
            // 
            // panel8
            // 
            panel8.BackColor = Color.WhiteSmoke;
            panel8.BackgroundImageLayout = ImageLayout.None;
            panel8.Controls.Add(pictureBox4);
            panel8.Controls.Add(label13);
            panel8.Controls.Add(label14);
            panel8.Controls.Add(label16);
            panel8.Controls.Add(label17);
            panel8.Location = new Point(3, 3);
            panel8.Name = "panel8";
            panel8.Size = new Size(224, 145);
            panel8.TabIndex = 1;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = Properties.Resources.sun;
            pictureBox4.Location = new Point(12, 13);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(60, 75);
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox4.TabIndex = 12;
            pictureBox4.TabStop = false;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label13.Location = new Point(70, 104);
            label13.Name = "label13";
            label13.Size = new Size(46, 20);
            label13.TabIndex = 7;
            label13.Text = "value";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(12, 104);
            label14.Name = "label14";
            label14.Size = new Size(52, 20);
            label14.TabIndex = 6;
            label14.Text = "Status:";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label16.Location = new Point(78, 47);
            label16.Name = "label16";
            label16.Size = new Size(87, 38);
            label16.TabIndex = 4;
            label16.Text = "value";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label17.Location = new Point(78, 13);
            label17.Name = "label17";
            label17.Size = new Size(144, 23);
            label17.TabIndex = 2;
            label17.Text = "LIGHT INTENSITY";
            // 
            // panel9
            // 
            panel9.BackColor = Color.WhiteSmoke;
            panel9.Controls.Add(panel13);
            panel9.Controls.Add(panel14);
            panel9.Controls.Add(panel12);
            panel9.Controls.Add(label18);
            panel9.Controls.Add(panel10);
            panel9.ImeMode = ImeMode.Hiragana;
            panel9.Location = new Point(752, 258);
            panel9.Name = "panel9";
            panel9.Size = new Size(235, 309);
            panel9.TabIndex = 11;
            // 
            // panel13
            // 
            panel13.Controls.Add(label25);
            panel13.Controls.Add(label22);
            panel13.Controls.Add(iconButton4);
            panel13.Dock = DockStyle.Bottom;
            panel13.Location = new Point(0, 49);
            panel13.Name = "panel13";
            panel13.Size = new Size(235, 65);
            panel13.TabIndex = 25;
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label25.Location = new Point(15, 31);
            label25.Name = "label25";
            label25.Size = new Size(28, 20);
            label25.TabIndex = 24;
            label25.Text = "off";
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label22.Location = new Point(15, 8);
            label22.Name = "label22";
            label22.Size = new Size(130, 23);
            label22.TabIndex = 24;
            label22.Text = "Irrigation Pump";
            // 
            // iconButton4
            // 
            iconButton4.BackColor = Color.WhiteSmoke;
            iconButton4.FlatAppearance.BorderSize = 0;
            iconButton4.FlatStyle = FlatStyle.Flat;
            iconButton4.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            iconButton4.ForeColor = Color.WhiteSmoke;
            iconButton4.IconChar = FontAwesome.Sharp.IconChar.PowerOff;
            iconButton4.IconColor = Color.Black;
            iconButton4.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton4.IconSize = 25;
            iconButton4.ImageAlign = ContentAlignment.MiddleLeft;
            iconButton4.Location = new Point(156, 8);
            iconButton4.Margin = new Padding(3, 4, 3, 4);
            iconButton4.Name = "iconButton4";
            iconButton4.Padding = new Padding(11, 0, 0, 0);
            iconButton4.Size = new Size(59, 47);
            iconButton4.TabIndex = 18;
            iconButton4.TextAlign = ContentAlignment.MiddleLeft;
            iconButton4.UseVisualStyleBackColor = false;
            // 
            // panel14
            // 
            panel14.Controls.Add(label24);
            panel14.Controls.Add(label20);
            panel14.Controls.Add(iconButton5);
            panel14.Dock = DockStyle.Bottom;
            panel14.Location = new Point(0, 114);
            panel14.Name = "panel14";
            panel14.Size = new Size(235, 65);
            panel14.TabIndex = 25;
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label24.Location = new Point(15, 31);
            label24.Name = "label24";
            label24.Size = new Size(28, 20);
            label24.TabIndex = 23;
            label24.Text = "off";
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label20.Location = new Point(15, 8);
            label20.Name = "label20";
            label20.Size = new Size(135, 23);
            label20.TabIndex = 23;
            label20.Text = "Ventilation Farm";
            // 
            // iconButton5
            // 
            iconButton5.BackColor = Color.WhiteSmoke;
            iconButton5.FlatAppearance.BorderSize = 0;
            iconButton5.FlatStyle = FlatStyle.Flat;
            iconButton5.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            iconButton5.ForeColor = Color.WhiteSmoke;
            iconButton5.IconChar = FontAwesome.Sharp.IconChar.PowerOff;
            iconButton5.IconColor = Color.Black;
            iconButton5.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton5.IconSize = 25;
            iconButton5.ImageAlign = ContentAlignment.MiddleLeft;
            iconButton5.Location = new Point(156, 8);
            iconButton5.Margin = new Padding(3, 4, 3, 4);
            iconButton5.Name = "iconButton5";
            iconButton5.Padding = new Padding(11, 0, 0, 0);
            iconButton5.Size = new Size(59, 47);
            iconButton5.TabIndex = 18;
            iconButton5.TextAlign = ContentAlignment.MiddleLeft;
            iconButton5.UseVisualStyleBackColor = false;
            // 
            // panel12
            // 
            panel12.Controls.Add(label23);
            panel12.Controls.Add(label19);
            panel12.Controls.Add(iconButton2);
            panel12.Dock = DockStyle.Bottom;
            panel12.Location = new Point(0, 179);
            panel12.Name = "panel12";
            panel12.Size = new Size(235, 65);
            panel12.TabIndex = 24;
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label23.Location = new Point(15, 31);
            label23.Name = "label23";
            label23.Size = new Size(28, 20);
            label23.TabIndex = 22;
            label23.Text = "off";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label19.Location = new Point(15, 8);
            label19.Name = "label19";
            label19.Size = new Size(70, 23);
            label19.TabIndex = 22;
            label19.Text = "Diffuser";
            // 
            // iconButton2
            // 
            iconButton2.BackColor = Color.WhiteSmoke;
            iconButton2.FlatAppearance.BorderSize = 0;
            iconButton2.FlatStyle = FlatStyle.Flat;
            iconButton2.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            iconButton2.ForeColor = Color.WhiteSmoke;
            iconButton2.IconChar = FontAwesome.Sharp.IconChar.PowerOff;
            iconButton2.IconColor = Color.Black;
            iconButton2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton2.IconSize = 25;
            iconButton2.ImageAlign = ContentAlignment.MiddleLeft;
            iconButton2.Location = new Point(156, 8);
            iconButton2.Margin = new Padding(3, 4, 3, 4);
            iconButton2.Name = "iconButton2";
            iconButton2.Padding = new Padding(11, 0, 0, 0);
            iconButton2.Size = new Size(59, 47);
            iconButton2.TabIndex = 18;
            iconButton2.TextAlign = ContentAlignment.MiddleLeft;
            iconButton2.UseVisualStyleBackColor = false;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label18.Location = new Point(5, 11);
            label18.Name = "label18";
            label18.Size = new Size(175, 25);
            label18.TabIndex = 0;
            label18.Text = "ACTIVE CONTROLS";
            // 
            // panel10
            // 
            panel10.Controls.Add(panel11);
            panel10.Controls.Add(iconButton3);
            panel10.Dock = DockStyle.Bottom;
            panel10.Location = new Point(0, 244);
            panel10.Name = "panel10";
            panel10.Size = new Size(235, 65);
            panel10.TabIndex = 22;
            // 
            // panel11
            // 
            panel11.Controls.Add(iconButton1);
            panel11.Controls.Add(label26);
            panel11.Controls.Add(label21);
            panel11.Dock = DockStyle.Bottom;
            panel11.Location = new Point(0, 0);
            panel11.Name = "panel11";
            panel11.Size = new Size(235, 65);
            panel11.TabIndex = 23;
            // 
            // iconButton1
            // 
            iconButton1.BackColor = Color.WhiteSmoke;
            iconButton1.FlatAppearance.BorderSize = 0;
            iconButton1.FlatStyle = FlatStyle.Flat;
            iconButton1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            iconButton1.ForeColor = Color.WhiteSmoke;
            iconButton1.IconChar = FontAwesome.Sharp.IconChar.PowerOff;
            iconButton1.IconColor = Color.Black;
            iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton1.IconSize = 25;
            iconButton1.ImageAlign = ContentAlignment.MiddleLeft;
            iconButton1.Location = new Point(156, 8);
            iconButton1.Margin = new Padding(3, 4, 3, 4);
            iconButton1.Name = "iconButton1";
            iconButton1.Padding = new Padding(11, 0, 0, 0);
            iconButton1.Size = new Size(59, 47);
            iconButton1.TabIndex = 18;
            iconButton1.TextAlign = ContentAlignment.MiddleLeft;
            iconButton1.UseVisualStyleBackColor = false;
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label26.Location = new Point(15, 35);
            label26.Name = "label26";
            label26.Size = new Size(28, 20);
            label26.TabIndex = 21;
            label26.Text = "off";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label21.Location = new Point(15, 12);
            label21.Name = "label21";
            label21.Size = new Size(101, 23);
            label21.TabIndex = 13;
            label21.Text = "Grow Lights";
            // 
            // iconButton3
            // 
            iconButton3.BackColor = Color.WhiteSmoke;
            iconButton3.FlatAppearance.BorderSize = 0;
            iconButton3.FlatStyle = FlatStyle.Flat;
            iconButton3.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            iconButton3.ForeColor = Color.WhiteSmoke;
            iconButton3.IconChar = FontAwesome.Sharp.IconChar.PowerOff;
            iconButton3.IconColor = Color.Black;
            iconButton3.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton3.IconSize = 25;
            iconButton3.ImageAlign = ContentAlignment.MiddleLeft;
            iconButton3.Location = new Point(156, 8);
            iconButton3.Margin = new Padding(3, 4, 3, 4);
            iconButton3.Name = "iconButton3";
            iconButton3.Padding = new Padding(11, 0, 0, 0);
            iconButton3.Size = new Size(59, 47);
            iconButton3.TabIndex = 18;
            iconButton3.TextAlign = ContentAlignment.MiddleLeft;
            iconButton3.UseVisualStyleBackColor = false;
            // 
            // label27
            // 
            label27.AutoSize = true;
            label27.Font = new Font("Bahnschrift SemiBold", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label27.Location = new Point(16, 246);
            label27.Name = "label27";
            label27.Size = new Size(196, 34);
            label27.TabIndex = 13;
            label27.Text = "Data Analytics";
            // 
            // dashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(999, 620);
            Controls.Add(label27);
            Controls.Add(panel9);
            Controls.Add(panel4);
            Controls.Add(panel1);
            Controls.Add(panel7);
            Controls.Add(label5);
            Controls.Add(panel5);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "dashboard";
            Text = "dashboard";
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel5.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel4.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            panel7.ResumeLayout(false);
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            panel9.ResumeLayout(false);
            panel9.PerformLayout();
            panel13.ResumeLayout(false);
            panel13.PerformLayout();
            panel14.ResumeLayout(false);
            panel14.PerformLayout();
            panel12.ResumeLayout(false);
            panel12.PerformLayout();
            panel10.ResumeLayout(false);
            panel11.ResumeLayout(false);
            panel11.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel panel3;
        private Label label1;
        private Label label5;
        private Label label6;
        private Label label15;
        private Label label7;
        private Panel panel5;
        private Panel panel1;
        private Panel panel2;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label8;
        private Panel panel4;
        private Panel panel6;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private Panel panel7;
        private Panel panel8;
        private Label label13;
        private Label label14;
        private Label label16;
        private Label label17;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private PictureBox pictureBox4;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Panel panel9;
        private Label label21;
        private Label label18;
        private FontAwesome.Sharp.IconButton iconButton3;
        private Label label26;
        private Panel panel14;
        private FontAwesome.Sharp.IconButton iconButton5;
        private Panel panel12;
        private FontAwesome.Sharp.IconButton iconButton2;
        private Panel panel10;
        private Panel panel11;
        private FontAwesome.Sharp.IconButton iconButton1;
        private Panel panel13;
        private FontAwesome.Sharp.IconButton iconButton4;
        private Label label25;
        private Label label22;
        private Label label24;
        private Label label20;
        private Label label23;
        private Label label19;
        private Label label27;
    }
}