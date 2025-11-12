using EstructuraVentas.Dominio;
using EstructuraVentas.Infraestructura.Commons.Bases.Request;
using EstructuraVentas.LogicaNegocio.Servicios;
using Microsoft.Extensions.DependencyInjection;
using System.Data;

namespace EstructuraVentas.WindowsForms
{
    public partial class PanelProductos : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private List<Producto> _productosOriginales;
        private ProductoFilterRequest _filtroActual = new ProductoFilterRequest(); // Almacena los filtros


        // --- Variables de Paginación ---
        private int _paginaActual = 1;
        private const int _tamanioPagina = 10; // Tamaño de página fijo
        private int _totalPaginas = 0;
        // ---------------------------------
        public PanelProductos(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            this.CenterToScreen();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        //Botones CRUD----------------------------------------------------------------

        //Agregar
        private void button1_Click(object sender, EventArgs e) 
        {
            var PanelAgregarProducto = _serviceProvider.GetRequiredService<PanelAgregaProducto>();
            PanelAgregarProducto.ProductoAgregado += async (s, args) => await CargarProductoAsync();
            PanelAgregarProducto.Show();
        }

        //Modificar un producto
        private void button2_Click(object sender, EventArgs e) 
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow filaSeleccionada = dataGridView1.SelectedRows[0];
                int idProducto = Convert.ToInt32(filaSeleccionada.Cells["IdProducto"].Value);

                var panelModificarProducto = new PanelModificarProducto(_serviceProvider, idProducto);
                panelModificarProducto.ShowDialog();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un producto");
            }
        }
        //Eliminar un producto
        private async void button3_Click(object sender, EventArgs e) 
        {
            await EliminarProductoAsync();
        }
        //-----------------------------------------------------------------------------

        //Funciones de los botones CRUD

        // Lógica para eliminar un producto
        public async Task EliminarProductoAsync()
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow filaSeleccionada = dataGridView1.SelectedRows[0];
                int idProducto = Convert.ToInt32(filaSeleccionada.Cells["IdProducto"].Value);

                using (var scope = _serviceProvider.CreateScope())
                {
                    var productoServiciosScoped = scope.ServiceProvider.GetRequiredService<ProductoServicios>();
                    var producto = await productoServiciosScoped.ObtenerPorIdProductoeAsync(idProducto);

                    if (producto != null)
                    {
                        var confirmResult = MessageBox.Show(
                            $"¿Está seguro de que desea eliminar el producto: {producto.Nombre}?",
                            "Confirmar eliminación",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning);

                        if (confirmResult == DialogResult.Yes)
                        {
                            await productoServiciosScoped.EliminarProducto(idProducto);
                            MessageBox.Show("Producto eliminado correctamente.");
                            await CargarProductoAsync(); // Recargar la lista
                        }
                    }
                    else
                    {
                        MessageBox.Show("El producto no fue encontrado.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un cliente para eliminar.");
            }
        }

        //Lógica para cargar productos con paginación
        public async Task CargarProductoAsync()
        {
            try
            {
                // 1. Preparar el filtro actual
                var filterRequest = _filtroActual ?? new ProductoFilterRequest();

                // 2. Aplicar los valores de paginación
                filterRequest.PageIndex = _paginaActual;
                filterRequest.Records = _tamanioPagina;

                using (var scope = _serviceProvider.CreateScope())
                {
                    var productoServiciosScoped = scope.ServiceProvider.GetRequiredService<ProductoServicios>();

                    // 3. Obtener los productos
                    var response = await productoServiciosScoped.MostrarProductos(filterRequest);

                    // 4. Cargar los productos en el DataGridView
                    _productosOriginales = response.Records ?? new List<Producto>();
                    dataGridView1.DataSource = _productosOriginales;

                    // 5. Calcular total de páginas
                    var totalRegistros = response.TotalRecords ?? 0;
                    _totalPaginas = totalRegistros > 0
                        ? (int)Math.Ceiling((double)totalRegistros / _tamanioPagina)
                        : 0;

                    // 6. Actualizar la UI de paginación
                    ActualizarControlesPaginacion();

                    // 7. Configurar columnas específicas del DataGridView
                    if (dataGridView1.Columns.Contains("IdProducto"))
                        dataGridView1.Columns["IdProducto"].HeaderText = "ID";

                    if (dataGridView1.Columns.Contains("FechaAlta"))
                        dataGridView1.Columns["FechaAlta"].DefaultCellStyle.Format = "dd/MM/yyyy";

                    if (dataGridView1.Columns.Contains("Precio"))
                        dataGridView1.Columns["Precio"].DefaultCellStyle.Format = "C2";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al cargar los productos:\n{ex.Message}",
                    "Error de Carga",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }


        // Botón Refrescar
        private async void button4_Click(object sender, EventArgs e)
        {
            await CargarProductoAsync();
        }

        // Evento al hacer clic en una celda del DataGridView
        private async void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dataGridView1.Rows[e.RowIndex];
                int idCliente = Convert.ToInt32(fila.Cells["IdProducto"].Value);

            }
        }






        // Evento al cargar el panel de productos
        private async void PanelProductos_Load(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = true;
            await CargarProductoAsync();
        }

        //Filtro de productos
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
        // Paginación - Botones Anterior y Siguiente
        private async void button7_Click(object sender, EventArgs e)
        {
            if (_paginaActual > 1)
            {
                _paginaActual--;
                await CargarProductoAsync();
            }
        }

        private async void button8_Click(object sender, EventArgs e)
        {
            if (_paginaActual < _totalPaginas)
            {
                _paginaActual++;
                await CargarProductoAsync();
            }
        }

        // Método para actualizar los controles de paginación

        private void ActualizarControlesPaginacion()
        {
            // --- Lógica para el Label (label3) ---
            if (_totalPaginas > 0)
            {
                LabelPaginacion.Text = $"Página {_paginaActual} de {_totalPaginas}";
            }
            else
            {
                LabelPaginacion.Text = "No hay Productos para mostrar.";
            }

            // --- Lógica para Botones (button6: Anterior, button7: Siguiente) ---

            // Deshabilita el botón de Anterior si estamos en la primera página
            botonAnterior.Enabled = _paginaActual > 1;

            // Deshabilita el botón de Siguiente si estamos en la última página
            botonSiguiente.Enabled = _paginaActual < _totalPaginas;
        }
    }
}
