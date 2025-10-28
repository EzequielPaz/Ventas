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
    public partial class PanelAgregarCompra : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ProveedorServicio _proveedorServicio;
        private readonly ProductoServicios _productoServicios;
        public PanelAgregarCompra(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _proveedorServicio = _serviceProvider.GetRequiredService<ProveedorServicio>();
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void PanelAgregarCompra_Load(object sender, EventArgs e)
        {

        }
    }
}
