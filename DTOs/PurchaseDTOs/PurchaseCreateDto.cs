using marketing_api.DTOs.PurchaseItemDetail;
using marketing_api.DTOs.PurchaseItemDTOs;
using Marketing_api.Models;

namespace marketing_api.DTOs.PurchaseDTOs;

public class PurchaseCreateDto
{
    const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
    static Random random = new Random();
    string code = new string(Enumerable.Repeat(chars, 6).Select(s => s[random.Next(s.Length)]).ToArray());
    
    public int SupplierID { get; set; }
    public string? Name { get; set; }
    public DateTime PurchaseDate { get; set; } 
    
    public ICollection<PurchaseItemCreateDto> PurchaseItems { get; set; }
    
}

