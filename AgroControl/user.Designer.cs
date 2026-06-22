namespace AgroControl
{
    partial class user
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
            pictureBox1 = new PictureBox();
            panel1 = new Panel();
            btnLogOut = new FontAwesome.Sharp.IconButton();
            btnManage = new FontAwesome.Sharp.IconButton();
            lblUser = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.user;
            pictureBox1.Location = new Point(30, 43);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(77, 79);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(247, 247, 247);
            panel1.Controls.Add(btnLogOut);
            panel1.Controls.Add(btnManage);
            panel1.Controls.Add(lblUser);
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(28, 23);
            panel1.Name = "panel1";
            panel1.Size = new Size(581, 172);
            panel1.TabIndex = 1;
            // 
            // btnLogOut
            // 
            btnLogOut.BackColor = Color.FromArgb(247, 77, 77);
            btnLogOut.FlatAppearance.BorderSize = 0;
            btnLogOut.FlatStyle = FlatStyle.Flat;
            btnLogOut.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogOut.ForeColor = Color.WhiteSmoke;
            btnLogOut.IconChar = FontAwesome.Sharp.IconChar.Close;
            btnLogOut.IconColor = Color.WhiteSmoke;
            btnLogOut.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnLogOut.IconSize = 25;
            btnLogOut.ImageAlign = ContentAlignment.MiddleLeft;
            btnLogOut.Location = new Point(361, 34);
            btnLogOut.Margin = new Padding(3, 4, 3, 4);
            btnLogOut.Name = "btnLogOut";
            btnLogOut.Padding = new Padding(11, 0, 0, 0);
            btnLogOut.Size = new Size(166, 36);
            btnLogOut.TabIndex = 32;
            btnLogOut.Text = "Log out";
            btnLogOut.TextAlign = ContentAlignment.MiddleLeft;
            btnLogOut.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnLogOut.UseVisualStyleBackColor = false;
            btnLogOut.Click += btnLogOut_Click;
            // 
            // btnManage
            // 
            btnManage.BackColor = Color.FromArgb(84, 86, 240);
            btnManage.FlatAppearance.BorderSize = 0;
            btnManage.FlatStyle = FlatStyle.Flat;
            btnManage.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnManage.ForeColor = Color.WhiteSmoke;
            btnManage.IconChar = FontAwesome.Sharp.IconChar.PlusSquare;
            btnManage.IconColor = Color.WhiteSmoke;
            btnManage.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnManage.IconSize = 25;
            btnManage.ImageAlign = ContentAlignment.MiddleLeft;
            btnManage.Location = new Point(361, 95);
            btnManage.Margin = new Padding(3, 4, 3, 4);
            btnManage.Name = "btnManage";
            btnManage.Padding = new Padding(11, 0, 0, 0);
            btnManage.Size = new Size(166, 37);
            btnManage.TabIndex = 30;
            btnManage.Text = "Manage users";
            btnManage.TextAlign = ContentAlignment.MiddleLeft;
            btnManage.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnManage.UseVisualStyleBackColor = false;
            btnManage.Click += btnManage_Click;
            // 
            // lblUser
            // 
            lblUser.Font = new Font("Bahnschrift SemiBold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUser.Location = new Point(128, 72);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(168, 29);
            lblUser.TabIndex = 12;
            lblUser.Text = "User";
            // 
            // user
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(646, 226);
            Controls.Add(panel1);
            Name = "user";
            Text = "User";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private Panel panel1;
        private Label lblUser;
        private FontAwesome.Sharp.IconButton btnLogOut;
        private FontAwesome.Sharp.IconButton btnManage;
    }
}