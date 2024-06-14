using marketing_api.Data;
using Marketing_api.Models;
using marketing_api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace marketing_api.Repositories;

public class StockRepository : BaseRepository<Stock> , IStockRepository
{
    public StockRepository(Marketingdbcontext dbContext, ILogger logger) : base(dbContext, logger)
    {
    }

    public override async Task<IEnumerable<Stock>> GetAll()
    {
        return await _dbSet.Include(c => c.Product).ToListAsync();
    }
}