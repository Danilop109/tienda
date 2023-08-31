using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces;
using Infraestruture.Data;
using Infraestruture.Repository;

namespace Infraestruture.UnitOfWork;
    public class UnitOfWork : IUnitOfWork, IDisposable

    {
        private readonly ApiTiendaContext context;
        private PaisRepository _paises;

    public UnitOfWork(ApiTiendaContext _context)
    {
        context = _context;
    }

    public IPaisInterfase PaisInterfase
    {
        get {
            if(_paises == null){
                _paises = new PaisRepository(context);
            }
            return _paises;
        }
    }

    public IPaisInterfase Paises
    {
        get {
            if(_paises == null){
                _paises = new PaisRepository(context);
            }
            return _paises;
        }
    }

    // public IPaisInterfase Paises => throw new NotImplementedException();

    // public ITipoPersona TipoPersonas => throw new NotImplementedException();

    // public IProducto Productos => throw new NotImplementedException();

    // public IRegion Regiones => throw new NotImplementedException();

    public void Dispose()
    {
        context.Dispose();
    }

    public async Task<int> SaveAsync()
    {
        return await context.SaveChangesAsync();
    }
}
