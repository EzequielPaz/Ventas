using EstructuraVentas.Dominio.Modelos;
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
    public partial class PanelEditarProveedor : Form
    {
        //varibles de clase
        private readonly IServiceProvider _serviceProvider;
        private readonly ProveedorServicio _proveedorServicio;
        private readonly int _proveedorId;
        //contructor
        public PanelEditarProveedor(IServiceProvider serviceProvider, int idProveedor)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _proveedorServicio = _serviceProvider.GetRequiredService<ProveedorServicio>();
            _proveedorId = idProveedor;
            this.CenterToScreen();
        }
        //load
        private async void PanelEditarProveedor_Load(object sender, EventArgs e)
        {
            await CargarDatosProveedor(_proveedorId);

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
        //BOTON GUARDAR MODIFICACION
        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var proveedorActualizado = ObtenerProveedorDesdeFormulario();

                // Llamás al servicio para actualizar
                await _proveedorServicio.ActualizarProveedorAsync(proveedorActualizado);

                MessageBox.Show("Proveedor actualizado correctamente.");
                this.Close();  // Cerrás el formulario si querés
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar proveedor: {ex.Message}");
            }
        }

        //BOTON CANCELAR

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        //FUNCION QUE CARGA DATOS DEL PROVEEDOR AL HACER CLICK EN LA FILA 
        public async Task CargarDatosProveedor(int id)
        {

            var proveedor = await _proveedorServicio.obtenerProveedorPorId(id);

            if (proveedor != null)
            {
                textBox1.Text = proveedor.RazonSocial;
                textBox2.Text = proveedor.Telefono;
                textBox3.Text = proveedor.Correo;
                textBox4.Text = proveedor.CUIT;
                textBox5.Text = proveedor.CodigoProovedor;
            }
            else
            {
                MessageBox.Show("Proveedor no encontrado");
                this.Close();
            }

        }

        public Proveedor ObtenerProveedorDesdeFormulario()
        {
            return new Proveedor
            {
                IdProveedor = _proveedorId,  // Usamos el id que recibiste en el constructor
                RazonSocial = textBox1.Text,
                Telefono = textBox2.Text,
                Correo = textBox3.Text,
                CUIT = textBox4.Text,
                CodigoProovedor = textBox5.Text
            };
        }


    }
}
