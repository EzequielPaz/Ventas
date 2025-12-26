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
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                 string.IsNullOrWhiteSpace(textBox2.Text) ||
                 string.IsNullOrWhiteSpace(textBox3.Text) ||
                 string.IsNullOrWhiteSpace(textBox4.Text) ||
                 string.IsNullOrWhiteSpace(textBox5.Text))
            {
                MessageBox.Show("Todos los campos son obligatorios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var scope = _serviceProvider.CreateScope())
            {
                var dto = new CreateProveedorDTO
                {
                    RazonSocial = textBox1.Text,
                    CUIT = textBox2.Text,
                    CodigoProveedor = textBox3.Text,
                    Telefono = textBox4.Text,
                    Correo = textBox5.Text
                };

                try
                {
                    var proveedorServiciosScoped = scope.ServiceProvider.GetRequiredService<ProveedorServicio>();
                    await proveedorServiciosScoped.AgregarProveedorAsync(dto);

                    MessageBox.Show("¡Proveedor registrado con éxito!");
                    LimpiarTextBox();
                    ProveedorAgregado?.Invoke(this, EventArgs.Empty);

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
