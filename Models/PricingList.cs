using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace Marketing_api.Models;

public class PricingList
{
    [Key]
    public int Id  { get; set; }
    
    public int ProductId { get; set; }
    public Product Product { get; set;}
    
    public decimal Price { get; set; }
    public decimal LastCost { get; set; }
    
    public decimal AverageCost { get; set; }
    
    public ICollection<SoldItem> SoldItems { get; set; }
}