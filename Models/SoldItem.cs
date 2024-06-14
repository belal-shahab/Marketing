using System.ComponentModel.DataAnnotations;

namespace Marketing_api.Models;

public class SoldItem
{
    [Key]
    public int Id { get; set; }
    
    public int Quantity { get; set; }
    
    public decimal Price { get; set; }

    public decimal TotalPrice { get; set; }
    
    public int ProductId { get; set; }
    public Product? Product { get; set; }
    
    
    public int SaleId { get; set; }   
    public Sale? Sale { get; set; }
    
    public ICollection<PurchaseItemDetail>? PurchaseItemDetails { get; set; }

}