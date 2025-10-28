using EstructuraVentas.Dominio;
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
    public partial class PanelAgregarVentas : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly PanelProductos _panelProducto;
        private List<Producto> _productosOriginales; // Utilizado en el filtro 
        private readonly ProductoServicios _productoServicios;
        public PanelAgregarVentas(PanelProductos panelProducto, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _panelProducto = panelProducto;
            _serviceProvider = serviceProvider;
            _productoServicios = serviceProvider.GetRequiredService<ProductoServicios>();
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) //Productos
        {
            _panelProducto.CargarProductoAsync();

        }

        private async void PanelAgregarVentas_Load(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = true;
           await CargarProductoAsync();
            
        }

        public async Task CargarProductoAsync()
        {
            try
            {
                _productosOriginales = await _productoServicios.MostrarProductoAsync();

                var productosParaMostrar = _productosOriginales.Select(p => new
                {
                    Código = p.Codigo,
                    Nombre = p.Nombre,
                    Stock = p.Stock,
                    Precio = p.Precio
                }).ToList();

                dataGridView1.DataSource = productosParaMostrar;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los Productos:\n{ex}");
            }
        }
    }
}
