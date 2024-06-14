using AutoMapper;
using marketing_api.DTOs.StockDTOs;
using Marketing_api.Models;

namespace marketing_api.Helper;

public class AutoMapperStock : Profile
{
    public AutoMapperStock()
    {
        CreateMap<Stock, StockDto>();
        CreateMap<Product, StockProductDto>();
    }
}