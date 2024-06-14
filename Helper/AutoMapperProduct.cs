using AutoMapper;
using marketing_api.DTOs.ProductDTOs;
using Marketing_api.Models;

namespace marketing_api.Helper;

public class AutoMapperProduct: Profile
{
   
   public AutoMapperProduct()
   {
      CreateMap<ProductDto, Product>();
      CreateMap<Supplier, ProductsSupplier>();
      CreateMap<ProductsSupplier, ProductDto>();
      CreateMap<Product, ProductCreateDto>();
      CreateMap<Product, ProductDto>();
      CreateMap<ProductCreateDto, Product>();
      CreateMap<ProductUpdateDto, Product>();
   } 
}