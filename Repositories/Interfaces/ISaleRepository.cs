using Marketing_api.Models;

namespace marketing_api.Repositories.Interfaces;

public interface ISaleRepository: IBaseRepsitories<Sale>
{
    Task<IEnumerable<Sale>> GetAll();
    Task<Product> getStockQuantity(int id);
}