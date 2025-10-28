using Microsoft.Extensions.DependencyInjection;
using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EstructuraVentas.WindowsForms
{
    public partial class PanelDashboard : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private Form _loginForm;
        public PanelDashboard(IServiceProvider serviceProvider, Form loginForm)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            this.CenterToScreen();
            _loginForm = loginForm;
        }

        private void PanelDashboard_Load(object sender, EventArgs e)
        {

        }

        public void loadForm(object form)
        {
            if (this.mainpanel.Controls.Count > 0)
                this.mainpanel.Controls.RemoveAt(0);

            Form f = form as Form;
            f.TopLevel = false;
            f.FormBorderStyle = FormBorderStyle.None;
            f.Dock = DockStyle.Fill;  // 🔥 Esto hace que el form se ajuste al tamaño del mainPanel
            this.mainpanel.Controls.Add(f);
            this.mainpanel.Tag = f;
            f.Show();
        }


        //Boton para registrar usuarios
        private void button1_Click(object sender, EventArgs e)
        {
            PanelRegistroUsuario panelRegistroUsuario = new PanelRegistroUsuario(this._serviceProvider);
            panelRegistroUsuario.Show();
        }
        //Cerrar sesion
        private void button2_Click(object sender, EventArgs e)
        {
            PanelLogin panelLoginForm = new PanelLogin(this._serviceProvider);
            panelLoginForm.Show();
            this.Hide();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void mainpanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelheader_Paint(object sender, PaintEventArgs e)
        {

        }
        //Clientes
        private void button3_Click(object sender, EventArgs e)
        {
            var panelClientes = _serviceProvider.GetRequiredService<PanelClientes>();
            loadForm(panelClientes);
        }


        //PRODUCTOS
        private void button4_Click(object sender, EventArgs e)
        {
            var panelProductos = _serviceProvider.GetRequiredService<PanelProductos>();
            loadForm(panelProductos);


        }
        //ventas

        private void button5_Click(object sender, EventArgs e)
        {
            var panelVentas = _serviceProvider.GetService<PanelVentas>();
            loadForm(panelVentas);
        }

        private void panelLogo_Paint(object sender, PaintEventArgs e)
        {

        }
        //
        private void iconButton1_Click(object sender, EventArgs e)
        {
            _loginForm.Show();
            _loginForm.Activate();

            // Cerrar el dashboard
            this.Close();
        }
        //CARGAR PANEL DE PROVEEDORES
        private void button1_Click_1(object sender, EventArgs e)
        {
            var panelProveedores = _serviceProvider.GetRequiredService<PanelProveedores>();
            loadForm(panelProveedores);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            var panelCompras = _serviceProvider.GetRequiredService<PanelCompras>();
            loadForm(panelCompras);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var panelCategorias = _serviceProvider.GetRequiredService<PanelAgregarCategoria>();
            loadForm(panelCategorias);
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            var panelCategorias = _serviceProvider.GetRequiredService<PanelAgregarCategoria>();
            loadForm(panelCategorias);
        }
    }
}
