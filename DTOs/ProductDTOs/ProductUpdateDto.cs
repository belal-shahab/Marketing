namespace marketing_api.DTOs.ProductDTOs;

public class ProductUpdateDto
{
    public int Id { get; set; }
        
    public int? SupplierID { get; set; }
    
    public string? ProductName { get; set; }

    public string? Description { get; set; }
    
}