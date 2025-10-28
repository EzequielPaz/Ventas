using EstructuraVentas.Dominio;
using EstructuraVentas.LogicaNegocio.DTOs.Clientes;
using EstructuraVentas.LogicaNegocio.Servicios;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EstructuraVentas.WindowsForms
{
    public partial class PanelModificarCliente : Form
    {
        private readonly int _idCliente;
        private readonly IServiceProvider _serviceProvider;

        // Evento para notificar al formulario padre que el cliente se modificó
        public event EventHandler ClienteModificado;

        public PanelModificarCliente(IServiceProvider serviceProvider, int idCliente)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _idCliente = idCliente;
            this.CenterToScreen();
        }

        private async void PanelModificarCliente_Load(object sender, EventArgs e)
        {
            try
            {
                await CargarDatosClientes(_idCliente);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos del cliente: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private async Task CargarDatosClientes(int id)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var clienteServiciosScoped = scope.ServiceProvider.GetRequiredService<ClienteServicios>();
                var cliente = await clienteServiciosScoped.ObtenerPorIdClienteAsync(id);

                if (cliente != null)
                {
                    textBox1.Text = cliente.NombreCliente;
                    textBox2.Text = cliente.Email;
                    textBox3.Text = cliente.Documento;
                    textBox4.Text = cliente.Celular;
                }
                else
                {
                    MessageBox.Show("Cliente no encontrado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                }
            }
        }

        private UpdateClienteDTO ObtenerClienteDesdePanel()
        {
            return new UpdateClienteDTO
            {
                IDClientes = _idCliente,
                NombreCliente = textBox1.Text.Trim(),
                Email = textBox2.Text.Trim(),
                Documento = textBox3.Text.Trim(),
                Celular = textBox4.Text.Trim(),
            };
        }

        private async void button1_Click(object sender, EventArgs e) // Guardar
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
                    var dto = ObtenerClienteDesdePanel();
                    var clienteServiciosScoped = scope.ServiceProvider.GetRequiredService<ClienteServicios>();
                    await clienteServiciosScoped.ModificarClienteAsync(dto);

                   

                    MessageBox.Show("Cliente actualizado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Notificar al formulario padre
                    ClienteModificado?.Invoke(this, EventArgs.Empty);

                    this.Close();
                }
                catch (ValidationException vex)
                {
                    var errores = string.Join(Environment.NewLine, vex.Errors.Select(e => e.ErrorMessage));
                    MessageBox.Show("Errores de validación:\n" + errores, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e) // Cancelar
        {
            this.Close();
        }

        // Los eventos TextChanged pueden eliminarse si no se usan
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void textBox2_TextChanged(object sender, EventArgs e) { }
        private void textBox3_TextChanged(object sender, EventArgs e) { }
        private void textBox4_TextChanged(object sender, EventArgs e) { }
    }
}
