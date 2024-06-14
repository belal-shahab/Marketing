using Marketing_api.Models;

namespace marketing_api.Repositories.Interfaces;

public interface IPurchaseRepository: IBaseRepsitories<Purchase>
{
    Task<PurchaseItemDetail> GetOldestPurchaseItemDetail(int productId);
    Task<IEnumerable<PurchaseItemDetail>> GetOldestPurchaseItemDetails(int productId, int amount);
    Task<int> GetTotalAvailableProductsInStock(int productId);
    Task<Product> GetProductwithStock(int productId);
    
}