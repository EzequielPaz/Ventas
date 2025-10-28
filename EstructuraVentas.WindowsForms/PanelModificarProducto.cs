using EstructuraVentas.Dominio;
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
    public partial class PanelModificarProducto : Form
    {
        private readonly int _idProducto;
        private readonly ProductoServicios _productoServicios;
        private readonly CategoriaServicio _categoriaServicio;
        private readonly IServiceProvider _serviceProvider;

        public PanelModificarProducto(IServiceProvider serviceProvider, int idProducto)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _productoServicios = _serviceProvider.GetRequiredService<ProductoServicios>();
            _categoriaServicio = _serviceProvider.GetRequiredService<CategoriaServicio>();

            _idProducto = idProducto;
            this.CenterToScreen();
        }



        public async Task CargarDatosProducto(int id)
        {
            var producto = await _productoServicios.ObtenerPorIdProducto(id);

            if (producto != null)
            {
                textBox1.Text = producto.Nombre;
                textBox2.Text = producto.Descripcion;
                textBox3.Text = producto.Codigo;
                textBox4.Text = producto.Stock.ToString();
                textBox5.Text = producto.Marca;

                // Set the selected category in comboBox1
                if (producto.CategoriaId > 0)
                {
                    var categorias = await _categoriaServicio.ObtenerTodas();
                    comboBox1.DataSource = categorias;
                    comboBox1.DisplayMember = "Nombre";
                    comboBox1.ValueMember = "IdCategoria";
                    comboBox1.SelectedValue = producto.CategoriaId; // Select the product's category
                }
            }
            else
            {
                MessageBox.Show("Producto no encontrado");
                this.Close();
            }
        }

        public Producto ObtenerProductoDesdePanel()
        {
            var categoriaSeleccionada = comboBox1.SelectedItem as Categoria;

            //Valida que se haya seleccionado una categoria
            if (categoriaSeleccionada == null)
            {
                MessageBox.Show("Por favor, seleccione una categoría válida.");
                return null;
            }

            int stock;
            if (!int.TryParse(textBox4.Text, out stock))
            {
                MessageBox.Show("El stock debe ser un número entero válido.");
                return null;
            }

            return new Producto
            {
                IdProducto = _idProducto,
                Nombre = textBox1.Text,
                Descripcion = textBox2.Text,
                Codigo = textBox3.Text,
                Stock = stock,
                Marca = textBox5.Text,
                CategoriaId = categoriaSeleccionada.IdCategoria
            };
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var productoModificado = ObtenerProductoDesdePanel();

                if (productoModificado == null)
                    return;

                await _productoServicios.ModificarProducto(productoModificado);

                MessageBox.Show("Producto actualizado con éxito.");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar producto: {ex.Message}");
            }
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

        private async void PanelModificarProducto_Load_1(object sender, EventArgs e)
        {
            // Load product data and set comboBox1
            await CargarDatosProducto(_idProducto);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

}
