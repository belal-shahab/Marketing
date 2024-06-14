using marketing_api.DTOs.SaleDTOs;
using Marketing_api.Models;

namespace marketing_api.DTOs.SoldItemDTOs;

public class SoldItemCreateDto
{
    public int ProductId { get; set; }

    public int Quantity { get; set; }
}