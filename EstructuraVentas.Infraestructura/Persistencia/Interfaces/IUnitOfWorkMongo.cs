using EstructuraVentas.Dominio.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructuraVentas.Infraestructura.Persistencia.Interfaces
{
    public interface IUnitOfWorkMongo
    {
        IGenericRepositoryMongo<Proveedor> Proveedores { get; }
    }
}
