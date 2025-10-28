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
    public partial class PanelAgregarCategoria : Form
    {
        private readonly IServiceProvider _serviceProvider;

        public PanelAgregarCategoria(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;

        }

        private void PanelAgregarCategoria_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var nombreTexto = textBox1.Text;
            var descripcion = richTextBox1.Text;

            //Validar que todos los campos estén completos
            if (string.IsNullOrEmpty(nombreTexto) ||
                string.IsNullOrEmpty(descripcion))
             
            {
                MessageBox.Show("Debes llenar todos los campos.");
                return;
            }

            var nuevaCategoria = new Categoria
            {
                Nombre = nombreTexto,
                Descripcion = descripcion
            };

            try
            {
                var categoriaServicio = _serviceProvider.GetService<CategoriaServicio>();
                await categoriaServicio.AgregarCategoria(nuevaCategoria);
                MessageBox.Show("¡Categoria registrada con éxito!");
                LimpiarCampos();
                this.Hide();

            }

            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar categoria: " + ex.Message);
            }
        }

        private void LimpiarCampos()
        {
            textBox1.Clear();
            richTextBox1.Clear();
        }
    }
}
