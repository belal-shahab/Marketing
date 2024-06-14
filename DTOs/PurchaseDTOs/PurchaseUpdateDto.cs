using marketing_api.DTOs.PurchaseItemDTOs;
using Marketing_api.Models;

namespace marketing_api.DTOs.PurchaseDTOs;

public class PurchaseUpdateDto
{
    public int Id { get; set; }
    
    public  string? Name { get; set; }
    public int SupplierID { get; set; }
    public DateTime PurchaseDate { get; set; }
    
    public ICollection<PurchaseItemUpdateDto> PurchaseItems { get; set; }

}