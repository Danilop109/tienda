namespace Core.Entities;
    public class Producto : BaseEntityA
    {
        
        public string ? CodInterno { get; set; }
        public string ? NombreProducto { get; set; }
        public int StockMin { get; set; }
        public int StockMax { get; set; }
        public int Stock{ get; set; }
        public double ValorVenta { get; set; }
        public ICollection<Persona> ? Personas {get; set;} = new HashSet<Persona>();
        public ICollection<ProductoPersona> ? ProductosPersonas {get; set;} 

    }
