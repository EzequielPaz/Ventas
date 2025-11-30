using EstructuraVentas.LogicaNegocio.Servicios;
using Microsoft.Extensions.DependencyInjection;
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
    public partial class PanelLogin : Form
    {
        private readonly UsuarioServicio _usuarioServicio;
        private readonly IServiceProvider _serviceProvider;


        public PanelLogin(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _usuarioServicio = _serviceProvider.GetRequiredService<UsuarioServicio>();

            InitializeComponent();
            textBox1.UseSystemPasswordChar = true;
            this.CenterToScreen();

        }
        private async void button1_Click(object sender, EventArgs e)
        {
            string nombreUsuario = textBox2.Text;
            string contraseña = textBox1.Text;

            try
            {
                bool autenticado = await _usuarioServicio.AutenticarUsuarioAsync(nombreUsuario, contraseña);

                if (autenticado)
                {
                    MessageBox.Show("¡Usuario encontrado!");
                    this.Hide();

                    var panelDashboard = new PanelDashboard(_serviceProvider, this);
                    panelDashboard.Show();
                    panelDashboard.Activate();
                }
                else
                {
                    MessageBox.Show("Usuario no encontrado o contraseña incorrecta.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al autenticar usuario: " + ex.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void PanelLogin_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.UseSystemPasswordChar = !checkBox1.Checked;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PanelRegistroUsuario panelRegistroUsuario = new PanelRegistroUsuario(this._serviceProvider);
            panelRegistroUsuario.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
