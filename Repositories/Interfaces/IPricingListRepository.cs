using Marketing_api.Models;

namespace marketing_api.Repositories.Interfaces;

public interface IPricingListRepository: IBaseRepsitories<PricingList>
{
    decimal GetLatestPriceForProduct(int productId);
}