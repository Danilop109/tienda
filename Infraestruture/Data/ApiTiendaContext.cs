using Microsoft.EntityFrameworkCore;
using Core.Entities;
using System.Reflection;

namespace Infraestruture.Data;
    public class ApiTiendaContext : DbContext
    {
        public ApiTiendaContext(DbContextOptions<ApiTiendaContext> options) : base(options)
        {
        }

        public DbSet<Pais> Paises {get; set;}
        public DbSet<Estado> Estados {get; set;}
        public DbSet<Region> Regiones {get; set;}
        public DbSet<Persona> Personas {get; set;}
        public DbSet<Producto> Productos {get; set;}

        public DbSet<TipoPersona> TipoPersonas {get; set;}

        public DbSet<ProductoPersona> ProductosPersonas {get; set;}


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TipoPersona>().HasKey(p => p.IdTipoPer);
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
