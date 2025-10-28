using EstructuraVentas.Dominio;
using EstructuraVentas.Dominio.Modelos;
using EstructuraVentas.LogicaNegocio.Servicios;
using Microsoft.Extensions.DependencyInjection;
using OfficeOpenXml;
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
    public partial class PanelProveedores : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ProveedorServicio _proveedorServicio;
        private List<Proveedor> proveedores;
        private List<Proveedor> _proveedoresOriginales; //Para el filtro

        public PanelProveedores(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _proveedorServicio = _serviceProvider.GetRequiredService<ProveedorServicio>();
            // this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            ExcelPackage.LicenseContext = ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;


            this.CenterToScreen();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void PanelProveedores_Load(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = true;
            await CargarProveedoresAsync();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            var panelAgregarProveedor = _serviceProvider.GetRequiredService<PanelAgregarProveedor>();
            //Cuando se dispare el evento ProveedorAgregado, se ejecutará la función que llama asíncronamente a
            //CargarProveedoresAsync() para volver a cargar la lista de proveedores en el datagridview.
            //panelAgregarProveedor.ProveedorAgregado += async (s, args) => await CargarProveedoresAsync();
            panelAgregarProveedor.ShowDialog();

        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Obtener la fila seleccionada
                DataGridViewRow filaSeleccionada = dataGridView1.SelectedRows[0];

                // Obtener el ID de la columna "Id"
                int idProveedor = Convert.ToInt32(filaSeleccionada.Cells["IdProveedor"].Value);

                // Abrir el formulario de edición pasando el ID
                var panelEditarProveedor = new PanelEditarProveedor(_serviceProvider, idProveedor);
                panelEditarProveedor.ShowDialog(); ;


            }
            else
            {
                MessageBox.Show("Por favor, seleccione un proveedor para editar.");
            }
        }


        private async Task CargarProveedoresAsync()
        {
            try
            {
                //proveedores = await _proveedorServicio.mostrarProveedoresAsync(); SE REMPLAZA PARA UTILIZAR EL FILTRO
                //dataGridView1.DataSource = proveedores;
                _proveedoresOriginales = await _proveedorServicio.mostrarProveedoresAsync(); // ← importante
                dataGridView1.DataSource = _proveedoresOriginales;
                dataGridView1.ClearSelection();

                if (dataGridView1.Columns.Contains("IdProveedor"))
                    dataGridView1.Columns["IdProveedor"].Visible = true;

                if (dataGridView1.Columns.Contains("FechaDeRegistro"))
                    dataGridView1.Columns["FechaDeRegistro"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los proveedores:\n{ex.Message}\n{ex.InnerException?.Message}");
            }
        }

        private async void iconButton4_Click(object sender, EventArgs e)
        {
            await CargarProveedoresAsync();
        }

        private async void iconButton5_Click(object sender, EventArgs e)
        {
            await EliminarProveedorAsync();

        }

        public async Task EliminarProveedorAsync()
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow filaSeleccionada = dataGridView1.SelectedRows[0];
                int idProveedor = Convert.ToInt32(filaSeleccionada.Cells["IdProveedor"].Value);

                var proveedor = await _proveedorServicio.obtenerProveedorPorId(idProveedor);

                if (proveedor != null)
                {
                    var confirmResult = MessageBox.Show(
                        $"¿Está seguro de que desea eliminar el proveedor: {proveedor.CodigoProovedor}?",
                        "Confirmar eliminación",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (confirmResult == DialogResult.Yes)
                    {
                        await _proveedorServicio.EliminarProveedorAsync(idProveedor);
                        MessageBox.Show("Proveedor eliminado correctamente.");
                    }
                }
                else
                {
                    MessageBox.Show("El proveedor no fue encontrado.");
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un proveedor para eliminar.");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //private void textBox1_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        string columnaSeleccionada = comboBox1.SelectedItem?.ToString();
        //        string filtro = textBox1.Text.ToLower();

        //        // Validar columna seleccionada
        //        if (string.IsNullOrEmpty(columnaSeleccionada) ||
        //            (columnaSeleccionada != "Razon social" &&
        //             columnaSeleccionada != "CUIT" &&
        //             columnaSeleccionada != "Codigo Proveedor" &&
        //             columnaSeleccionada != "Correo"))
        //        {
        //            MessageBox.Show("Por favor seleccione una columna válida para filtrar.",
        //                            "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            return;
        //        }

        //        // Filtrar la lista
        //        List<Proveedor> proveedoresFiltrados = new List<Proveedor>(proveedores);

        //        switch (columnaSeleccionada)
        //        {
        //            case "Razon social":
        //                proveedoresFiltrados = proveedores
        //                    .Where(p => p.RazonSocial.ToLower().Contains(filtro))
        //                    .ToList();
        //                break;
        //            case "CUIT":
        //                proveedoresFiltrados = proveedores
        //                    .Where(p => p.CUIT.ToLower().Contains(filtro))
        //                    .ToList();
        //                break;
        //            case "Codigo Proveedor":
        //                proveedoresFiltrados = proveedores
        //                    .Where(p => p.CodigoProovedor.ToLower().Contains(filtro))
        //                    .ToList();
        //                break;
        //            case "Correo":
        //                proveedoresFiltrados = proveedores
        //                    .Where(p => p.Correo.ToLower().Contains(filtro))
        //                    .ToList();
        //                break;
        //        }

        //        // Mostrar resultados en la DataGridView
        //        dataGridView1.DataSource = null;
        //        dataGridView1.DataSource = proveedoresFiltrados;

        //        // Evitar el sonido "ding" de la tecla Enter
        //        e.Handled = true;
        //        e.SuppressKeyPress = true;
        //    }
        //}

        private void iconButton6_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Archivo de Excel (*.xlsx)|*.xlsx";
                saveFileDialog.FileName = "Proveedores.xlsx";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (ExcelPackage excel = new ExcelPackage())
                        {
                            var hoja = excel.Workbook.Worksheets.Add("Proveedores");

                            // Agregar encabezados
                            for (int i = 0; i < dataGridView1.Columns.Count; i++)
                            {
                                hoja.Cells[1, i + 1].Value = dataGridView1.Columns[i].HeaderText;
                                hoja.Cells[1, i + 1].Style.Font.Bold = true;
                            }

                            // Agregar datos
                            int rowIndex = 2;
                            for (int i = 0; i < dataGridView1.Rows.Count; i++)
                            {
                                if (dataGridView1.Rows[i].IsNewRow) continue;

                                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                                {
                                    var valor = dataGridView1.Rows[i].Cells[j].Value;
                                    hoja.Cells[rowIndex, j + 1].Value = valor?.ToString() ?? "";
                                }
                                rowIndex++;
                            }

                            // Ajustar ancho de columnas
                            hoja.Cells[hoja.Dimension.Address].AutoFitColumns();

                            // Guardar el archivo
                            FileInfo archivo = new FileInfo(saveFileDialog.FileName);
                            excel.SaveAs(archivo);

                            MessageBox.Show("Archivo Excel exportado correctamente.", "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al exportar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }


        }

        private void button1_Click(object sender, EventArgs e) //Limpiar filtro
        {
            dataGridView1.DataSource = _proveedoresOriginales;
            comboBox1.SelectedIndex = -1;
            textBox1.Clear();
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void iconButton2_Click(object sender, EventArgs e) //Boton lupa
        {
            string columna = comboBox1.SelectedItem?.ToString();
            string filtro = textBox1.Text.Trim();

            if (string.IsNullOrEmpty(columna) || string.IsNullOrEmpty(filtro))
            {
                MessageBox.Show("Seleccioná una columna y escribí un filtro.");
                return;
            }

            IEnumerable<Proveedor> filtrados = _proveedoresOriginales;

            switch (columna)
            {
                case "IdProveedor":
                    if (int.TryParse(filtro, out int id))
                        filtrados = _proveedoresOriginales.Where(c => c.IdProveedor == id);
                    else
                    {
                        MessageBox.Show("El ID debe ser numérico.");
                        return;
                    }
                    break;

                case "Razon Social":
                    filtrados = _proveedoresOriginales.Where(c => c.RazonSocial.Contains(filtro, StringComparison.OrdinalIgnoreCase));
                    break;

                case "CUIT":
                    filtrados = _proveedoresOriginales.Where(c => c.CUIT.Contains(filtro, StringComparison.OrdinalIgnoreCase));
                    break;

                case "Codigo Proveedor":
                    filtrados = _proveedoresOriginales.Where(c => c.CodigoProovedor.Contains(filtro, StringComparison.OrdinalIgnoreCase));
                    break;

                case "Telefono":
                    filtrados = _proveedoresOriginales.Where(c => c.Telefono.Contains(filtro, StringComparison.OrdinalIgnoreCase));
                    break;

                case "Correo":
                    filtrados = _proveedoresOriginales.Where(c => c.Correo.Contains(filtro, StringComparison.OrdinalIgnoreCase));
                    break;

                case "FechaDeRegistro":
                    if (DateTime.TryParse(filtro, out DateTime fecha))
                        filtrados = _proveedoresOriginales.Where(c => c.FechaDeRegistro.Date == fecha.Date);
                    else
                    {
                        MessageBox.Show("Formato de fecha incorrecto. Ej: 2025-06-15");
                        return;
                    }
                    break;
                default:
                    MessageBox.Show("Columna no válida.");
                    return;
            }

            dataGridView1.DataSource = filtrados.ToList();
        }
    }
}
