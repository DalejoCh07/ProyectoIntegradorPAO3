namespace AgroControl
{
    partial class adminUsers
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
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(adminUsers));
            dgvUsers = new DataGridView();
            label1 = new Label();
            btnNewUser = new FontAwesome.Sharp.IconButton();
            iconButton1 = new FontAwesome.Sharp.IconButton();
            iconButton3 = new FontAwesome.Sharp.IconButton();
            textBox3 = new TextBox();
            panel2 = new Panel();
            pictureBox6 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            SuspendLayout();
            // 
            // dgvUsers
            // 
            dataGridViewCellStyle6.BackColor = Color.WhiteSmoke;
            dgvUsers.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            dgvUsers.BackgroundColor = SystemColors.Control;
            dgvUsers.BorderStyle = BorderStyle.None;
            dgvUsers.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvUsers.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = Color.WhiteSmoke;
            dataGridViewCellStyle7.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle7.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.True;
            dgvUsers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = Color.WhiteSmoke;
            dataGridViewCellStyle8.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle8.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = Color.WhiteSmoke;
            dataGridViewCellStyle8.SelectionForeColor = Color.Black;
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.False;
            dgvUsers.DefaultCellStyle = dataGridViewCellStyle8;
            dgvUsers.EnableHeadersVisualStyles = false;
            dgvUsers.GridColor = Color.LightGray;
            dgvUsers.Location = new Point(27, 97);
            dgvUsers.Name = "dgvUsers";
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = Color.LightGray;
            dataGridViewCellStyle9.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle9.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = DataGridViewTriState.True;
            dgvUsers.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            dgvUsers.RowHeadersVisible = false;
            dgvUsers.RowHeadersWidth = 51;
            dataGridViewCellStyle10.BackColor = Color.WhiteSmoke;
            dgvUsers.RowsDefaultCellStyle = dataGridViewCellStyle10;
            dgvUsers.Size = new Size(464, 394);
            dgvUsers.TabIndex = 7;
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
            // btnNewUser
            // 
            btnNewUser.BackColor = Color.FromArgb(84, 86, 240);
            btnNewUser.FlatAppearance.BorderSize = 0;
            btnNewUser.FlatStyle = FlatStyle.Flat;
            btnNewUser.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNewUser.ForeColor = Color.WhiteSmoke;
            btnNewUser.IconChar = FontAwesome.Sharp.IconChar.PlusSquare;
            btnNewUser.IconColor = Color.WhiteSmoke;
            btnNewUser.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnNewUser.IconSize = 25;
            btnNewUser.ImageAlign = ContentAlignment.MiddleLeft;
            btnNewUser.Location = new Point(508, 147);
            btnNewUser.Margin = new Padding(3, 4, 3, 4);
            btnNewUser.Name = "btnNewUser";
            btnNewUser.Padding = new Padding(11, 0, 0, 0);
            btnNewUser.Size = new Size(143, 43);
            btnNewUser.TabIndex = 9;
            btnNewUser.Text = "New user";
            btnNewUser.TextAlign = ContentAlignment.MiddleLeft;
            btnNewUser.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnNewUser.UseVisualStyleBackColor = false;
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
            iconButton1.Location = new Point(508, 209);
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
            iconButton3.Location = new Point(674, 97);
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
            textBox3.Location = new Point(508, 97);
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
            panel2.Controls.Add(btnNewUser);
            panel2.Controls.Add(textBox3);
            panel2.Controls.Add(dgvUsers);
            panel2.Location = new Point(21, 27);
            panel2.Name = "panel2";
            panel2.Size = new Size(804, 515);
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
            // adminUsers
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(843, 568);
            Controls.Add(panel2);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 4, 3, 4);
            Name = "adminUsers";
            Text = "Admin users";
            Load += adminUsers_Load;
            ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvUsers;
        private Label label1;
        private FontAwesome.Sharp.IconButton btnNewUser;
        private FontAwesome.Sharp.IconButton iconButton1;
        private FontAwesome.Sharp.IconButton iconButton3;
        private TextBox textBox3;
        private Panel panel2;
        private PictureBox pictureBox6;
    }
}

