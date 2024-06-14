using Marketing_api.Models;

namespace marketing_api.DTOs.PurchaseItemDTOs;

public class PurchaseItemDto
{
    public int? ProductID { get; set; }
    public GetNameProdutDto Product { get; set; }
    public decimal? Price { get; set; }
    public int TotalQuantity { get; set; }
    public decimal? TotalAmount { get; set; }
}