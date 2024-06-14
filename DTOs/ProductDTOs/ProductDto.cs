using FastLifePublicData;
using Marketing_api.Models;

namespace marketing_api.DTOs.ProductDTOs;


public class ProductDto
{
    public int Id { get; set; }       
    public int? SupplierID { get; set; }
    public ProductsSupplier Supplier { get; set; }
    public string? ProductName { get; set; }

    public string? Description { get; set; }
    
}