using AutoMapper;
using marketing_api.DTOs.SaleDTOs;
using marketing_api.DTOs.SoldItemDTOs;
using Marketing_api.Models;
using marketing_api.Repositories;
using marketing_api.Repositories.Interfaces;
using marketing_api.Services.Core.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace marketing_api.Controllers;
[ApiController]
[Route("[controller]")]
public class SaleController: BaseController 
{
    private readonly ICodeRecipeGenerator _codeRecipeGenerator;

    public SaleController(IUnitOfWork _unitOfWork, IMapper _mapper, ICodeRecipeGenerator codeRecipeGenerator) : base(_unitOfWork, _mapper)
    {
        _codeRecipeGenerator = codeRecipeGenerator;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<SoldItemDto>>> GetSoldtItemList()
    {
        var soldItems = await  _unitOfWork.SoldItems.IncludeAsync(s=>s.Sale);
        var saleDtos = _mapper.Map<IEnumerable<SoldItemDto>>(soldItems).ToList();
        return Ok(saleDtos);
    }
    
    [HttpGet("{id:int}")]
    public async Task<ActionResult<SoldItemDto>> GetSoldItemId(int id)
    {
        var result = await _unitOfWork.SoldItems.GetById(id);
        if (result == null) return BadRequest();

        var solditemall = _mapper.Map<SoldItemDto>(result);
        return Ok(solditemall);
    }
    
    [HttpPost]
    public async Task<ActionResult<bool>> SoldItemCreate([FromBody] SaleCreateDto saleCreate)
    {
        if (saleCreate == null) return BadRequest();
        
        
        
        var code = _codeRecipeGenerator.GenerateCode(6);
        var sale = _mapper.Map<Sale>(saleCreate);

        var totalquantity = 0;
        decimal totalprice = 0;
        
        foreach (var soldItem in sale.SoldItems)
        {
            var totalAvailableQuantity = await _unitOfWork.Purchases.GetTotalAvailableProductsInStock(soldItem.ProductId);
            if (totalAvailableQuantity < soldItem.Quantity)
            {
                throw new Exception(
                    $"There is no enough quantity amount left in stock for product {soldItem.ProductId} \n" +
                    $"Currently there is only {totalAvailableQuantity} is left. ");
            }
            
            
            // setting the product price for the sold item
            soldItem.Price =_unitOfWork.PricingLists.GetLatestPriceForProduct(soldItem.ProductId);
            soldItem.TotalPrice = soldItem.Price * soldItem.Quantity;
            totalquantity += soldItem.Quantity;
            totalprice += soldItem.TotalPrice;
            var stockt2 = await _unitOfWork.Products.GetById(soldItem.ProductId);
            var stock = await _unitOfWork.Sales.getStockQuantity(soldItem.ProductId);
           stockt2.Stock.Quanitty -= soldItem.Quantity;
            
            var purchaseItemDetails = await 
                _unitOfWork.Purchases.GetOldestPurchaseItemDetails(soldItem.ProductId, soldItem.Quantity);
            foreach (var purchaseItemDetail in purchaseItemDetails)
            {
                if (purchaseItemDetail == null)
                {
                    // proudct namwa lal maxzan bo froshtn
                    throw new ArgumentException("There is no quantity in stock for given product");
                }
                purchaseItemDetail.Status = Status.Sold;
                purchaseItemDetail.SoldItem = soldItem;
            }
         
        }
        sale.DateTime = DateTime.Now;
        sale.Code = code;
        sale.TotalQuantity = totalquantity;
        sale.TotalPrice = totalprice;
        await _unitOfWork.Sales.Add(sale);
        return Ok(await _unitOfWork.CompleteAsync());
    }
}