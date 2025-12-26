using EstructuraVentas.Dominio.Modelos;
using EstructuraVentas.LogicaNegocio.DTOs.Proveedor;
using EstructuraVentas.LogicaNegocio.Servicios;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using System.Data;

namespace EstructuraVentas.WindowsForms
{
    public partial class PanelAgregarProveedor : Form
    {
        private readonly IServiceProvider _serviceProvider;
        public event EventHandler ProveedorAgregado;


        public PanelAgregarProveedor(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var razonSocialTexto = textBox1.Text;
            var telefonoTexto = textBox2.Text;
            var correoTexto = textBox3.Text;
            var cuitTexto = textBox4.Text;
            var codigoTexto = textBox5.Text;

            if (string.IsNullOrEmpty(razonSocialTexto) ||
                string.IsNullOrEmpty(telefonoTexto) ||
                string.IsNullOrEmpty(correoTexto) ||
                string.IsNullOrEmpty(cuitTexto) ||
                string.IsNullOrEmpty(codigoTexto))
            {
                MessageBox.Show("Todos los campos son obligatorios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var nuevoProveedorDto = new CreateProveedorDto
            {
                RazonSocial = razonSocialTexto,
                Telefono = telefonoTexto,
                Correo = correoTexto,
                CUIT = cuitTexto,
                CodigoProveedor = codigoTexto
            };

            try
            {
                var proveedorServicio = _serviceProvider.GetService<ProveedorServicio>();
                await proveedorServicio.AgregarProveedor(nuevoProveedorDto);

                MessageBox.Show("¡Proveedor registrado con éxito!");
                LimpiarCampos();
                this.Hide();
            }
            catch (ValidationException ex)
            {
                MessageBox.Show(ex.Message, "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar usuario: " + ex.Message);
            }


        }
        private void LimpiarTextBox()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LimpiarTextBox();
            this.Hide();
        }

        private void PanelAgregarProveedor_Load(object sender, EventArgs e)
        {

        }

        private void PanelAgregarProveedor_Load_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged_1(object sender, EventArgs e)
        {

        }


    }
}
