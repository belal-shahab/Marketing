using System.ComponentModel.DataAnnotations;

namespace marketing_api.DTOs.PurchaseItemDTOs;

public class PurchaseItemCreateDto
{
    public int ProductID { get; set; }
    public decimal Price { get; set; }
    
    public decimal TotalQuantity { get; set; }
}