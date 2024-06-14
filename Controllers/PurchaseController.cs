using AutoMapper;
using marketing_api.DTOs.PurchaseDTOs;
using Marketing_api.Models;
using marketing_api.Repositories;
using marketing_api.Repositories.Interfaces;
using marketing_api.Services.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace marketing_api.Controllers;
[ApiController]
[Route("[controller]")]
public class PurchaseController: BaseController
{
    private readonly ICodeRecipeGenerator _codeRecipeGenerator;

    // private readonly IPurchaseRepository _purchaseRepository;
    public PurchaseController(IUnitOfWork unitOfWork, IMapper mapper, ICodeRecipeGenerator codeRecipeGenerator) : base(unitOfWork, mapper)
    {
        _codeRecipeGenerator = codeRecipeGenerator;
    }
    [HttpGet("{id:int}", Name = "GetPurchaseById")]
    public async Task<ActionResult<PurchaseDto>> GetPurchaseById(int id)
    {
        var purchase = await _unitOfWork.Purchases.GetById(id);
        if(purchase == null)
            return NotFound();
        
        var purchaseDto = _mapper.Map<PurchaseDto>(purchase);
        return Ok(purchaseDto);

    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PurchaseDto>>> GetPurchases()
    {
        var purchasedto =await _unitOfWork.Purchases
            .GetAll();
        var purchaseReadDtos = _mapper.Map<IEnumerable<PurchaseDto>>(purchasedto);
        return Ok(purchaseReadDtos);
    }

    [HttpPost]
    public async Task<ActionResult> CreatePurchase(PurchaseCreateDto newPurchase)
    {
        var code = _codeRecipeGenerator.GenerateCode(6);

        var purchaseToCreate = _mapper.Map<Purchase>(newPurchase);
        purchaseToCreate.Code = code;
        purchaseToCreate.PurchaseDate = DateTime.Now;
        var supplier = await _unitOfWork.Suppliers.GetById(purchaseToCreate.SupplierID);
        if (supplier == null)
        {
            return BadRequest($"Supplier with given Id is not found");
        }

        int totalQuantityPurchae = 0;
        decimal totalAmountPurchase = 0;
        

        foreach (var purchaseItem in purchaseToCreate.PurchaseItems)
        {
            // int, double, float, char, awana maka ?nuallable.
            // struct  baxoy default value haya
            // balam class default value null a loya abe ?awa bkay.
            var product = await _unitOfWork.Products.GetById(purchaseItem.ProductID);
            if (product == null)
            {
                return BadRequest($"No matching Product with given Id {purchaseItem.ProductID} is found");
            }

            var getStock = await _unitOfWork.Purchases.GetProductwithStock(purchaseItem.ProductID);
            totalQuantityPurchae += purchaseItem.TotalQuantity;
            purchaseItem.TotalAmount = purchaseItem.TotalQuantity * purchaseItem.Price;
            totalAmountPurchase += purchaseItem.TotalAmount;
            getStock.Stock.Quanitty += purchaseItem.TotalQuantity;
            
            
            //var stock = await _unitOfWork.Purchases.GetProductwithStock(purchaseItem.ProductID);

            //purchaseItem.Product.Stock.Quanitty += purchaseItem.TotalQuantity;
        }

       // stock.Stock.Quanitty = totalQuantityPurchae;
        
        
    purchaseToCreate.TotalQuantity = totalQuantityPurchae;
        purchaseToCreate.TotalAmount = totalAmountPurchase;
        var purchase = await _unitOfWork.Purchases.Add(purchaseToCreate);
        await _unitOfWork.CompleteAsync();
        if (purchase != null)
        {
            foreach (var purchaseItem in purchaseToCreate.PurchaseItems)
            {
                for (int i = 0; i < purchaseItem.TotalQuantity; i++)
                {
                    var purchaseItemDetail = new PurchaseItemDetail()
                    {
                        Status = Status.Available,
                        ProductId = purchaseItem.ProductID,
                        PurchaseItemId = purchaseItem.Id,
                        Price = purchaseItem.Price,
                    };
                    await _unitOfWork.PurchaseItemDetails.Add(purchaseItemDetail);
                }
            }
        }
        return Ok(await _unitOfWork.CompleteAsync());
    }
  
    [HttpDelete]
    public async Task<ActionResult> DeletePurchase(int id)
    {
        await _unitOfWork.Purchases.Delete(id);
        return Ok(await _unitOfWork.CompleteAsync());
    }
    
    [HttpPut("{id:int}")]
    public async Task<ActionResult<PurchaseDto>> PutPurchase([FromBody] PurchaseUpdateDto bodyEntity, int id)
    {
             
        var purchase = await _unitOfWork.Purchases.GetById(bodyEntity.Id);
             
        if (purchase == null) return BadRequest();
     
        var updatedContent = _mapper.Map<Purchase>(bodyEntity);
        await _unitOfWork.Purchases.Update(updatedContent);
     
        await _unitOfWork.CompleteAsync();
        return Ok(_mapper.Map<PurchaseDto>(updatedContent));
    }
}