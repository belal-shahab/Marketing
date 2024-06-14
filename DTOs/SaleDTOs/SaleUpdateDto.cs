namespace marketing_api.DTOs.SaleDTOs;

public class SaleUpdateDto
{
    public int Id { get; set; }
    
    public string Code { get; set; }
    
    public DateTime DateTime { get; set; }
    
    public int TotalQuantity { get; set; }

    public decimal TotalPrice { get; set; }
    
    public int SoldItemId { get; set; }
}