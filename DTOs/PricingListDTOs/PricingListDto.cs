using Newtonsoft.Json;

namespace marketing_api.DTOs.PricingListDTOs;

public class PricingListDto
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public ProductPriceDto Product { get; set; }
    public decimal Price { get; set; }

    public decimal LastCost { get; set; }
    
    public decimal AverageCost { get; set; }
}