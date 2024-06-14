using System.Data.Entity;
using marketing_api.Data;
using Marketing_api.Models;
using marketing_api.Repositories.Interfaces;

namespace marketing_api.Repositories;

public class SoldItemRepository: BaseRepository<SoldItem>, ISoldItemRepository
{
    public SoldItemRepository(Marketingdbcontext dbContext, ILogger logger) : base(dbContext, logger)
    {
        
    }

    public override async Task<bool> Delete(int id)
    {
        try
        {
            var result = await _dbSet.FirstOrDefaultAsync(s => s.Id == id);
            if (result is null) return false;
            _dbSet.Remove(result);
            return true;    
        }
        catch (Exception e)
        {
            _logger.LogError(e, "{Repo} Delete function error", typeof(ProductRepository));
            throw;
        }
        
    }

    public override async Task<bool> Update(SoldItem entity)
    {
        try
        {
            var result = await _dbSet.FirstOrDefaultAsync(s => s.Id == entity.Id);
            result.Id = entity.Id;
            result.Quantity = entity.Quantity;
            result.Price = entity.Price;
            result.TotalPrice = entity.TotalPrice;
            result.ProductId = entity.ProductId;
            return true;
        }
        catch (Exception e)
        {
            _logger.LogError(e, "{Repo} Delete function error", typeof(ProductRepository));
            throw;
        }
        
    }
    
}