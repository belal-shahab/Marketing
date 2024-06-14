using AutoMapper;
using marketing_api.DTOs.ProductDTOs;
using marketing_api.DTOs.PurchaseItemDetail;
using Marketing_api.Models;
using marketing_api.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace marketing_api.Controllers;
[ApiController]
[Route("[controller]")]
public class ProductController: BaseController
{
    public ProductController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }
    
    [HttpGet("{id}", Name = "GetProductById")]
    public async Task<ActionResult<ProductDto>> GetProductById(int id)
    {
        var Product = await _unitOfWork.Products.GetById(id);
        if(Product==null)
            return NotFound();

        var ProductDto = _mapper.Map<ProductDto>(Product);
        return Ok(ProductDto);

    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts()
    {
        var Productdto = await _unitOfWork.Products.IncludeAsync(p =>p.Supplier);
        var ProductReadDtos = _mapper.Map<IEnumerable<ProductDto>>(Productdto).ToList();
        return Ok(ProductReadDtos);
    }
    
    [HttpPost]
    public async Task<ActionResult<ProductDto>> CreateProduct([FromBody] ProductCreateDto newProduct)
    {
       
        if (newProduct == null)
            return BadRequest();

        var supplier =await _unitOfWork.Suppliers.GetById(newProduct.SupplierID.Value);
        if (supplier == null)
        {
            return BadRequest("Please provide a valid supplier id");
        }

        var productToCreate = _mapper.Map<Product>(newProduct);
            
         await _unitOfWork.Products.Add(productToCreate);

         _unitOfWork.Stock.Add(new Stock()
         {
             Product = productToCreate,
             Quanitty = 0
         });

        return Ok(await _unitOfWork.CompleteAsync());

    }

    [HttpGet("SupplierProducts")]
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetSupplierProducts(int supplierId)
    {
        var suppllierProducts = await _unitOfWork.Products.GetSupplierProducts(supplierId);
        var respones = _mapper.Map<IEnumerable<ProductDto>>(suppllierProducts);
        return Ok(respones);
    }

    [HttpDelete]
    public async Task<ActionResult> DeleteProduct(int id)
    {

        await _unitOfWork.Products.Delete(id);
            
        return Ok(await _unitOfWork.CompleteAsync());
    }
    
    [HttpPut("{id}")]
    public async Task<ActionResult<ProductDto>> PutProduct([FromBody] ProductUpdateDto bodyEntity)
    {
             
        var Product = await _unitOfWork.Products.GetById(bodyEntity.Id);

        if (Product == null) return BadRequest();
     
        var updatedContent = _mapper.Map<Product>(bodyEntity);
        await _unitOfWork.Products.Update(updatedContent);
        await _unitOfWork.CompleteAsync();
     
        return Ok(_mapper.Map<ProductDto>(updatedContent));
    }
}