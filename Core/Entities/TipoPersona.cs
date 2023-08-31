
namespace Core.Entities;
    public class TipoPersona : BaseEntityA
    {
        public int IdTipoPer { get; set; }
        public string ? Descripcion {get; set;}
        
        public ICollection<Persona> ? Personas { get; set; }
    }
