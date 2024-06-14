namespace marketing_api.DTOs.SoldItemDTOs;

public class SoldItemUpdateDto
{
    public int Id { get; set; }
    
    public int Quantity { get; set; }
    
    public decimal Price { get; set; }

    public decimal TotalPrice { get; set; }
    
    public int ProductId { get; set; }
    
    public int PricingListId { get; set; }
    
    public int SaleId { get; set; }
    
    public int PurchaseItemDetailId { get; set; }
}