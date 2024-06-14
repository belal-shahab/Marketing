using marketing_api.DTOs.PurchaseItemDTOs;
using Marketing_api.Models;

namespace marketing_api.DTOs.PurchaseDTOs;

public class PurchaseDto
{
    public int Id { get; set; }
    public int? SupplierID { get; set; }
    public SupplierNameDto Supplier { get; set; }
     public  string? Name { get; set; }
     public  string Code { get; set; }
     public int TotalQuantity { get; set; }
     public int TotalAmount { get; set; }
     public DateTime PurchaseDate { get; set; } 
     
    public ICollection<PurchaseItemDto> PurchaseItems { get; set; }
}