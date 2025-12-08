using EstructuraVentas.Dominio;
using EstructuraVentas.Dominio.Modelos;
using EstructuraVentas.LogicaNegocio.DTOs.Clientes;
using EstructuraVentas.LogicaNegocio.DTOs.Proveedor;
using EstructuraVentas.LogicaNegocio.Servicios;
using FluentValidation;
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
        private readonly string _idProveedor;
        private readonly IServiceProvider _serviceProvider;

        // Evento para notificar al formulario padre que el cliente se modificó
        public event EventHandler ProveedorModificado;
        public PanelEditarProveedor(IServiceProvider serviceProvider, string idProveedor)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _idProveedor = idProveedor;
            this.CenterToScreen();
        }
        //load
        private async void PanelEditarProveedor_Load(object sender, EventArgs e)
        {
            try
            {
                await CargarDatosProveedor(_idProveedor);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos del proveedor: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private async Task CargarDatosProveedor(string id)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var proveedorServiciosScoped = scope.ServiceProvider.GetRequiredService<ProveedorServicio>();
                var proveedor = await proveedorServiciosScoped.ObtenerPorIdProveedorAsync(id);

                if (proveedor != null)
                {
                    textBox1.Text = proveedor.RazonSocial;
                    textBox2.Text = proveedor.CUIT;
                    textBox3.Text = proveedor.CodigoProveedor;
                    textBox4.Text = proveedor.Telefono;
                    textBox5.Text = proveedor.Correo;
                }
                else
                {
                    MessageBox.Show("Proveedor no encontrado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                }
            }
        }

        private UpdateProveedorDTO ObtenerProveedorDesdePanel()
        {
            return new UpdateProveedorDTO
            {
                IdProveedor = _idProveedor,
                RazonSocial = textBox1.Text.Trim(),
                CUIT = textBox2.Text.Trim(),
                CodigoProveedor = textBox3.Text.Trim(),
                Telefono = textBox4.Text.Trim(),
                Correo = textBox5.Text.Trim(),
            };
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
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
               string.IsNullOrWhiteSpace(textBox2.Text) ||
               string.IsNullOrWhiteSpace(textBox3.Text) ||
               string.IsNullOrWhiteSpace(textBox4.Text))
            {
                MessageBox.Show("Todos los campos son obligatorios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var scope = _serviceProvider.CreateScope())
            {
                try
                {
                    var dto = ObtenerProveedorDesdePanel();
                    var proveedorServiciosScoped = scope.ServiceProvider.GetRequiredService<ProveedorServicio>();
                    await proveedorServiciosScoped.ModificarProveedorAsync(dto);



                    MessageBox.Show("Proveedor actualizado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Notificar al formulario padre
                    ProveedorModificado?.Invoke(this, EventArgs.Empty);

                    this.Close();
                }
                catch (ValidationException vex)
                {
                    var errores = string.Join(Environment.NewLine, vex.Errors.Select(e => e.ErrorMessage));
                    MessageBox.Show("Errores de validación:\n" + errores, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar proveedor: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //BOTON CANCELAR

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

    }
}
