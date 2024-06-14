using marketing_api.DTOs.SoldItemDTOs;

namespace marketing_api.DTOs.SaleDTOs;

public class SaleCreateDto
{
    public ICollection<SoldItemCreateDto> SoldItems { get; set; }
}