using Microsoft.EntityFrameworkCore;

namespace AutoGlass;
public class DataContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    
}
