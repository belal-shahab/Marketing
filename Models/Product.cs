using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace Marketing_api.Models
{
   
    public class Product
    {
        [Key]
        public int Id { get; set; }
        
        public int SupplierID { get; set; }
        public Supplier Supplier { get; set; }
        public string? ProductName { get; set; }

        public string? Description { get; set; }
        public Stock Stock { get; set; }
        
        public ICollection<PricingList> PricingLists { get; set; }
        public ICollection<PurchaseItemDetail> PurchaseItemDetails { get; set; }
        public ICollection<PurchaseItem> PurchaseItems { get; set; }
        
    }
}