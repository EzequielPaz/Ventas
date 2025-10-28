using EstructuraVentas.Dominio;
using EstructuraVentas.LogicaNegocio.Servicios;
using Microsoft.Extensions.DependencyInjection;
using System.Data;

namespace EstructuraVentas.WindowsForms
{
    public partial class PanelProductos : Form
    {
        private readonly ProductoServicios _productoServicios;
        private readonly IServiceProvider _serviceProvider;
        private List<Producto> _productosOriginales; // Utilizado en el filtro
        public PanelProductos(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _productoServicios = _serviceProvider.GetRequiredService<ProductoServicios>();

            this.CenterToScreen();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e) //Agregar
        {
            var PanelAgregaProducto = _serviceProvider.GetRequiredService<PanelAgregaProducto>();
            PanelAgregaProducto.ProductoAgregado += async (s, args) => await CargarProductoAsync();
            PanelAgregaProducto.Show();
        }

        private void button2_Click(object sender, EventArgs e) //Modificar
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Obtener la fila seleccionada
                DataGridViewRow filaSeleccionada = dataGridView1.SelectedRows[0];

                // Obtener el ID de la columna "Id"
                int idProducto = Convert.ToInt32(filaSeleccionada.Cells["IdProducto"].Value);

                // Abrir el formulario de edición pasando el ID
                var panelModificarProducto = new PanelModificarProducto(_serviceProvider, idProducto);
                panelModificarProducto.ShowDialog(); ;


            }
            else
            {
                MessageBox.Show("Por favor, seleccione un producto");
            }
        }

        private async void button3_Click(object sender, EventArgs e) //Elimiar
        {
            await EliminarProductoAsync();
        }

        public async Task EliminarProductoAsync()
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow filaSeleccionada = dataGridView1.SelectedRows[0];
                int idProducto = Convert.ToInt32(filaSeleccionada.Cells["IdProducto"].Value);

                var producto = await _productoServicios.ObtenerPorIdProducto(idProducto);

                if (producto != null)
                {
                    var confirmResult = MessageBox.Show(
                        $"¿Está seguro de que desea eliminar el producto: {producto.IdProducto}?",
                        "Confirmar eliminación",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (confirmResult == DialogResult.Yes)
                    {
                        await _productoServicios.EliminarProducto(idProducto);
                        MessageBox.Show("Producto eliminado correctamente.");
                    }
                }
                else
                {
                    MessageBox.Show("El producto no fue encontrado.");
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un producto para eliminar.");
            }
        }



        private async void button4_Click(object sender, EventArgs e)
        {
            await CargarProductoAsync();
        }

        private async void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dataGridView1.Rows[e.RowIndex];
                int idCliente = Convert.ToInt32(fila.Cells["IdProducto"].Value);



            }
        }



        public async Task CargarProductoAsync()
        {
            try
            {
                _productosOriginales = await _productoServicios.MostrarProductoAsync();
                dataGridView1.DataSource = _productosOriginales;

                if (dataGridView1.Columns.Contains("IdProducto"))
                    dataGridView1.Columns["IdProducto"].Visible = true;

                if (dataGridView1.Columns.Contains("FechaAltaProducto"))
                    dataGridView1.Columns["FechaAltaProducto"].DefaultCellStyle.Format = "dd/MM/yyyy";

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los Productos:\n{ex}");
            }
        }

        private async void PanelProductos_Load(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = true;
            await CargarProductoAsync();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void iconButton2_Click(object sender, EventArgs e) //Filtrar lupita
        {
            string columna = comboBox1.SelectedItem?.ToString();
            string filtro = textBox1.Text.Trim();

            if (string.IsNullOrEmpty(columna) || string.IsNullOrEmpty(filtro))
            {
                MessageBox.Show("Seleccioná una columna y escribí un filtro.");
                return;
            }

            IEnumerable<Producto> filtrados = _productosOriginales;

            switch (columna)
            {
                case "IdProducto":
                    if (int.TryParse(filtro, out int id))
                        filtrados = _productosOriginales.Where(c => c.IdProducto == id);
                    else
                    {
                        MessageBox.Show("El ID debe ser numérico.");
                        return;
                    }
                    break;

                case "Nombre Producto":
                    filtrados = _productosOriginales.Where(c => c.Nombre.Contains(filtro, StringComparison.OrdinalIgnoreCase));
                    break;

                case "Codigo Producto":
                    filtrados = _productosOriginales.Where(c => c.Codigo.Contains(filtro, StringComparison.OrdinalIgnoreCase));
                    break;

                default:
                    MessageBox.Show("Columna no válida.");
                    return;
            }

            dataGridView1.DataSource = filtrados.ToList();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _productosOriginales;
            comboBox1.SelectedIndex = -1;
            textBox1.Clear();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            var PanelAgregaCategoria = _serviceProvider.GetRequiredService<PanelAgregarCategoria>();
            PanelAgregaCategoria.Show();
            
        }
    }
}
