using marketing_api.Data;
using Marketing_api.Models;
using marketing_api.Repositories.Interfaces;

namespace marketing_api.Repositories;

public class PurchaseItemDetailRepository: BaseRepository<PurchaseItemDetail>, IPurchaseItemDetailReository
{
    public PurchaseItemDetailRepository(Marketingdbcontext dbContext, ILogger logger) : base(dbContext, logger)
    {

    }    
}