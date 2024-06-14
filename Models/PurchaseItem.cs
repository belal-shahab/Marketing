using System.Collections;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NodaTime;

namespace Marketing_api.Models;

public class PurchaseItem
{
    [Key]
    public int Id { get; set; }

    public int PurchaseID { get; set; }
    public Purchase? Purchase { get; set; }
    public int ProductID { get; set; }
    public Product? Product { get; set; }
    
    public decimal Price { get; set; }

    public int TotalQuantity { get; set; }
    
    public decimal TotalAmount { get; set; }
    
    public ICollection<PurchaseItemDetail> PurchaseItemDetails { get; set;}
    
}