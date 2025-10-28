using EstructuraVentas.Dominio.Modelos;
using EstructuraVentas.LogicaNegocio.Servicios;
using Microsoft.Extensions.DependencyInjection;

namespace EstructuraVentas.WindowsForms
{
    public partial class PanelRegistroUsuario : Form
    {
        private string nombreUsuarioTexto = string.Empty;
        private string contraseñaTexto = string.Empty;
        private readonly IServiceProvider _serviceProvider;

        public PanelRegistroUsuario(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
            comboBox1.Items.AddRange(Enum.GetNames(typeof(RolDelUsuario)));
            this.CenterToScreen();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            nombreUsuarioTexto = textBox2.Text;
            contraseñaTexto = textBox1.Text;
            string rolSeleccionado = comboBox1.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(nombreUsuarioTexto))
            {
                MessageBox.Show("Debes seleccionar un nombre de usuario.");
                return;
            }

            if (string.IsNullOrEmpty(contraseñaTexto))
            {
                MessageBox.Show("Debes seleccionar una contraseña.");
                return;

            }

            if (string.IsNullOrEmpty(rolSeleccionado))
            {
                MessageBox.Show("Debes seleccionar un rol del listado.");
                return;
            }


            if (!Enum.TryParse<RolDelUsuario>(rolSeleccionado, out var rol))
            {
                MessageBox.Show("Rol seleccionado no válido.");
                return;
            }

            var nuevoUsuario = new Usuario
            {
                NombreUsuario = nombreUsuarioTexto,
                Contraseña = contraseñaTexto,
                RolDelUsuario = rol,
                Estado = Estado.Activo,
                FechaDeRegistro = DateTime.Now
            };

            try
            {
                // Obtener el servicio UsuarioServicio bajo demanda
                var usuarioServicio = _serviceProvider.GetService<UsuarioServicio>();
                if (usuarioServicio == null)
                {
                    MessageBox.Show("No se pudo obtener el servicio de usuario.");
                    return;
                }

                await usuarioServicio.RegistrarUsuarioAsync(nuevoUsuario);
                MessageBox.Show("¡Usuario registrado con éxito!");

                // Obtener el formulario PanelLoginForm bajo demanda
                var panelDashboard = _serviceProvider.GetService<PanelDashboard>();
                if (panelDashboard != null)
                {
                    panelDashboard.Show();
                }

                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar usuario: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var panelLogin = _serviceProvider.GetService<PanelLogin>();
            panelLogin.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            contraseñaTexto = textBox1.Text;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            nombreUsuarioTexto = textBox2.Text;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void PanelRegistroUsuario_Load(object sender, EventArgs e)
        {

        }
    }
}
