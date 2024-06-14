using AutoMapper;
using marketing_api.DTOs.PurchaseDTOs;
using Marketing_api.Models;

namespace marketing_api.Helper;

public class AutoMapperPurchase : Profile
{
    public AutoMapperPurchase()
    {
        CreateMap<PurchaseItem, PurchaseDto>();
        CreateMap<PurchaseDto, Purchase>();
        CreateMap<Supplier, SupplierNameDto>();
        CreateMap<Purchase, PurchaseCreateDto>();
        CreateMap<PurchaseCreateDto, PurchaseDto>(); 
        CreateMap<Purchase, PurchaseDto>();
        CreateMap<PurchaseCreateDto, Purchase>();
        CreateMap<PurchaseUpdateDto, Purchase>();
    } 
}