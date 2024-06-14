using System.ComponentModel.DataAnnotations;
using Marketing_api.Models;

namespace marketing_api.DTOs.SupplierDTOs;

public class SupplierDto
{
    public int Id { get; set; }
    
    public string? Name { get; set; }

    public string? ContactName { get; set; }
    
    [EmailAddress]
    public string? Email { get; set; }
    
    [Phone]
    public string? Phone { get; set; }
        
    public string? Address { get; set; }
}