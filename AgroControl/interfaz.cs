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
        private int _idInvernaderoActivo = 1;
        public Interfaz()
        {
            InitializeComponent();
        }

        // Modificamos el constructor para que reciba al usuario
        public Interfaz(Usuario usuarioQueIngreso, int idInvernadero, string nombreInvernadero)
        {
            InitializeComponent();
            _usuarioLogueado = usuarioQueIngreso;
            _idInvernaderoActivo = idInvernadero;
            btnUser.Text = _usuarioLogueado.Nombre;
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
            openSonForm(new dashboard(_idInvernaderoActivo));
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            label1.Text = "Technical functions";
            openSonForm(new technical());
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
            openSonForm(new readingLog(_idInvernaderoActivo)); ;
        }

        private void btnCharts_Click(object sender, EventArgs e)
        {
            
            label1.Text = "Charts";
            openSonForm(new charts(_idInvernaderoActivo));
        }

        private void btnPlantRecords_Click(object sender, EventArgs e)
        {
            label1.Text = "Plant Records";
            openSonForm(new plantRecord());
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            // Pasamos el usuario que ya tenemos en la interfaz al nuevo formulario
            user ventanaConfig = new user(_usuarioLogueado);
            ventanaConfig.Show();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            label1.Text = "Help";
            openSonForm(new help());
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panelTitleBar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelDesktop_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
