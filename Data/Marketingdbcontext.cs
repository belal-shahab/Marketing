using FastLifePublicData;
using Marketing_api.Models;
using Microsoft.EntityFrameworkCore;

namespace marketing_api.Data;

public class Marketingdbcontext : DbContext
{
   public Marketingdbcontext(DbContextOptions<Marketingdbcontext> options) : base(options)
   {
      
   }
   
   public DbSet<Product> Product { get; set; }
   public DbSet<Purchase> Purchases { get; set; }
   public DbSet<PurchaseItemDetail> PurchaseItemDatails { get; set; }
   public DbSet<PurchaseItem> PurchaseItems { get; set; }
   public DbSet<Supplier> Suppliers { get; set; }
   public DbSet<Sale> Sales { get; set; }
   public DbSet<SoldItem> SoldItems { get; set; }
   public DbSet<PricingList> PricingLists { get; set; }
   public DbSet<Stock> Stocks { get; set; }
}
