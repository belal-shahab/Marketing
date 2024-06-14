using Marketing_api.Models;

namespace marketing_api.Repositories.Interfaces;

public interface IProductRepository: IBaseRepsitories<Product>
{
    Task<IEnumerable<Product>> GetSupplierProducts(int supplierId);
}