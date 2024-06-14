using System.Linq.Expressions;
using FastLifePublicData;
using marketing_api.Data;
using Marketing_api.Models;
using marketing_api.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace marketing_api.Repositories;

public class PricingListRepository: BaseRepository<PricingList>, IPricingListRepository
{
    public PricingListRepository(Marketingdbcontext dbContext, ILogger logger) : base(dbContext, logger)
    {

    }

    public override async Task<IEnumerable<PricingList>> GetAll()
    {
        return  _dbSet.Include(p=>p.Product).AsEnumerable().OrderByDescending(p => p.Id).
            DistinctBy(p=>p.Product.ProductName).OrderBy(p=>p.Id).ToList();
    }

    public override async Task<PricingList?> GetById(int id)
    {
        return await _dbSet.Include(p => p.Product).
            FirstOrDefaultAsync(p => p.Id == id);
    }

    /// <summary>
    /// finds the latest price for given product
    /// </summary>
    /// <param name="productId">the product id that needs the price</param>
    /// <returns>A decimal price for a given product</returns>
    public decimal GetLatestPriceForProduct(int productId)
    {
        try
        {
            var pricingList = _dbSet.OrderByDescending(dc => dc.Id).First(pc => pc.ProductId == productId);
            return pricingList.Price;

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
        
    public override async Task<bool> Delete(int id)
    {
        try
        {
            var result = await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
            if (result is null)
                return false;
            _dbSet.Remove(result);
            return true;
            
        }
        catch (Exception e)
        {
            _logger.LogError(e, "{Repo} Delete function error", typeof(ProductRepository));
            throw;
        }
    }

    public override async Task<bool> Update(PricingList entity)
    {
        try
        {
            var result = await _dbSet.FirstOrDefaultAsync(s => s.Id == entity.Id);
            if (result == null) return false;
            result.Id = entity.Id;
            result.Price = entity.Price;
            result.ProductId = entity.ProductId;
            result.LastCost = entity.LastCost;
            result.AverageCost = entity.AverageCost;
            return true;
        }
        catch (Exception e)
        {
            _logger.LogError(e, "{Repo} Delete function error", typeof(ProductRepository));
            throw;
        }
        
    }
}