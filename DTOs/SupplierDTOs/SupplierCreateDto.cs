using System.ComponentModel.DataAnnotations;
using Marketing_api.Models;

namespace marketing_api.DTOs.SupplierDTOs;

public class SupplierCreateDto
{
    [Required]
    public string? Name { get; set; }

    public string? ContactName { get; set; }
    [EmailAddress]
    [Required]
    public string? Email { get; set; }

    [Phone]
    [Required]
    public string? Phone { get; set; }
        
    public string? Address { get; set; }
}