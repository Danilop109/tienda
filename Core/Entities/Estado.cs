
namespace Core.Entities;
    public class Estado : BaseEntityA
    {
       
        public string ? NombreEstado { get; set; }
        public int IdPaisFk {get; set;}
        public Pais ? Pais {get; set;}
        public ICollection<Region> ? Regiones {get;}
    }
