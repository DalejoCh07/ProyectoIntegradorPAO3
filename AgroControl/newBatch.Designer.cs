namespace AgroControl
{
    partial class newBatch
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
            label1 = new Label();
            label28 = new Label();
            numPlants = new NumericUpDown();
            cmbPlants = new ComboBox();
            label11 = new Label();
            btnSave = new FontAwesome.Sharp.IconButton();
            label3 = new Label();
            label2 = new Label();
            label5 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numPlants).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.WhiteSmoke;
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label28);
            panel1.Controls.Add(numPlants);
            panel1.Controls.Add(cmbPlants);
            panel1.Controls.Add(label11);
            panel1.Controls.Add(btnSave);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label5);
            panel1.Location = new Point(27, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(242, 366);
            panel1.TabIndex = 14;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Gray;
            label1.Location = new Point(25, 73);
            label1.Name = "label1";
            label1.Size = new Size(104, 23);
            label1.TabIndex = 17;
            label1.Text = "current date";
            // 
            // label28
            // 
            label28.AutoSize = true;
            label28.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label28.ForeColor = Color.Gray;
            label28.Location = new Point(25, 50);
            label28.Name = "label28";
            label28.Size = new Size(191, 23);
            label28.TabIndex = 16;
            label28.Text = "It is registered with the ";
            // 
            // numPlants
            // 
            numPlants.Location = new Point(28, 239);
            numPlants.Name = "numPlants";
            numPlants.Size = new Size(101, 27);
            numPlants.TabIndex = 15;
            // 
            // cmbPlants
            // 
            cmbPlants.BackColor = Color.WhiteSmoke;
            cmbPlants.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPlants.ForeColor = Color.Black;
            cmbPlants.FormattingEnabled = true;
            cmbPlants.Location = new Point(25, 155);
            cmbPlants.Name = "cmbPlants";
            cmbPlants.Size = new Size(191, 28);
            cmbPlants.TabIndex = 14;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.Location = new Point(25, 13);
            label11.Name = "label11";
            label11.Size = new Size(154, 28);
            label11.TabIndex = 13;
            label11.Text = "Add new batch";
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(84, 86, 240);
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSave.ForeColor = Color.WhiteSmoke;
            btnSave.IconChar = FontAwesome.Sharp.IconChar.Save;
            btnSave.IconColor = Color.WhiteSmoke;
            btnSave.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnSave.IconSize = 25;
            btnSave.ImageAlign = ContentAlignment.MiddleLeft;
            btnSave.Location = new Point(24, 296);
            btnSave.Margin = new Padding(3, 4, 3, 4);
            btnSave.Name = "btnSave";
            btnSave.Padding = new Padding(11, 0, 0, 0);
            btnSave.Size = new Size(105, 40);
            btnSave.TabIndex = 12;
            btnSave.Text = "Save";
            btnSave.TextAlign = ContentAlignment.MiddleLeft;
            btnSave.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSave.UseVisualStyleBackColor = false;
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
            label2.Location = new Point(25, 203);
            label2.Name = "label2";
            label2.Size = new Size(77, 23);
            label2.TabIndex = 4;
            label2.Text = "Quantity";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(25, 111);
            label5.Name = "label5";
            label5.Size = new Size(49, 23);
            label5.TabIndex = 3;
            label5.Text = "Plant";
            // 
            // newBatch
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(301, 401);
            Controls.Add(panel1);
            Name = "newBatch";
            Text = "newBatch";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numPlants).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private NumericUpDown numPlants;
        private ComboBox cmbPlants;
        private Label label11;
        private FontAwesome.Sharp.IconButton btnSave;
        private Label label3;
        private Label label2;
        private Label label5;
        private Label label1;
        private Label label28;
    }
}