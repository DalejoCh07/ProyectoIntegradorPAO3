namespace AgroControl
{
    partial class charts
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
            panel2 = new Panel();
            panel3 = new Panel();
            panel1 = new Panel();
            panel4 = new Panel();
            panel5 = new Panel();
            panel6 = new Panel();
            formsPlot1 = new ScottPlot.FormsPlot();
            formsPlot2 = new ScottPlot.FormsPlot();
            formsPlot3 = new ScottPlot.FormsPlot();
            formsPlot4 = new ScottPlot.FormsPlot();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel1.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            panel6.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.Controls.Add(formsPlot1);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(488, 240);
            panel2.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.Controls.Add(formsPlot2);
            panel3.Dock = DockStyle.Right;
            panel3.Location = new Point(487, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(488, 240);
            panel3.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.BackColor = Color.WhiteSmoke;
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Location = new Point(12, 68);
            panel1.Name = "panel1";
            panel1.Size = new Size(975, 240);
            panel1.TabIndex = 0;
            // 
            // panel4
            // 
            panel4.BackColor = Color.WhiteSmoke;
            panel4.Controls.Add(panel5);
            panel4.Controls.Add(panel6);
            panel4.Location = new Point(12, 368);
            panel4.Name = "panel4";
            panel4.Size = new Size(975, 240);
            panel4.TabIndex = 1;
            // 
            // panel5
            // 
            panel5.Controls.Add(formsPlot4);
            panel5.Dock = DockStyle.Right;
            panel5.Location = new Point(487, 0);
            panel5.Name = "panel5";
            panel5.Size = new Size(488, 240);
            panel5.TabIndex = 1;
            // 
            // panel6
            // 
            panel6.Controls.Add(formsPlot3);
            panel6.Dock = DockStyle.Left;
            panel6.Location = new Point(0, 0);
            panel6.Name = "panel6";
            panel6.Size = new Size(488, 240);
            panel6.TabIndex = 0;
            // 
            // formsPlot1
            // 
            formsPlot1.Dock = DockStyle.Fill;
            formsPlot1.Location = new Point(0, 0);
            formsPlot1.Margin = new Padding(5, 4, 5, 4);
            formsPlot1.Name = "formsPlot1";
            formsPlot1.Size = new Size(488, 240);
            formsPlot1.TabIndex = 0;
            // 
            // formsPlot2
            // 
            formsPlot2.Dock = DockStyle.Fill;
            formsPlot2.Location = new Point(0, 0);
            formsPlot2.Margin = new Padding(5, 4, 5, 4);
            formsPlot2.Name = "formsPlot2";
            formsPlot2.Size = new Size(488, 240);
            formsPlot2.TabIndex = 1;
            // 
            // formsPlot3
            // 
            formsPlot3.Dock = DockStyle.Fill;
            formsPlot3.Location = new Point(0, 0);
            formsPlot3.Margin = new Padding(5, 4, 5, 4);
            formsPlot3.Name = "formsPlot3";
            formsPlot3.Size = new Size(488, 240);
            formsPlot3.TabIndex = 1;
            // 
            // formsPlot4
            // 
            formsPlot4.Dock = DockStyle.Fill;
            formsPlot4.Location = new Point(0, 0);
            formsPlot4.Margin = new Padding(5, 4, 5, 4);
            formsPlot4.Name = "formsPlot4";
            formsPlot4.Size = new Size(488, 240);
            formsPlot4.TabIndex = 1;
            // 
            // charts
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(999, 620);
            Controls.Add(panel4);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "charts";
            Text = "graphics";
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel6.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel2;
        private Panel panel3;
        private Panel panel1;
        private Panel panel4;
        private Panel panel5;
        private Panel panel6;
        private ScottPlot.FormsPlot formsPlot1;
        private ScottPlot.FormsPlot formsPlot2;
        private ScottPlot.FormsPlot formsPlot4;
        private ScottPlot.FormsPlot formsPlot3;
    }
}