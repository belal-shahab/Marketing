namespace marketing_api.DTOs.PurchaseItemDTOs;

public class PurchaseItemUpdateDto
{
    public int Id { get; set; }
    public int? ProductID { get; set; }
    
    public decimal? Price { get; set; }

    public decimal? TotalQuantity { get; set; }
    //totalamount abe bkaya amount lanaw models 
    public decimal? TotalAmount { get; set; }
}