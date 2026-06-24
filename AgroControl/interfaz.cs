using AgroControl.Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgroControl
{
    public partial class Interfaz : Form
    {
        private Usuario _usuarioLogueado;
        private int _idInvernaderoActivo = 1;
        public static SerialReaderService? SerialReader { get; private set; }

        public Interfaz()
        {
            InitializeComponent();
        }

        public Interfaz(Usuario usuarioQueIngreso, int idInvernadero, string nombreInvernadero)
        {
            InitializeComponent();
            _usuarioLogueado = usuarioQueIngreso;
            _idInvernaderoActivo = idInvernadero;
            btnUser.Text = _usuarioLogueado.Nombre;
            this.Text = "Main Panel - User: " + _usuarioLogueado.Nombre;
            IniciarSerialReader();
            this.FormClosing += (s, e) => SerialReader?.Stop();
        }

        private void IniciarSerialReader()
        {
            if (SerialReader == null)
            {
                SerialReader = new SerialReaderService(_idInvernaderoActivo);
                SerialReader.Start();
            }
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {

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
            if (_usuarioLogueado.TipoUsuario != "Admin" && _usuarioLogueado.TipoUsuario != "Tecnico")
            {
                MessageBox.Show("You do not have permission to access this section.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            label1.Text = "Technical Functions";
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
            openSonForm(new plantRecord(_usuarioLogueado));
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
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


