namespace AgroControl
{
    partial class newGreenhouse
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
            iconButton2 = new FontAwesome.Sharp.IconButton();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label5 = new Label();
            textBox3 = new TextBox();
            label1 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.WhiteSmoke;
            panel1.Controls.Add(textBox3);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label11);
            panel1.Controls.Add(iconButton2);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label5);
            panel1.Location = new Point(24, 27);
            panel1.Name = "panel1";
            panel1.Size = new Size(448, 444);
            panel1.TabIndex = 12;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.Location = new Point(28, 28);
            label11.Name = "label11";
            label11.Size = new Size(211, 28);
            label11.TabIndex = 13;
            label11.Text = "Add new greenhouse";
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
            iconButton2.Location = new Point(28, 354);
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
            label3.Size = new Size(0, 23);
            label3.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(28, 162);
            label2.Name = "label2";
            label2.Size = new Size(70, 23);
            label2.TabIndex = 4;
            label2.Text = "Address";
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
            // textBox3
            // 
            textBox3.BackColor = Color.WhiteSmoke;
            textBox3.Location = new Point(28, 288);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(386, 27);
            textBox3.TabIndex = 15;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(28, 249);
            label1.Name = "label1";
            label1.Size = new Size(96, 23);
            label1.TabIndex = 14;
            label1.Text = "Description";
            // 
            // newGreenhouse
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(498, 496);
            Controls.Add(panel1);
            Name = "newGreenhouse";
            Text = "New Greenhouse";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private TextBox textBox3;
        private Label label1;
        private Label label11;
        private FontAwesome.Sharp.IconButton iconButton2;
        private TextBox textBox2;
        private TextBox textBox1;
        private Label label3;
        private Label label2;
        private Label label5;
    }
}
