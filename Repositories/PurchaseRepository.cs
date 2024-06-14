using marketing_api.Data;
using marketing_api.DTOs.StockDTOs;
using Marketing_api.Models;
using marketing_api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace marketing_api.Repositories;

public class PurchaseRepository : BaseRepository<Purchase>, IPurchaseRepository
{
    private DbSet<PurchaseItem> _purchaseItemDbSet;
    private DbSet<PurchaseItemDetail> _purchaseItemDetailsDbSet;
    private DbSet<Product> _products;
    
    public PurchaseRepository(Marketingdbcontext dbContext, ILogger logger) : base(dbContext, logger)
    {
        _purchaseItemDetailsDbSet = _dbContext.Set<PurchaseItemDetail>();
        _purchaseItemDbSet = _dbContext.Set<PurchaseItem>();
        _products = _dbContext.Set<Product>();
    }

    
    /// <summary> 3 /// dagra
    /// returns a purchase item detail object to be sold
    /// </summary>
    /// <param name="productId">the product that needs the oldest item in stock</param>
    /// <returns>oldest purchase item for given product that is Available to sale</returns>
    public async Task<PurchaseItemDetail> GetOldestPurchaseItemDetail(int productId)
    {
        return await _purchaseItemDetailsDbSet.OrderBy(p => p.Id)
            .FirstAsync(p => p.ProductId == productId && p.Status == Status.Available);
    }

    public async Task<IEnumerable<PurchaseItemDetail>> GetOldestPurchaseItemDetails(int productId, int amount)
    {
        return await _purchaseItemDetailsDbSet.OrderBy(p => p.Id)
            .Where(p => p.ProductId == productId && p.Status == Status.Available).Take(amount).ToListAsync();    
    }
    
    /// <summary> stock = maxzan, koga
    /// returns the total available amount of given product in stock.
    /// </summary>
    /// <param name="productId"></param>
    /// <returns>total amount of given product in stock</returns>
    public async Task<int> GetTotalAvailableProductsInStock(int productId)
    {
        return await _purchaseItemDetailsDbSet.CountAsync(p => p.ProductId == productId && p.Status == Status.Available);
    }

   


    public override async Task<bool> Delete(int id)
    {
        try
        {
          // var result2 = await _dbSet.Include(p => p.PurchaseItems).FirstOrDefaultAsync(p => p.Id == id);
           var result =await  _dbSet.FirstOrDefaultAsync(purchase => purchase.Id == id);
            if (result == null) return false;
            _dbSet.Remove(result);
            return true;
        }
        catch (Exception e)
        {
            _logger.LogError(e, "{Repo} Delete function error", typeof(PurchaseRepository));
            throw;
        }
    }
    
    public override async Task<bool> Update(Purchase purchase)
    {
        try
        {
            var result = await _dbSet.FirstOrDefaultAsync(entity => entity.Id ==purchase.Id);
            if (result == null) return false;
            result.Name = purchase.Name;
            result.TotalQuantity = purchase.TotalQuantity;
            result.TotalAmount = purchase.TotalAmount;
            result.SupplierID = purchase.SupplierID;
            result.PurchaseDate = purchase.PurchaseDate;
            return true;
        }

        catch (Exception e)
        {
            _logger.LogError(e, "{Repo} Update Function Error", typeof(PurchaseRepository));
            throw;
        }
    }


    public async Task<Product> GetProductwithStock(int productId)
    {
        return await _products.Include(p => p.Stock)
            .FirstOrDefaultAsync(p => p.Id == productId);
    }

    public override async Task<IEnumerable<Purchase>> GetAll()
    {
        // Use Include to eagerly load related PurchaseItems
        return await _dbSet.Include(p => p.PurchaseItems).
            ThenInclude(pi=>pi.Product)
            .Include(p=> p.Supplier).ToListAsync();
    }
}