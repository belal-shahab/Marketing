using AutoMapper;
using Common.Basies.Maps;
using FastLifePublicData;
using marketing_api.DTOs.PricingListDTOs;
using Marketing_api.Models;

namespace marketing_api.Helper;

public class AutoMapperPricingList: Profile
{
        public AutoMapperPricingList()
        {
                CreateMap<PricingListDto, PricingList>();
                CreateMap<Product,ProductPriceDto>();
                CreateMap<PricingListUpdateDto, PricingList>();
                CreateMap<PricingList, PricingListDto>();
                CreateMap<PricingList, PricingListCreateDto>();
                CreateMap<PricingListCreateDto,PricingList>();
        }
}