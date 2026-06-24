namespace AgroControl.View
{
    partial class newSensor
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
            cmbSensorTypes = new ComboBox();
            label11 = new Label();
            iconButton2 = new FontAwesome.Sharp.IconButton();
            cmbGreenhouse = new ComboBox();
            label3 = new Label();
            label2 = new Label();
            label5 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.WhiteSmoke;
            panel1.Controls.Add(cmbSensorTypes);
            panel1.Controls.Add(label11);
            panel1.Controls.Add(iconButton2);
            panel1.Controls.Add(cmbGreenhouse);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label5);
            panel1.Location = new Point(26, 28);
            panel1.Name = "panel1";
            panel1.Size = new Size(242, 394);
            panel1.TabIndex = 13;
            // 
            // cmbSensorTypes
            // 
            cmbSensorTypes.BackColor = Color.WhiteSmoke;
            cmbSensorTypes.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSensorTypes.ForeColor = Color.Black;
            cmbSensorTypes.FormattingEnabled = true;
            cmbSensorTypes.Location = new Point(28, 122);
            cmbSensorTypes.Name = "cmbSensorTypes";
            cmbSensorTypes.Size = new Size(151, 28);
            cmbSensorTypes.TabIndex = 14;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.Location = new Point(28, 28);
            label11.Name = "label11";
            label11.Size = new Size(162, 28);
            label11.TabIndex = 13;
            label11.Text = "Add new sensor";
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
            iconButton2.Location = new Point(28, 308);
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
            // cmbGreenhouse
            // 
            cmbGreenhouse.BackColor = Color.WhiteSmoke;
            cmbGreenhouse.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGreenhouse.ForeColor = Color.Black;
            cmbGreenhouse.FormattingEnabled = true;
            cmbGreenhouse.Location = new Point(28, 233);
            cmbGreenhouse.Name = "cmbGreenhouse";
            cmbGreenhouse.Size = new Size(151, 28);
            cmbGreenhouse.TabIndex = 10;
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
            label2.Location = new Point(28, 181);
            label2.Name = "label2";
            label2.Size = new Size(102, 23);
            label2.TabIndex = 4;
            label2.Text = "Greenhouse";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(28, 81);
            label5.Name = "label5";
            label5.Size = new Size(46, 23);
            label5.TabIndex = 3;
            label5.Text = "Type";
            // 
            // newSensor
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(314, 450);
            Controls.Add(panel1);
            Name = "newSensor";
            Text = "New Sensor";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private ComboBox cmbSensorTypes;
        private Label label11;
        private FontAwesome.Sharp.IconButton iconButton2;
        private ComboBox cmbGreenhouse;
        private Label label3;
        private Label label2;
        private Label label5;
    }
}