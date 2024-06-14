namespace marketing_api.DTOs.ProductDTOs;

public class ProductCreateDto
{
        
    public int? SupplierID { get; set; }
    
    public string? ProductName { get; set; }

    public string? Description { get; set; }
}