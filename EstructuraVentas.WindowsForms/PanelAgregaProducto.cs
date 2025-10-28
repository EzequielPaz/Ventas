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
        private string NombreProductoTexto = string.Empty;
        private string DescripcionTexto = string.Empty;
        private string CodigoTexto = string.Empty;
        private string StockTexto = string.Empty;
        private string MarcaTexto = string.Empty;
        private string PrecioTexto = string.Empty;
        private string CategoriaTexto = string.Empty;

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
            NombreProductoTexto = textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            DescripcionTexto = textBox2.Text;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            CodigoTexto = textBox3.Text;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            StockTexto = textBox4.Text;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            MarcaTexto = textBox5.Text;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            PrecioTexto = textBox6.Text;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            NombreProductoTexto = textBox1.Text;
            DescripcionTexto = textBox2.Text;
            CodigoTexto = textBox3.Text;
            StockTexto = textBox4.Text;
            MarcaTexto = textBox5.Text;
            PrecioTexto = textBox6.Text;
            CategoriaTexto = textBox7.Text;

            if (string.IsNullOrWhiteSpace(NombreProductoTexto) ||
                string.IsNullOrWhiteSpace(DescripcionTexto) ||
                string.IsNullOrWhiteSpace(CodigoTexto) ||
                string.IsNullOrWhiteSpace(StockTexto) ||
                string.IsNullOrWhiteSpace(CategoriaTexto) == null)
            {
                MessageBox.Show("Debes llenar todos los campos");
                return;
            }

            if (!int.TryParse(StockTexto, out int stock) || stock < 0)
            {
                MessageBox.Show("El stock debe ser un número entero positivo.");
                return;
            }

            if (!int.TryParse(PrecioTexto, out int Precio) || Precio < 0)
            {
                MessageBox.Show("El precio debe ser un número entero positivo.");
                return;
            }

            if (!int.TryParse(CategoriaTexto, out int Categoria) || Precio < 0)
            {
                MessageBox.Show("La categoria debe ser un entero.");
                return;
            }


            var productDTO = new CreateProductDTO
            {
                Nombre = NombreProductoTexto,
                Descripcion = DescripcionTexto,
                Codigo = CodigoTexto,
                Stock = stock,
                Marca = MarcaTexto,
                Precio = Precio,
                CategoriaId = Categoria,
     
            };

            try
            {
                await _productoServicios.AgregarProducto(productDTO);
                MessageBox.Show("¡Producto registrado con éxito!");
                LimpiarTextBox();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar producto: " + ex.Message);
            }
        }
        private void LimpiarTextBox()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
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
            var categorias = await _categoriaServicio.ObtenerTodas();

            if (categorias == null || !categorias.Any())
            {
                MessageBox.Show("No hay categorías registradas. Debes crear al menos una antes de agregar productos.");
                this.Hide();
                return;
            }


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            CategoriaTexto = textBox6.Text;

        }
    }
}
