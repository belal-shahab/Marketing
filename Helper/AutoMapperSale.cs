using AutoMapper;
using marketing_api.DTOs.SaleDTOs;
using Marketing_api.Models;

namespace marketing_api.Helper;

public class AutoMapperSale: Profile
{
    public AutoMapperSale()
    {
        CreateMap<SaleDto, Sale>();//.ReverseMap();
        CreateMap<Sale, SaleDto>();
        CreateMap<Sale, SaleCreateDto>();
        CreateMap<SaleCreateDto, Sale>(); 
        CreateMap<SaleCreateDto, SaleDto>();
        CreateMap<SaleUpdateDto,Sale>();
    }   
}