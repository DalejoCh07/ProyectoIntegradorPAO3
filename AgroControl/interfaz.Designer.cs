namespace AgroControl
{
    partial class Interfaz
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Interfaz));
            iconDropDownButton1 = new FontAwesome.Sharp.IconDropDownButton();
            panelMenu = new Panel();
            iconButton8 = new FontAwesome.Sharp.IconButton();
            btnSettings = new FontAwesome.Sharp.IconButton();
            btnPlantRecords = new FontAwesome.Sharp.IconButton();
            btnCharts = new FontAwesome.Sharp.IconButton();
            btnReadingLog = new FontAwesome.Sharp.IconButton();
            btnDasboard = new FontAwesome.Sharp.IconButton();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            panelTitleBar = new Panel();
            label2 = new Label();
            label1 = new Label();
            panelDesktop = new Panel();
            panelMenu.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panelTitleBar.SuspendLayout();
            SuspendLayout();
            // 
            // iconDropDownButton1
            // 
            iconDropDownButton1.IconChar = FontAwesome.Sharp.IconChar.None;
            iconDropDownButton1.IconColor = Color.Black;
            iconDropDownButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconDropDownButton1.Name = "iconDropDownButton1";
            iconDropDownButton1.Size = new Size(23, 23);
            iconDropDownButton1.Text = "iconDropDownButton1";
            // 
            // panelMenu
            // 
            panelMenu.BackColor = Color.FromArgb(84, 86, 240);
            panelMenu.Controls.Add(iconButton8);
            panelMenu.Controls.Add(btnSettings);
            panelMenu.Controls.Add(btnPlantRecords);
            panelMenu.Controls.Add(btnCharts);
            panelMenu.Controls.Add(btnReadingLog);
            panelMenu.Controls.Add(btnDasboard);
            panelMenu.Controls.Add(panel1);
            panelMenu.Dock = DockStyle.Left;
            panelMenu.Location = new Point(0, 0);
            panelMenu.Margin = new Padding(3, 4, 3, 4);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(263, 673);
            panelMenu.TabIndex = 0;
            // 
            // iconButton8
            // 
            iconButton8.Dock = DockStyle.Bottom;
            iconButton8.FlatAppearance.BorderSize = 0;
            iconButton8.FlatStyle = FlatStyle.Flat;
            iconButton8.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            iconButton8.ForeColor = Color.WhiteSmoke;
            iconButton8.IconChar = FontAwesome.Sharp.IconChar.CircleInfo;
            iconButton8.IconColor = Color.WhiteSmoke;
            iconButton8.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton8.IconSize = 25;
            iconButton8.ImageAlign = ContentAlignment.MiddleLeft;
            iconButton8.Location = new Point(0, 620);
            iconButton8.Margin = new Padding(3, 4, 3, 4);
            iconButton8.Name = "iconButton8";
            iconButton8.Padding = new Padding(11, 0, 0, 0);
            iconButton8.Size = new Size(263, 53);
            iconButton8.TabIndex = 7;
            iconButton8.Text = "Help";
            iconButton8.TextAlign = ContentAlignment.MiddleLeft;
            iconButton8.TextImageRelation = TextImageRelation.ImageBeforeText;
            iconButton8.UseVisualStyleBackColor = true;
            // 
            // btnSettings
            // 
            btnSettings.Dock = DockStyle.Top;
            btnSettings.FlatAppearance.BorderSize = 0;
            btnSettings.FlatStyle = FlatStyle.Flat;
            btnSettings.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSettings.ForeColor = Color.WhiteSmoke;
            btnSettings.IconChar = FontAwesome.Sharp.IconChar.Key;
            btnSettings.IconColor = Color.WhiteSmoke;
            btnSettings.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnSettings.IconSize = 25;
            btnSettings.ImageAlign = ContentAlignment.MiddleLeft;
            btnSettings.Location = new Point(0, 345);
            btnSettings.Margin = new Padding(3, 4, 3, 4);
            btnSettings.Name = "btnSettings";
            btnSettings.Padding = new Padding(11, 0, 0, 0);
            btnSettings.Size = new Size(263, 53);
            btnSettings.TabIndex = 5;
            btnSettings.Text = "Settings";
            btnSettings.TextAlign = ContentAlignment.MiddleLeft;
            btnSettings.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSettings.UseVisualStyleBackColor = true;
            btnSettings.Click += btnSettings_Click;
            // 
            // btnPlantRecords
            // 
            btnPlantRecords.Dock = DockStyle.Top;
            btnPlantRecords.FlatAppearance.BorderSize = 0;
            btnPlantRecords.FlatStyle = FlatStyle.Flat;
            btnPlantRecords.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPlantRecords.ForeColor = Color.WhiteSmoke;
            btnPlantRecords.IconChar = FontAwesome.Sharp.IconChar.PlantWilt;
            btnPlantRecords.IconColor = Color.WhiteSmoke;
            btnPlantRecords.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnPlantRecords.IconSize = 25;
            btnPlantRecords.ImageAlign = ContentAlignment.MiddleLeft;
            btnPlantRecords.Location = new Point(0, 292);
            btnPlantRecords.Margin = new Padding(3, 4, 3, 4);
            btnPlantRecords.Name = "btnPlantRecords";
            btnPlantRecords.Padding = new Padding(11, 0, 0, 0);
            btnPlantRecords.Size = new Size(263, 53);
            btnPlantRecords.TabIndex = 4;
            btnPlantRecords.Text = "Plant Records";
            btnPlantRecords.TextAlign = ContentAlignment.MiddleLeft;
            btnPlantRecords.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnPlantRecords.UseVisualStyleBackColor = true;
            btnPlantRecords.Click += btnPlantRecords_Click;
            // 
            // btnCharts
            // 
            btnCharts.Dock = DockStyle.Top;
            btnCharts.FlatAppearance.BorderSize = 0;
            btnCharts.FlatStyle = FlatStyle.Flat;
            btnCharts.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCharts.ForeColor = Color.WhiteSmoke;
            btnCharts.IconChar = FontAwesome.Sharp.IconChar.ChartColumn;
            btnCharts.IconColor = Color.WhiteSmoke;
            btnCharts.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnCharts.IconSize = 25;
            btnCharts.ImageAlign = ContentAlignment.MiddleLeft;
            btnCharts.Location = new Point(0, 239);
            btnCharts.Margin = new Padding(3, 4, 3, 4);
            btnCharts.Name = "btnCharts";
            btnCharts.Padding = new Padding(11, 0, 0, 0);
            btnCharts.Size = new Size(263, 53);
            btnCharts.TabIndex = 3;
            btnCharts.Text = "Charts";
            btnCharts.TextAlign = ContentAlignment.MiddleLeft;
            btnCharts.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCharts.UseVisualStyleBackColor = true;
            btnCharts.Click += btnCharts_Click;
            // 
            // btnReadingLog
            // 
            btnReadingLog.Dock = DockStyle.Top;
            btnReadingLog.FlatAppearance.BorderSize = 0;
            btnReadingLog.FlatStyle = FlatStyle.Flat;
            btnReadingLog.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnReadingLog.ForeColor = Color.WhiteSmoke;
            btnReadingLog.IconChar = FontAwesome.Sharp.IconChar.Book;
            btnReadingLog.IconColor = Color.WhiteSmoke;
            btnReadingLog.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnReadingLog.IconSize = 25;
            btnReadingLog.ImageAlign = ContentAlignment.MiddleLeft;
            btnReadingLog.Location = new Point(0, 186);
            btnReadingLog.Margin = new Padding(3, 4, 3, 4);
            btnReadingLog.Name = "btnReadingLog";
            btnReadingLog.Padding = new Padding(11, 0, 0, 0);
            btnReadingLog.Size = new Size(263, 53);
            btnReadingLog.TabIndex = 2;
            btnReadingLog.Text = "Reading Log";
            btnReadingLog.TextAlign = ContentAlignment.MiddleLeft;
            btnReadingLog.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnReadingLog.UseVisualStyleBackColor = true;
            btnReadingLog.Click += btnReadingLog_Click;
            // 
            // btnDasboard
            // 
            btnDasboard.BackColor = Color.FromArgb(84, 86, 240);
            btnDasboard.Dock = DockStyle.Top;
            btnDasboard.FlatAppearance.BorderSize = 0;
            btnDasboard.FlatStyle = FlatStyle.Flat;
            btnDasboard.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDasboard.ForeColor = Color.WhiteSmoke;
            btnDasboard.IconChar = FontAwesome.Sharp.IconChar.House;
            btnDasboard.IconColor = Color.WhiteSmoke;
            btnDasboard.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnDasboard.IconSize = 25;
            btnDasboard.ImageAlign = ContentAlignment.MiddleLeft;
            btnDasboard.Location = new Point(0, 133);
            btnDasboard.Margin = new Padding(3, 4, 3, 4);
            btnDasboard.Name = "btnDasboard";
            btnDasboard.Padding = new Padding(11, 0, 0, 0);
            btnDasboard.Size = new Size(263, 53);
            btnDasboard.TabIndex = 1;
            btnDasboard.Text = "Dashboard";
            btnDasboard.TextAlign = ContentAlignment.MiddleLeft;
            btnDasboard.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnDasboard.UseVisualStyleBackColor = false;
            btnDasboard.Click += btnDasboard_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(84, 86, 240);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(263, 133);
            panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.WhiteSmoke;
            pictureBox1.BackgroundImageLayout = ImageLayout.None;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Margin = new Padding(3, 4, 3, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(260, 130);
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click_1;
            // 
            // panelTitleBar
            // 
            panelTitleBar.Controls.Add(label2);
            panelTitleBar.Controls.Add(label1);
            panelTitleBar.Dock = DockStyle.Top;
            panelTitleBar.Location = new Point(263, 0);
            panelTitleBar.Margin = new Padding(3, 4, 3, 4);
            panelTitleBar.Name = "panelTitleBar";
            panelTitleBar.Size = new Size(999, 53);
            panelTitleBar.TabIndex = 1;
            panelTitleBar.Paint += panelTitleBar_Paint;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.Font = new Font("Bahnschrift SemiBold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(837, 12);
            label2.Name = "label2";
            label2.Size = new Size(159, 32);
            label2.TabIndex = 6;
            label2.Text = "USER";
            label2.Click += label2_Click;
            // 
            // label1
            // 
            label1.Font = new Font("Bahnschrift SemiBold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(15, 12);
            label1.Name = "label1";
            label1.Size = new Size(341, 29);
            label1.TabIndex = 5;
            label1.Text = "WELCOME BACK!";
            label1.Click += label1_Click;
            // 
            // panelDesktop
            // 
            panelDesktop.BackColor = Color.WhiteSmoke;
            panelDesktop.Dock = DockStyle.Fill;
            panelDesktop.Location = new Point(263, 53);
            panelDesktop.Margin = new Padding(3, 4, 3, 4);
            panelDesktop.Name = "panelDesktop";
            panelDesktop.Size = new Size(999, 620);
            panelDesktop.TabIndex = 2;
            // 
            // Interfaz
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1262, 673);
            Controls.Add(panelDesktop);
            Controls.Add(panelTitleBar);
            Controls.Add(panelMenu);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Interfaz";
            Text = "interfaz";
            TransparencyKey = Color.White;
            Load += Interfaz_Load;
            panelMenu.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panelTitleBar.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private FontAwesome.Sharp.IconDropDownButton iconDropDownButton1;
        private Panel panelMenu;
        private Panel panelTitleBar;
        private Panel panelDesktop;
        private Panel panel1;
        private PictureBox pictureBox1;
        private FontAwesome.Sharp.IconButton btnDasboard;
        private FontAwesome.Sharp.IconButton btnSettings;
        private FontAwesome.Sharp.IconButton btnPlantRecords;
        private FontAwesome.Sharp.IconButton btnCharts;
        private FontAwesome.Sharp.IconButton btnReadingLog;
        private FontAwesome.Sharp.IconButton iconButton8;
        private Label label1;
        private Label label2;
    }
}