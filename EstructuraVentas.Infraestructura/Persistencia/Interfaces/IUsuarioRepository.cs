using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EstructuraVentas.Dominio.Modelos;
using EstructuraVentas.Infraestructura.Contexto;
using EstructuraVentas.Infraestructura.Persistencia.Interfaces;

namespace EstructuraVentas.Infraestructura.Contexto
{
    public interface IUsuarioRepository:IGenericRepository<Usuario>
    {
        Task<Usuario?> ObtenerPorNombreUsuarioAsync(string nombreUsuario);
    }
}