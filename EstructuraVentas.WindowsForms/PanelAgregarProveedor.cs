using EstructuraVentas.Dominio.Modelos;
using EstructuraVentas.LogicaNegocio.Servicios;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EstructuraVentas.WindowsForms
{
    public partial class PanelAgregarProveedor : Form
    {
        private readonly IServiceProvider _serviceProvider;

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




            //Validar que todos los campos estén completos
            if (string.IsNullOrEmpty(razonSocialTexto) ||
                string.IsNullOrEmpty(telefonoTexto) || 
                string.IsNullOrEmpty(correoTexto) || string.IsNullOrEmpty(cuitTexto) || 
                string.IsNullOrEmpty(codigoTexto))
            {
                MessageBox.Show("Debes llenar todos los campos.");
                return;
            }


            var nuevoProveedor = new Proveedor
            {
                RazonSocial = razonSocialTexto,
                Telefono = telefonoTexto,
                Correo = correoTexto,
                CUIT = cuitTexto,
                CodigoProovedor = codigoTexto,
                FechaDeRegistro = DateTime.Now,
            };

            try
            {
                var proveedorServicio = _serviceProvider.GetService<ProveedorServicio>();
                await proveedorServicio.agregarProveedorAsync(nuevoProveedor);
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void PanelAgregarProveedor_Load(object sender, EventArgs e)
        {
           
        }

        private void PanelAgregarProveedor_Load_1(object sender, EventArgs e)
        {

        }
        private void LimpiarCampos()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }


    }
}
