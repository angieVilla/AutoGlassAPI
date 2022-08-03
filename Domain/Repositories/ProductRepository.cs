
namespace AutoGlass;
public class ProductRepository : IProductRepository
{
    DataContext context;
    public ProductRepository(DataContext dbcontext)
    {
        context = dbcontext;
    }

    public IEnumerable<Product> Get()
    {
        return context.Products.Where(p => p.State);
    }

    public Product GetProductByCode(int code)
    {
        var currentProduct = context.Products.FirstOrDefault(p => p.State && p.Code == code);

        if (currentProduct != null)
        {
            return currentProduct;
        }
        return null;
    }

    public async Task Insert(Product product)
    {
        context.Add(product);
        await context.SaveChangesAsync();
    }

    public async Task Update(int code, Product product)
    {
        var currentProduct = context.Products.FirstOrDefault(p=> p.Code == code);

        if (currentProduct != null)
        {
            currentProduct.Description = product.Description;
            currentProduct.State = product.State;
            currentProduct.ManufacturingDate = product.ManufacturingDate;
            currentProduct.ValidityDate = product.ValidityDate;
            currentProduct.Supplier.Code = product.Supplier.Code;
            currentProduct.Supplier.Description = product.Supplier.Description;
            currentProduct.Supplier.PhoneNumber = product.Supplier.PhoneNumber;


            await context.SaveChangesAsync();
        }
    }

    public async Task DeleteByCode(int code)
    {
        var currentProduct = context.Products.FirstOrDefault(p=> p.Code == code);

        if (currentProduct != null)
        {
            currentProduct.State = false;
            await context.SaveChangesAsync();
        }
    }
}