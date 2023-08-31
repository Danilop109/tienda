using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Interfaces;
    public interface IUnitOfWork
    {
        IPaisInterfase Paises {get; }
        // ITipoPersona TipoPersonas {get; }
        // IProducto Productos {get; }
        // IRegion Regiones {get; }
        Task <int> SaveAsync();
    }
