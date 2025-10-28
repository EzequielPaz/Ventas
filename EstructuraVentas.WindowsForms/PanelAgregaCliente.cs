using EstructuraVentas.LogicaNegocio.DTOs.Clientes;
using EstructuraVentas.LogicaNegocio.Servicios;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace EstructuraVentas.WindowsForms
{
    public partial class PanelAgregaCliente : Form
    {
        private readonly IServiceProvider _serviceProvider;
        public event EventHandler ClienteAgregado;
        private string NombreClienteTexto = string.Empty;
        private string DocumentoTexto = string.Empty;
        private string EmailTexto = string.Empty;
        private string CelularTexto = string.Empty;
        public PanelAgregaCliente(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            this.CenterToScreen();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void PanelAgregaCliente_Load(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e) //Aceptar 
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
                var dto = new CreateClienteDTO
                {
                    NombreCliente = textBox1.Text,
                    Email = textBox2.Text,
                    Documento = textBox3.Text,
                    Celular = textBox4.Text
                };

                try
                {
                    var clienteServiciosScoped = scope.ServiceProvider.GetRequiredService<ClienteServicios>();
                    await clienteServiciosScoped.AgregarCliente(dto);

                    MessageBox.Show("¡Cliente registrado con éxito!");
                    LimpiarTextBox();
                    ClienteAgregado?.Invoke(this, EventArgs.Empty);

                    this.Hide(); // opcional: podrías dejarlo abierto para seguir cargando

                }
                catch (ValidationException vex)
                {
                    var errores = string.Join(Environment.NewLine, vex.Errors.Select(e => e.ErrorMessage));
                    MessageBox.Show("Errores de validación:\n" + errores);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al registrar usuario: " + ex.Message);
                }
            }
            
        }

        
        private void LimpiarTextBox()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }
        private void button2_Click(object sender, EventArgs e) //Cancelar
        {
            LimpiarTextBox();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            NombreClienteTexto = textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            EmailTexto = textBox2.Text;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            DocumentoTexto = textBox3.Text;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            CelularTexto = textBox4.Text;
        }
    }
}
