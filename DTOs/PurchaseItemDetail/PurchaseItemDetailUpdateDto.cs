namespace marketing_api.DTOs.PurchaseItemDetail;

public class PurchaseItemDetailUpdateDto
{
    public int Id { get; set; }
    public int? ProductId { get; set; }
    
    public int? PurchaseItemId { get; set; }
    public DateTime? ExpiryDate { get; set; }
    public decimal? Price { get; set; }
    public string? Status { get; set; }
}