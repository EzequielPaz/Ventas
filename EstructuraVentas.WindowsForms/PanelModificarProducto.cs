using EstructuraVentas.Dominio.Modelos;
using EstructuraVentas.LogicaNegocio.DTOs.Producto;
using EstructuraVentas.LogicaNegocio.Servicios;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Data;


namespace EstructuraVentas.WindowsForms
{
    public partial class PanelModificarProducto : Form
    {
        private readonly int _idProducto;
        private readonly IServiceProvider _serviceProvider;
        // Evento para notificar al formulario padre que el cliente se modificó
        public event EventHandler ProductoModificado;

        public PanelModificarProducto(IServiceProvider serviceProvider, int idProducto)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _idProducto = idProducto;
            this.CenterToScreen();
        }


        // ---------------------------------------------------
        // ✅ Cargar datos del producto
        // ---------------------------------------------------
        public async Task CargarDatosProducto(int id)
        {
            using var scope = _serviceProvider.CreateScope();
            var productoServicios = scope.ServiceProvider.GetRequiredService<ProductoServicios>();
            var categoriaServicios = scope.ServiceProvider.GetRequiredService<CategoriaServicio>();

            // 🔹 Cargar producto (asegurate de que devuelve un DTO con CategoriaId)
            var producto = await productoServicios.ObtenerPorIdProductoeAsync(id);

            if (producto == null)
            {
                MessageBox.Show("Producto no encontrado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }

            // 🔹 Cargar categorías disponibles
            var categoriasResponse = await categoriaServicios.MostrarCategoriasAsync();
            if (categoriasResponse == null || categoriasResponse.Records == null)
            {
                MessageBox.Show("Error al cargar categorías", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 🔹 Asignar categorías al comboBox
            comboBox1.DataSource = categoriasResponse.Records;
            comboBox1.DisplayMember = "Nombre";      // propiedad visible
            comboBox1.ValueMember = "IdCategoria";   // propiedad usada como valor

            // 🔹 Asegurar que el valor exista antes de asignar
            if (categoriasResponse.Records.Any(c => c.IdCategoria == producto.CategoriaId))
                comboBox1.SelectedValue = producto.CategoriaId;
            else
                comboBox1.SelectedIndex = -1;

            // 🔹 Asignar valores del producto a los TextBox
            textBox1.Text = producto.Nombre;
            textBox2.Text = producto.Descripcion;
            textBox3.Text = producto.Codigo;
            textBox4.Text = producto.Stock.ToString();
            textBox5.Text = producto.Marca;
            textBox6.Text = producto.Precio.ToString("0.00");


        }

        // ---------------------------------------------------
        // ✅ Armar el DTO desde los datos del panel
        // ---------------------------------------------------

        public UpdateProductDTO ObtenerProductoDesdePanel()
        {
            if (!(comboBox1.SelectedValue is int categoriaId) || categoriaId <= 0)
            {
                MessageBox.Show("Por favor, seleccione una categoría válida.");
                return null;
            }

            if (!int.TryParse(textBox4.Text, out int stock))
            {
                MessageBox.Show("El stock debe ser un número entero válido.");
                return null;
            }

            if (!decimal.TryParse(textBox6.Text, out decimal precio))
            {
                MessageBox.Show("El precio debe ser un número válido.");
                return null;
            }

            return new UpdateProductDTO
            {
                IdProducto = _idProducto,
                Nombre = textBox1.Text.Trim(),
                Descripcion = textBox2.Text.Trim(),
                Codigo = textBox3.Text.Trim(),
                Marca = textBox5.Text.Trim(),
                Stock = stock,
                Precio = precio,
                CategoriaId = categoriaId
            };
        }

        // ---------------------------------------------------
        // ✅ Botón Guardar
        // ---------------------------------------------------

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

            using var scope = _serviceProvider.CreateScope();
            try
            {
                var dto = ObtenerProductoDesdePanel();
                if (dto == null) return; // Ya se mostró el error correspondiente

                var productoServicios = scope.ServiceProvider.GetRequiredService<ProductoServicios>();
                await productoServicios.ModificarProducto(dto);

                MessageBox.Show("Producto actualizado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ProductoModificado?.Invoke(this, EventArgs.Empty);
                this.Close();
            }
            catch (ValidationException vex)
            {
                var errores = string.Join(Environment.NewLine, vex.Errors.Select(e => e.ErrorMessage));
                MessageBox.Show("Errores de validación:\n" + errores, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar producto: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }

        //Textbox Nombre del producto
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        //Textbox Descripcion del producto
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        //Textbox Codigo del producto
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        //textbox Stock del producto

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
        //Textbox Marca del producto
        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        // ---------------------------------------------------
        // ✅ Cargar datos al iniciar el formulario
        // ---------------------------------------------------


        private async void PanelModificarProducto_Load_1(object sender, EventArgs e)
        {
            await CargarDatosProducto(_idProducto);
        }

        // ComboBox Categoria del producto
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //Textbox Precio del producto
        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
    }

}
