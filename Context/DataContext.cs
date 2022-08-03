using Microsoft.EntityFrameworkCore;

namespace AutoGlass;
    public class DataContext : DbContext
    {
        ///duda sobre la normalizacion de base de datos y la especificacion que el dbset en la bd se va a llamar Products
        public DbSet<Product> Products {get; set;}
        public DbSet<Supplier> Suppliers {get; set;}
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        
    }
