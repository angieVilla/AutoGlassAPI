namespace AutoGlass;
public class SupplierRepository : ISupplierRepository
{
    DataContext context;
    public SupplierRepository(DataContext dbcontext)
    {
        context = dbcontext;
    }

    public IEnumerable<Supplier> Get()
    {
        return context.Suppliers;
    }

    public Supplier GetSupplierByCode(int code)
    {
        var currentSupplier = context.Suppliers.FirstOrDefault(p=> p.Code == code);

        if (currentSupplier != null)
        {
            return currentSupplier;
        }
        return null;
    }

    public async Task Insert(Supplier Supplier)
    {
        context.Add(Supplier);
        await context.SaveChangesAsync();
    }

    public async Task Update(int code, Supplier Supplier)
    {
        var currentSupplier = context.Suppliers.FirstOrDefault(p=> p.Code == code);

        if (currentSupplier != null)
        {            
            currentSupplier.Code = Supplier.Code;
            currentSupplier.Description = Supplier.Description;
            currentSupplier.PhoneNumber = Supplier.PhoneNumber;
            await context.SaveChangesAsync();
        }
    }

    public async Task DeleteByCode(int code)
    {
        var currentSupplier = context.Suppliers.FirstOrDefault(p=> p.Code == code);

        if (currentSupplier != null)
        {
            context.Remove(currentSupplier);
            await context.SaveChangesAsync();
        }
    }
}