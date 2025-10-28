using EstructuraVentas.Dominio;
using EstructuraVentas.Infraestructura.Commons.Bases.Request;
using EstructuraVentas.LogicaNegocio.Servicios;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using System.Windows.Forms; // Necesario para la funcionalidad de Form, MessageBox, etc.

namespace EstructuraVentas.WindowsForms
{
    public partial class PanelClientes : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private List<Cliente> _clientesOriginales;
        private ClienteFilterRequest _filtroActual = new ClienteFilterRequest(); // Almacena los filtros


        // --- Variables de Paginación ---
        private int _paginaActual = 1;
        private const int _tamanioPagina = 10; // Tamaño de página fijo
        private int _totalPaginas = 0;
        // ---------------------------------

        public PanelClientes(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            this.CenterToScreen();
        }

        private void label1_Click(object sender, EventArgs e) { }

        // Su Label de información de paginación
        private void label3_Click(object sender, EventArgs e) { }


        private async void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) //Seleccion de registro
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dataGridView1.Rows[e.RowIndex];
                int idCliente = Convert.ToInt32(fila.Cells["IDClientes"].Value);
            }
        }

        private async void PanelClientes_Load(object sender, EventArgs e)
        {
            
            dataGridView1.ReadOnly = true;
            await CargarClientesAsync();
        }

        //Botones
        private void button1_Click(object sender, EventArgs e) // Agregar
        {
            var PanelAgregaCliente = _serviceProvider.GetRequiredService<PanelAgregaCliente>();
            PanelAgregaCliente.ClienteAgregado += async (s, args) => await CargarClientesAsync();
            PanelAgregaCliente.Show();
        }

        private void button3_Click(object sender, EventArgs e) // Modificar
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow filaSeleccionada = dataGridView1.SelectedRows[0];
                int idCliente = Convert.ToInt32(filaSeleccionada.Cells["IDClientes"].Value);

                var panelModificarCliente = new PanelModificarCliente(_serviceProvider, idCliente);
                panelModificarCliente.ShowDialog();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un cliente");
            }
        }

        //--- Lógica Central de Carga y Paginación ---
        private async Task CargarClientesAsync()
        {
            try
            {
                // 1. Clonar el objeto de filtro para enviar la solicitud
                // y aplicar la paginación actual.
                // Asegúrate de que _filtroActual ya tiene los valores de TextFilter, etc.
                var filterRequest = _filtroActual;

                // 2. Establecer los valores de paginación
                filterRequest.PageIndex = _paginaActual;
                filterRequest.Records = _tamanioPagina;

                using (var scope = _serviceProvider.CreateScope())
                {
                    var clienteServiciosScoped = scope.ServiceProvider.GetRequiredService<ClienteServicios>();

                    // 2. Llamar al servicio
                    var response = await clienteServiciosScoped.MostrarClientes(filterRequest);

                    _clientesOriginales = response.Records ?? new List<Cliente>();
                    dataGridView1.DataSource = _clientesOriginales;

                    // 3. CÁLCULO CLAVE: Calcular _totalPaginas usando TotalRecords
                    if (response.TotalRecords.HasValue && response.TotalRecords.Value > 0)
                    {
                        // Se usa Math.Ceiling para redondear hacia arriba y asegurar una página para registros parciales.
                        _totalPaginas = (int)Math.Ceiling((double)response.TotalRecords.Value / _tamanioPagina);
                    }
                    else
                    {
                        _totalPaginas = 0;
                    }

                    // 4. Actualizar la UI de paginación
                    ActualizarControlesPaginacion();

                    // ... (Configuración de columnas) ...
                    if (dataGridView1.Columns.Contains("IDClientes"))
                        dataGridView1.Columns["IDClientes"].Visible = true;

                    if (dataGridView1.Columns.Contains("FechaDeRegistro"))
                        dataGridView1.Columns["FechaDeRegistro"].DefaultCellStyle.Format = "dd/MM/yyyy";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los clientes:\n{ex.Message}", "Error de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //--- Fin Lógica Central de Carga y Paginación ---

        private async void button2_Click(object sender, EventArgs e) // Eliminar
        {
            await EliminarClienteAsync();
        }

        // Funcion para eliminar (código omitido por brevedad, asumo que está correcto)
        public async Task EliminarClienteAsync()
        {
            // ... (su código de eliminación) ...
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow filaSeleccionada = dataGridView1.SelectedRows[0];
                int idCliente = Convert.ToInt32(filaSeleccionada.Cells["IDClientes"].Value);

                using (var scope = _serviceProvider.CreateScope())
                {
                    var clienteServiciosScoped = scope.ServiceProvider.GetRequiredService<ClienteServicios>();
                    var cliente = await clienteServiciosScoped.ObtenerPorIdClienteAsync(idCliente);

                    if (cliente != null)
                    {
                        var confirmResult = MessageBox.Show(
                            $"¿Está seguro de que desea eliminar el cliente: {cliente.NombreCliente}?",
                            "Confirmar eliminación",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning);

                        if (confirmResult == DialogResult.Yes)
                        {
                            await clienteServiciosScoped.EliminarClienteAsync(idCliente);
                            MessageBox.Show("Cliente eliminado correctamente.");
                            await CargarClientesAsync(); // Recargar la lista
                        }
                    }
                    else
                    {
                        MessageBox.Show("El cliente no fue encontrado.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un cliente para eliminar.");
            }
        }

        private async void button4_Click(object sender, EventArgs e) // Recargar
        {
            // Reseteamos la página a 1 al recargar la lista
            _paginaActual = 1;
            await CargarClientesAsync();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) { }

        private async void iconButton2_Click(object sender, EventArgs e) // Filtro
        {
            // 1. Aseguramos que _filtroActual sea ClienteFilterRequest (ya lo es por la declaración de la clase)
            var clienteFiltro = _filtroActual;

            // 2. Aplicar los filtros de texto (AND combinado)
            // Se asume que los TextBox existen y tienen los nombres 'txtNombreFilter', etc.
            clienteFiltro.TextFilter = txtNombre.Text.Trim(); // Para Nombre
            clienteFiltro.EmailFilter = txtEmail.Text.Trim();   // Para Email
            clienteFiltro.DocumentoFilter = txtDocumento.Text.Trim(); // Para Documento

            // 3. Aplicar el filtro de Estado
            if (cboEstado.SelectedIndex > -1)
            {
                // Mapeo directo: Activo (Index 0) -> Valor 0, Inactivo (Index 1) -> Valor 1
                clienteFiltro.StateFilter = cboEstado.SelectedIndex;
            }
            else
            {
                clienteFiltro.StateFilter = null; // No filtrar
            }

            // 4. Resetear la paginación y cargar los datos
            _paginaActual = 1;
            await CargarClientesAsync();

            MessageBox.Show("Filtros aplicados correctamente.");
        }

        private void textBox1_TextChanged(object sender, EventArgs e) { }

        private async void button5_Click(object sender, EventArgs e) // Limpiar Filtro
        {
            // 1. Resetear el objeto de filtro
            _filtroActual = new ClienteFilterRequest();

            // 2. Resetear la UI de los filtros
            txtNombre.Clear();
            txtEmail.Clear();
            txtDocumento.Clear();
            cboEstado.SelectedIndex = -1; // Deselecciona el estado

            // 3. Reiniciar la paginación y cargar (sin filtros)
            _paginaActual = 1;
            await CargarClientesAsync();

        }

        // --------------------------------------------------------------------------------
        // MÉTODOS DE PAGINACIÓN 

        private async void button7_Click(object sender, EventArgs e) // PÁGINA SIGUIENTE
        {
            if (_paginaActual < _totalPaginas)
            {
                _paginaActual++;
                await CargarClientesAsync();
            }
        }

        private async void button6_Click(object sender, EventArgs e) // PÁGINA ANTERIOR
        {
            if (_paginaActual > 1)
            {
                _paginaActual--;
                await CargarClientesAsync();
            }
        }

        private void ActualizarControlesPaginacion()
        {
            // --- Lógica para el Label (label3) ---
            if (_totalPaginas > 0)
            {
                label3.Text = $"Página {_paginaActual} de {_totalPaginas}";
            }
            else
            {
                label3.Text = "No hay clientes para mostrar.";
            }

            // --- Lógica para Botones (button6: Anterior, button7: Siguiente) ---

            // Deshabilita el botón de Anterior si estamos en la primera página
            botonAnterior.Enabled = _paginaActual > 1;

            // Deshabilita el botón de Siguiente si estamos en la última página
            botonSiguiente.Enabled = _paginaActual < _totalPaginas;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtNombreFilter_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEmailFilter_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDocumentoFilter_TextChanged(object sender, EventArgs e)
        {

        }
        // --------------------------------------------------------------------------------
    }
}