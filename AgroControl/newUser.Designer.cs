namespace AgroControl
{
    partial class newUser
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
            panel1 = new Panel();
            label11 = new Label();
            btnSaveUser = new FontAwesome.Sharp.IconButton();
            cmbRoles = new ComboBox();
            txtPass = new TextBox();
            txtName = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label5 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.WhiteSmoke;
            panel1.Controls.Add(label11);
            panel1.Controls.Add(btnSaveUser);
            panel1.Controls.Add(cmbRoles);
            panel1.Controls.Add(txtPass);
            panel1.Controls.Add(txtName);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label5);
            panel1.Location = new Point(23, 22);
            panel1.Name = "panel1";
            panel1.Size = new Size(448, 394);
            panel1.TabIndex = 12;
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
            // btnSaveUser
            // 
            btnSaveUser.BackColor = Color.FromArgb(84, 86, 240);
            btnSaveUser.FlatAppearance.BorderSize = 0;
            btnSaveUser.FlatStyle = FlatStyle.Flat;
            btnSaveUser.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSaveUser.ForeColor = Color.WhiteSmoke;
            btnSaveUser.IconChar = FontAwesome.Sharp.IconChar.Save;
            btnSaveUser.IconColor = Color.WhiteSmoke;
            btnSaveUser.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnSaveUser.IconSize = 25;
            btnSaveUser.ImageAlign = ContentAlignment.MiddleLeft;
            btnSaveUser.Location = new Point(28, 322);
            btnSaveUser.Margin = new Padding(3, 4, 3, 4);
            btnSaveUser.Name = "btnSaveUser";
            btnSaveUser.Padding = new Padding(11, 0, 0, 0);
            btnSaveUser.Size = new Size(105, 53);
            btnSaveUser.TabIndex = 12;
            btnSaveUser.Text = "Save";
            btnSaveUser.TextAlign = ContentAlignment.MiddleLeft;
            btnSaveUser.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSaveUser.UseVisualStyleBackColor = false;
            // 
            // cmbRoles
            // 
            cmbRoles.BackColor = Color.WhiteSmoke;
            cmbRoles.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRoles.ForeColor = Color.Black;
            cmbRoles.FormattingEnabled = true;
            cmbRoles.Location = new Point(212, 269);
            cmbRoles.Name = "cmbRoles";
            cmbRoles.Size = new Size(151, 28);
            cmbRoles.TabIndex = 10;
            // 
            // txtPass
            // 
            txtPass.BackColor = Color.WhiteSmoke;
            txtPass.Location = new Point(28, 201);
            txtPass.Name = "txtPass";
            txtPass.Size = new Size(386, 27);
            txtPass.TabIndex = 7;
            // 
            // txtName
            // 
            txtName.BackColor = Color.WhiteSmoke;
            txtName.Location = new Point(28, 120);
            txtName.Name = "txtName";
            txtName.Size = new Size(386, 27);
            txtName.TabIndex = 6;
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
            // newUser
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(505, 432);
            Controls.Add(panel1);
            Name = "newUser";
            Text = "New user";
            Load += newUser_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label11;
        private FontAwesome.Sharp.IconButton btnSaveUser;
        private ComboBox cmbRoles;
        private TextBox txtPass;
        private TextBox txtName;
        private Label label3;
        private Label label2;
        private Label label5;
    }
}
