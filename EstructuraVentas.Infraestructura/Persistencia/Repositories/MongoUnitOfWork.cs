using EstructuraVentas.Dominio.Modelos;
using EstructuraVentas.Infraestructura.Persistencia.Contexto;
using EstructuraVentas.Infraestructura.Persistencia.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructuraVentas.Infraestructura.Persistencia.Repositories
{
    public class MongoUnitOfWork: IUnitOfWorkMongo
    {
        public IGenericRepositoryMongo<Proveedor> Proveedores { get; }

        public MongoUnitOfWork(MongoContext context)
        {
            Proveedores = new MongoGenericRepository<Proveedor>(
    context,    // <-- pasamos el MongoContext
    "Proveedores"
);
        }


    }
}
