using System.ComponentModel.DataAnnotations;

namespace Marketing_api.Models;

public class PurchaseItemDetail
{
    [Key]
    public int Id { get; set; }
    
    public int? ProductId { get; set; }
    public Product? Product { get; set; }
    
    public int? PurchaseItemId { get; set; }
    public PurchaseItem? PurchaseItem { get; set; } 
    
    public DateTime? ExpiryDate { get; set; }
    public decimal? Price { get; set; }
    public Status Status { get; set; }
    
    public SoldItem? SoldItem { get; set; } 
    public int? SoldItemId { get; set; }
}

public enum Status
{
    Available,
    Sold
}
// struct vs class
// enum 
