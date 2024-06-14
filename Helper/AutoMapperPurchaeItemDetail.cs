using AutoMapper;
using marketing_api.DTOs.PurchaseItemDetail;
using marketing_api.DTOs.PurchaseItemDTOs;
using Marketing_api.Models;

namespace marketing_api.Helper;

public class AutoMapperPurchaeItemDetail: Profile
{
    public AutoMapperPurchaeItemDetail()
    {
        CreateMap<PurchaseItemDetailDto, PurchaseItemDetail>();
        CreateMap<PurchaseItemDetail, PurchaseItemCreateDto>();
        CreateMap<PurchaseItemDetail, PurchaseItemDetailDto>();
        CreateMap<PurchaseItemCreateDto, PurchaseItemDetail>();
        CreateMap<PurchaseItemDetailUpdateDto,PurchaseItemDetail>();
    }
}