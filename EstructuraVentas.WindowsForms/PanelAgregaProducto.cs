using EstructuraVentas.Dominio;
using EstructuraVentas.Dominio.Modelos;
using EstructuraVentas.LogicaNegocio.DTOs.Producto;
using EstructuraVentas.LogicaNegocio.Servicios;
using Microsoft.Extensions.DependencyInjection;

namespace EstructuraVentas.WindowsForms
{
    public partial class PanelAgregaProducto : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly CategoriaServicio _categoriaServicio;
        private readonly ProductoServicios _productoServicios;

        public event EventHandler ProductoAgregado;

        public PanelAgregaProducto(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _categoriaServicio = _serviceProvider.GetRequiredService<CategoriaServicio>();
            _productoServicios = _serviceProvider.GetRequiredService<ProductoServicios>();
            this.CenterToScreen();
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

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            // Validaciones de campos
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) ||
                string.IsNullOrWhiteSpace(textBox4.Text) ||
                string.IsNullOrWhiteSpace(textBox5.Text) ||
                string.IsNullOrWhiteSpace(textBox6.Text))
            {
                MessageBox.Show("Debes llenar todos los campos.");
                return;
            }

            if (!int.TryParse(textBox4.Text, out int stock) || stock < 0)
            {
                MessageBox.Show("El stock debe ser un número entero positivo.");
                return;
            }

            if (!decimal.TryParse(textBox6.Text, out decimal precio) || precio < 0)
            {
                MessageBox.Show("El precio debe ser un número decimal positivo.");
                return;
            }

            if (comboBox1.SelectedValue == null)
            {
                MessageBox.Show("Debes seleccionar una categoría.");
                return;
            }

            int categoriaId = (int)comboBox1.SelectedValue;

            // Crear DTO
            var productDTO = new CreateProductDTO
            {
                Nombre = textBox1.Text,
                Descripcion = textBox2.Text,
                Codigo = textBox3.Text,
                Stock = stock,
                Marca = textBox5.Text,
                Precio = precio,
                CategoriaId = categoriaId
            };

            try
            {
                await _productoServicios.AgregarProducto(productDTO);
                MessageBox.Show("¡Producto registrado con éxito!");
                ProductoAgregado?.Invoke(this, EventArgs.Empty);
                LimpiarCampos();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar producto: {ex.Message}");
            }
        }
        private void LimpiarCampos()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            comboBox1.SelectedIndex = -1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private async void PanelAgregaProducto_Load(object sender, EventArgs e)
        {
            try
            {
                var categoriasResponse = await _categoriaServicio.MostrarCategoriasAsync();

                if (categoriasResponse == null || categoriasResponse.Records == null || !categoriasResponse.Records.Any())
                {
                    MessageBox.Show("No hay categorías registradas. Debes crear al menos una antes de agregar productos.");
                    this.Hide();
                    return;
                }

                comboBox1.DataSource = categoriasResponse.Records;
                comboBox1.DisplayMember = "Nombre";   // lo que se muestra al usuario
                comboBox1.ValueMember = "IdCategoria"; // el valor que se usará internamente
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar categorías: {ex.Message}");
            }


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}
