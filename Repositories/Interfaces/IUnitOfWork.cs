namespace marketing_api.Repositories.Interfaces;

public interface IUnitOfWork
{
    //ILanguageRepository Languages { get; } abe bam shewaya zyade bkay
    ISupplierRepository Suppliers { get; set; }
    IProductRepository Products { get; set; }
    IPurchaseRepository Purchases { get; set; }
   IPurchaseItemRepository PurchaseItems { get; set; }
   IPurchaseItemDetailReository PurchaseItemDetails { get; set; }
   ISoldItemRepository SoldItems { get; set; }    
   ISaleRepository Sales { get; set; }
   IPricingListRepository PricingLists { get; set; }
   IStockRepository Stock { get; set; }
    Task<bool> CompleteAsync();
}