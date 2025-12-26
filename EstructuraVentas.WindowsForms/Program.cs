using EstructuraVentas.Infraestructura.Contexto;
using EstructuraVentas.Infraestructura.Persistencia.Contexto;
using EstructuraVentas.Infraestructura.Persistencia.Interfaces;
using EstructuraVentas.Infraestructura.Persistencia.Repositories;
using EstructuraVentas.LogicaNegocio.Servicios;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using System.Configuration;

namespace EstructuraVentas.WindowsForms
{
    internal static class Program
    {

        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // 1. Cargar la configuración de appsettings.json
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            // 2. Configuramos el contenedor de servicios
            var services = new ServiceCollection();
            ConfigureServices(services, configuration);

            // 3. Construimos el ServiceProvider y ejecutamos la primera forma
            var serviceProvider = services.BuildServiceProvider();
            Application.Run(serviceProvider.GetRequiredService<PanelLogin>());
        }

        private static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            // 1. Registrar IConfiguration
            services.AddSingleton<IConfiguration>(configuration);

            // -----------------------------------------------------------------
            // 2. CONFIGURACIÓN DE MONGODB (IMongoClient e IMongoDatabase)
            // -----------------------------------------------------------------

            var connectionString = configuration.GetConnectionString("MongoDb");

            // a) Registrar IMongoClient (Singleton)
            services.AddSingleton<IMongoClient>(s =>
            {
                // Manejar posible valor nulo de GetConnectionString
                if (string.IsNullOrEmpty(connectionString))
                {
                    throw new InvalidOperationException("La cadena de conexión 'MongoDb' no está configurada en appsettings.json.");
                }
                return new MongoClient(connectionString);
            });

            // b) Registrar IMongoDatabase (Singleton)
            services.AddSingleton<IMongoDatabase>(s =>
            {
                var client = s.GetRequiredService<IMongoClient>();

                // Obtener el nombre de la base de datos de la configuración
                var databaseName = configuration.GetValue<string>("MongoDbDatabaseName");

                if (string.IsNullOrEmpty(databaseName))
                {
                    throw new InvalidOperationException("Falta la clave 'MongoDbDatabaseName' en appsettings.json.");
                }

                // 🌟 CORRECCIÓN AQUÍ 🌟
                return client.GetDatabase(databaseName);
            }); // 👈 Cierre del AddSingleton de IMongoDatabase

            // -----------------------------------------------------------------
            // 3. Repositorios y Unit Of Work
            // -----------------------------------------------------------------

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Repositorios específicos
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IProveedorRepository, ProveedorRepository>();
            services.AddScoped<CategoriaRepository>();
            // services.AddScoped<IProductRepository, ProductoRepository>();
            // services.AddScoped<IVentasRespository, VentaRepository>();

            // 4. Servicios de Lógica de Negocio
            services.AddScoped<ClienteServicios>();
            services.AddScoped<ProductoServicios>();
            services.AddScoped<UsuarioServicio>();
            services.AddScoped<ProveedorServicio>();
            services.AddScoped<CategoriaServicio>();
            services.AddScoped<VentaServicio>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ProductoServicios>();


            // 5. Formas (Paneles/Vistas)
            services.AddScoped<PanelClientes>();
            services.AddScoped<PanelProductos>();
            services.AddScoped<PanelLogin>();
            services.AddScoped<PanelDashboard>();
            services.AddScoped<PanelRegistroUsuario>();
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