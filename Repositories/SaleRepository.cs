using Microsoft.EntityFrameworkCore;

using marketing_api.Data;
using Marketing_api.Models;
using marketing_api.Repositories.Interfaces;

namespace marketing_api.Repositories;

public class SaleRepository: BaseRepository<Sale> , ISaleRepository
{
    public SaleRepository(Marketingdbcontext dbContenxt, ILogger logger) : base(dbContenxt, logger)
    {
        
    }

    public async Task<IEnumerable<Sale>> GetAll()
    {
        // Use Include to eagerly load related PurchaseItems
        return await _dbSet
            .Include(p => p.SoldItems)
            .ToListAsync();
    }

    public async Task<Product> getStockQuantity(int id)
    {
        return await _dbContext.Product.Include(p => p.Stock).
            FirstOrDefaultAsync(p => p.Id == id);
    }
    public override async Task<bool> Delete(int id)
    {
        try
        {
            var result = await _dbSet.FirstOrDefaultAsync(s => s.Id == id);
            if (result == null) return false;
            _dbSet.Remove(result);
            return true;
        }
        catch (Exception e)
        {
            _logger.LogError(e, "{Repo} Delete function error", typeof(SaleRepository));
            throw;
        }
    }
    
    public override async Task<bool> Update(Sale entity)
    {
        try
        {
            var result = await _dbSet.FirstOrDefaultAsync(s => s.Id == entity.Id);
            if (result == null) return false;
            result.Id = entity.Id;
            result.Code = entity.Code;
            result.DateTime = entity.DateTime;
            result.TotalQuantity = entity.TotalQuantity;
            result.TotalPrice = entity.TotalPrice;
            return true;
        }
        catch (Exception e)
        {
            _logger.LogError(e, "{Repo} Delete function error", typeof(SaleRepository));
            throw;
        }
    }
}