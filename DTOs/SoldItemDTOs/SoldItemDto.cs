using marketing_api.DTOs.SaleDTOs;
using Marketing_api.Models;

namespace marketing_api.DTOs.SoldItemDTOs;

public class SoldItemDto
{
    
    public int Quantity { get; set; }
    
    public decimal Price { get; set; }

    public decimal TotalPrice { get; set; }
    
    public int ProductId { get; set; }
    
    public int SaleId { get; set; }
    public GetSaleDto Sale { get; set; }
}