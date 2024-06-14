using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Marketing_api.Models;

public class Purchase
{
   

    [Key]
    public int Id { get; set; }
    
    public string? Name { get; set; }
    public string Code { get; set; } 

    public int TotalQuantity { get; set; }

    public decimal TotalAmount { get; set; }
    public DateTime PurchaseDate { get; set; }
    
    public int SupplierID { get; set; }
    public Supplier? Supplier { get; set; }
    
    
   public ICollection<PurchaseItem> PurchaseItems { get; set; }
}