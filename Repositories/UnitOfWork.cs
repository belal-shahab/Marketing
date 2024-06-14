using marketing_api.Data;
using Marketing_api.Models;
using marketing_api.Repositories.Interfaces;

namespace marketing_api.Repositories;

public class UnitOfWork : IUnitOfWork, IDisposable
{ 
    //public ILanguageRepository Languages { get; } abe awa bam shewaya zyade bkay
    public ISupplierRepository Suppliers { get; set; }
    public IProductRepository Products { get; set; }
    public IPurchaseRepository Purchases { get; set; }
    public IPurchaseItemRepository PurchaseItems { get; set; }
    public IPurchaseItemDetailReository PurchaseItemDetails { get; set; }
    public IPricingListRepository PricingLists { get; set; }
    public ISoldItemRepository SoldItems { get; set; }
    public ISaleRepository Sales { get; set; }
    public IStockRepository Stock { get; set; }
    private readonly Marketingdbcontext _dbContext;
    public UnitOfWork(Marketingdbcontext dbContext, ILoggerFactory loggerFactory)
    {
        _dbContext = dbContext;
            
        var logger = loggerFactory.CreateLogger("logs");

        //Languages = new LanguageRepository(_dbContext, logger); abe awa bam shewaya zyade bkay 
        Suppliers = new SupplierRepository(_dbContext, logger);
        Products = new ProductRepository(_dbContext, logger);
        Purchases = new PurchaseRepository(_dbContext, logger);
        PurchaseItems = new PurchaseItemRepository(_dbContext, logger);
        PurchaseItemDetails = new PurchaseItemDetailRepository(_dbContext, logger);
        PricingLists = new PricingListRepository(_dbContext, logger);
        SoldItems = new SoldItemRepository(_dbContext, logger);
        Sales = new SaleRepository(_dbContext, logger);
        Stock = new StockRepository(_dbContext, logger);
    }

    public async Task<bool> CompleteAsync()
    {
        var result = await _dbContext.SaveChangesAsync();
        return result > 0;
    }

    public void Dispose()
    {
        _dbContext.Dispose();
    }
}