using BusinessLogic;
using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgroControl
{
    // En el archivo de tu FormPrincipal.cs
    public partial class Interfaz : Form
    {
        private Usuario _usuarioLogueado; // Variable para guardar quién entró

        public Interfaz()
        {
            InitializeComponent();
        }

        // Modificamos el constructor para que reciba al usuario
        public Interfaz(Usuario usuarioQueIngreso)
        {
            InitializeComponent();
            _usuarioLogueado = usuarioQueIngreso;
            label2.Text = _usuarioLogueado.Nombre;
            this.Text = "Panel Principal - Usuario: " + _usuarioLogueado.Nombre;
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            // Así puedes mostrar el nombre en el título de la ventana


        }

        private void openSonForm(Form SonForm)
        {
            if (this.panelDesktop.Controls.Count > 0)
                this.panelDesktop.Controls.RemoveAt(0);

            SonForm.TopLevel = false;
            SonForm.Dock = DockStyle.Fill;
            this.panelDesktop.Controls.Add(SonForm);
            this.panelDesktop.Tag = SonForm;
            SonForm.Show();
        }

        private void Interfaz_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnDasboard_Click(object sender, EventArgs e)
        {
            label1.Text = "Dashboard";
            openSonForm(new dashboard());
        }

        private void iconButton11_Click(object sender, EventArgs e)
        {

        }

        private void iconButton10_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void btnReadingLog_Click(object sender, EventArgs e)
        {
            label1.Text = "Reading Log";
            openSonForm(new readingLog());
        }

        private void btnCharts_Click(object sender, EventArgs e)
        {
            label1.Text = "Charts";
            openSonForm(new charts());
        }

        private void btnPlantRecords_Click(object sender, EventArgs e)
        {
            label1.Text = "Plant Records";
            openSonForm(new plantRecord());
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            label1.Text = "Settings";
            openSonForm(new settings());
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panelTitleBar_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
