using EstructuraVentas.Infraestructura.Persistencia.Contexto;
using EstructuraVentas.Infraestructura.Persistencia.Interfaces;
using EstructuraVentas.Infraestructura.Persistencia.Repositories;
using EstructuraVentas.LogicaNegocio.Servicios;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;

namespace EstructuraVentas.WindowsForms
{
    internal static class Program
    {
       
        [STAThread]
        static void Main()
        {
            
            ApplicationConfiguration.Initialize();

            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();


            // Configuramos el contenedor de servicios
            var services = new ServiceCollection();
            ConfigureServices(services, configuration);

            // Construimos el ServiceProvider
            var serviceProvider = services.BuildServiceProvider();
            Application.Run(serviceProvider.GetRequiredService<PanelLogin>());
        }
        private static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            // Cadena de conexión
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            // DbContext
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            // Repositorios y servicios
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IProductRepository, ProductoRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IProveedorRepository, ProveedorRepository>();
            services.AddScoped<CategoriaRepository>();
//services.AddScoped<IVentasRespository, VentaRepository>();

            services.AddScoped<ClienteServicios>();
            services.AddScoped<ProductoServicios>();
            services.AddScoped<UsuarioServicio>();
            services.AddScoped<ProveedorServicio>();
            services.AddScoped<CategoriaServicio>();
            services.AddScoped<VentaServicio>();

            services.AddScoped<PanelClientes>();
            services.AddScoped<PanelProductos>();
            services.AddScoped<PanelLogin>();
            services.AddScoped<PanelDashboard>();
            services.AddScoped<PanelRegistroUsuario>();
            services.AddScoped<PanelProductos>();
            services.AddScoped<PanelVentas>();
            services.AddScoped<PanelProveedores>();
            services.AddScoped<PanelAgregarProveedor>();
            services.AddScoped<PanelEditarProveedor>();
            services.AddScoped<PanelAgregaCliente>();
            services.AddScoped<PanelModificarCliente>();
            services.AddScoped<PanelAgregaProducto>();
            services.AddScoped<PanelModificarProducto>();
            services.AddScoped<PanelCompras>();
            services.AddScoped<PanelAgregarCategoria>();
            services.AddScoped<PanelAgregarVentas>();

        }
    }
}