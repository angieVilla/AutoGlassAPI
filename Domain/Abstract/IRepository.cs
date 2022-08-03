namespace AutoGlass;
public interface IProductRepository {
    IEnumerable<Product> Get();   
    Product GetProductByCode(int code);
    Task Insert(Product product);
    Task Update(int code,Product product);
    Task DeleteByCode(int code);
}

/* public interface ISupplierRepository {
    IEnumerable<Product> Get();
    Task<Product> GetSupplierById(Guid id);
    Task Insert(Product product);
    Task Update(Guid id,Product product);
    Task Delete(Guid id);
} */