using AutoMapper;
using marketing_api.DTOs.SupplierDTOs;
using Marketing_api.Models;

namespace marketing_api.Helper;

public class AutoMapperSuplier: Profile
{
    public AutoMapperSuplier()
    {
        CreateMap<SupplierDto, Supplier>();
        CreateMap<Supplier, SupplierCreateDto>();
        CreateMap<SupplierCreateDto, Supplier>(); 
        CreateMap<Supplier, SupplierDto>();
        CreateMap<SupplierCreateDto, Supplier>();
        CreateMap<SupplierUpdateDto,Supplier>();
        CreateMap<Supplier, SupplierListDto>();
    }
}