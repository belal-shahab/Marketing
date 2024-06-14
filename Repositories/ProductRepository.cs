using marketing_api.Data;
using Marketing_api.Models;
using marketing_api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace marketing_api.Repositories;

public class ProductRepository: BaseRepository<Product>, IProductRepository
{
    public ProductRepository(Marketingdbcontext dbContext, ILogger logger) : base(dbContext, logger)
    {

    }

    public override async Task<Product?> GetById(int id)
    {
        return await _dbSet.Include(s =>s.Supplier).FirstOrDefaultAsync(product => product.Id==id);
    }


    public async Task<IEnumerable<Product>> GetSupplierProducts(int supplierId)
    {
        return await FindAll(p => p.SupplierID == supplierId);
    }
    
    public override async Task<bool> Delete(int id)
    {
        try
        {
            var result =await  _dbSet.FirstOrDefaultAsync(Product => Product.Id == id);
            if (result == null) return false;
            _dbSet.Remove(result);
            return true;
        }
        catch (Exception e)
        {
            _logger.LogError(e, "{Repo} Delete function error", typeof(ProductRepository));
            throw;
        }
    }

    public override async Task<bool> Update(Product product)
    {
        try
        {
            var result = await _dbSet.FirstOrDefaultAsync(entity => entity.Id ==product.Id);
            if (result == null) return false;
            result.ProductName = product.ProductName;
            result.Description = product.Description;
            return true;
        }

        catch (Exception e)
        {
            _logger.LogError(e, "{Repo} Update Function Error", typeof(ProductRepository));
            throw;
        }
    }
}