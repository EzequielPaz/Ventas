using EstructuraVentas.Dominio;
using EstructuraVentas.Dominio.Commons.Enums;
using EstructuraVentas.Dominio.Modelos;
using EstructuraVentas.Infraestructura.Commons.Bases.Request;
using EstructuraVentas.Infraestructura.Commons.Bases.Response;
using EstructuraVentas.Infraestructura.Persistencia.Contexto;
using EstructuraVentas.Infraestructura.Persistencia.Interfaces;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EstructuraVentas.Infraestructura.Persistencia.Repositories
{
    //Esta clase implementa la interfaz IProveedorRepository para manejar operaciones CRUD sobre la entidad Proveedor
    //dentro de una base de datos usando Entity Framework 


    public class ProveedorRepository : MongoGenericRepository<Proveedor>, IProveedorRepository
    {
        public ProveedorRepository(MongoContext context)
        : base(context, "Proveedores")
        {
        }

        
    }
}
