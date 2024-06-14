using marketing_api.Data;
using Marketing_api.Models;
using marketing_api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace marketing_api.Repositories;

public class SupplierRepository: BaseRepository<Supplier>, ISupplierRepository
{
    public SupplierRepository(Marketingdbcontext dbContext, ILogger logger) : base(dbContext, logger)
    {

    }

    public override async Task<bool> Delete(int id)
    {
        try
        {
            var result =await  _dbSet.FirstOrDefaultAsync(Customer => Customer.Id == id);
            if (result == null) return false;
            _dbSet.Remove(result);
            return true;
        }
        catch (Exception e)
        {
            _logger.LogError(e, "{Repo} Delete function error", typeof(SupplierRepository));
            throw;
        }
    }

    public override async Task<bool> Update(Supplier supplier)
    {
        try
        {
            var result = await _dbSet.FirstOrDefaultAsync(entity => entity.Id ==supplier.Id);
            if (result == null) return false;
            result.Name = supplier.Name;
            result.ContactName = supplier.ContactName;
            result.Email = supplier.Email;
            result.Phone = supplier.Phone;
            result.Address = supplier.Address;
            return true;
        }

        catch (Exception e)
        {
            _logger.LogError(e, "{Repo} Update Function Error", typeof(SupplierRepository));
            throw;
        }
    }
}