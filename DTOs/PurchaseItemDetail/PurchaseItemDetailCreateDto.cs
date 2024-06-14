using Marketing_api.Models;

namespace marketing_api.DTOs.PurchaseItemDetail;

public class PurchaseItemDetailCreateDto
{
    
    public DateTime? ExpiryDate { get; set; }
    public decimal? Price { get; set; } 
    public string? Status { get; set; }
}