using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using marketing_api.DTOs.SoldItemDTOs;

namespace Marketing_api.Models;

public class Sale
{
    [Key]
    public int Id { get; set; }
    
    public string Code { get; set; }
    
    public DateTime DateTime { get; set; }
    
    public int TotalQuantity { get; set; }

    public decimal TotalPrice { get; set; }
    
   public ICollection<SoldItem> SoldItems { get; set; }
}