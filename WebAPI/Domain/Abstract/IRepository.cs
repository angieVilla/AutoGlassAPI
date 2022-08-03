namespace AutoGlass;
public interface IProductRepository {
    IEnumerable<Product> Get();   
    Product GetProductByCode(int code);
    Task Insert(Product product);
    Task Update(int code,Product product);
    Task DeleteByCode(int code);
}

public interface ISupplierRepository {
    IEnumerable<Supplier> Get();
    Supplier GetSupplierByCode(int code);
    Task Insert(Supplier supplier);
    Task Update(int code,Supplier supplier);
    Task DeleteByCode(int code);
}