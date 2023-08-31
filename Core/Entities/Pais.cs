using System.Data.Common;

namespace Core.Entities;
    public class Pais : BaseEntityA
    {
        public string ? NombrePais {get; set;}
        public ICollection<Estado> ? Estados {get; set;}

    }
