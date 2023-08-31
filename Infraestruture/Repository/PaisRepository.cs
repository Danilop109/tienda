using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infraestruture.Data;
using Microsoft.EntityFrameworkCore;

namespace Infraestruture.Repository;
    public class PaisRepository : GenericRepositoryA<Pais> , IPaisInterfase
    {
    private readonly ApiTiendaContext _context;

    public PaisRepository (ApiTiendaContext context) : base(context)
        {
            _context = context;
        
     }
        public override async Task <IEnumerable<Pais>> GetAllAsync()
        {
            return await _context.Paises
            .Include(p => p.Estados)
            .ToListAsync();
        }
        
        public override async Task<Pais> GetByIdAsync(int id)
        {
            return await _context.Paises
            .Include(p=> p.Estados)
            .FirstOrDefaultAsync(p => p.Id == id);
        }
    }