using marketing_api.Data;
using Marketing_api.Models;
using marketing_api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace marketing_api.Repositories;

public class PurchaseItemRepository: BaseRepository<PurchaseItem>, IPurchaseItemRepository
{
    public PurchaseItemRepository(Marketingdbcontext dbContext, ILogger logger) : base(dbContext, logger)
    {

    }
    
    public override async Task<bool> Delete(int id)
    {
        try
        {
            var result =await  _dbSet.FirstOrDefaultAsync(PurchaseItem => PurchaseItem.Id == id);
            if (result == null) return false;
            _dbSet.Remove(result);
            return true;
        }
        catch (Exception e)
        {
            _logger.LogError(e, "{Repo} Delete function error", typeof(PurchaseItemRepository));
            throw;
        }
    }

   
    public override async Task<bool> Update(PurchaseItem purchaseItem)
    {
        try
        {
            var result = await _dbSet.FirstOrDefaultAsync(entity => entity.Id ==purchaseItem.Id);
            if (result == null) return false;
            result.PurchaseID = purchaseItem.PurchaseID;
            result.ProductID = purchaseItem.ProductID;
            result.Price = purchaseItem.Price;
            result.TotalQuantity = purchaseItem.TotalQuantity;
            result.TotalAmount = purchaseItem.TotalAmount;
            return true;
        }

        catch (Exception e)
        {
            _logger.LogError(e, "{Repo} Update Function Error", typeof(PurchaseItemRepository));
            throw;
        }
    }
}