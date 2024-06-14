using AutoMapper;
using marketing_api.DTOs.PurchaseItemDTOs;
using Marketing_api.Models;

namespace marketing_api.Helper;

public class AutoMapperPurchaseItem: Profile
{
    public AutoMapperPurchaseItem()
    {
        CreateMap<PurchaseItemDto, PurchaseItem>();
        CreateMap<Product, GetNameProdutDto>();
        CreateMap<PurchaseItem, PurchaseItemCreateDto>();
        CreateMap<PurchaseItemCreateDto, PurchaseItemDto>();
        CreateMap<PurchaseItem, PurchaseItemDto>();
        CreateMap<PurchaseItemCreateDto, PurchaseItem>();
        CreateMap<PurchaseItemUpdateDto, PurchaseItem>();
    }
}