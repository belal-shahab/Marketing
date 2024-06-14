using AutoMapper;
using FastLifePublicData;
using marketing_api.DTOs.SoldItemDTOs;
using Marketing_api.Models;

namespace marketing_api.Helper;

public class AutoMapperSoldItem: Profile
{
    public AutoMapperSoldItem()
    {
        CreateMap<SoldItemDto, SoldItem>().ReverseMap();
        CreateMap<Sale, GetSaleDto>();
        CreateMap<SoldItem, SoldItemCreateDto>();
        CreateMap<SoldItemCreateDto, SoldItem>();
        CreateMap<SoldItemCreateDto, SoldItemDto>();
        CreateMap<SoldItemUpdateDto,Supplier>();
    }
}