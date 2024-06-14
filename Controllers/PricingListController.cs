using AutoMapper;
using marketing_api.Data;
using marketing_api.DTOs.PricingListDTOs;
using Marketing_api.Models;
using marketing_api.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace marketing_api.Controllers;
[ApiController]
[Route("[controller]")]
public class PricingListController: BaseController
{
    public PricingListController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
        
    }
    
    [HttpGet("{id:int}")]
    public async Task<ActionResult<PricingListDto>> getpricinglistid(int id)
    {
        var result = await _unitOfWork.PricingLists.GetById(id);
        if (result == null) return BadRequest();
        var pricinglist = _mapper.Map<PricingListDto>(result);
        return Ok(pricinglist);
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<PricingListDto>>> GetPricingListId()
    {
        var result = await _unitOfWork.PricingLists.GetAll();
        var pricinglist = _mapper.Map<IEnumerable<PricingListDto>>(result).ToList();
        return Ok(pricinglist);
    }
    
    [HttpPost]
    public async Task<ActionResult> CreatePricingList(PricingListCreateDto pricingListcreate)
    {
        if (pricingListcreate == null) return BadRequest();
        var pricinglist = _mapper.Map<PricingList>(pricingListcreate);
        pricinglist.LastCost = pricinglist.Price * 9;
        pricinglist.AverageCost = pricinglist.LastCost * 5;
        await _unitOfWork.PricingLists.Add(pricinglist);
        return Ok(await _unitOfWork.CompleteAsync());
    }
    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeletePricingList(int id)
    {
         await _unitOfWork.PricingLists.Delete(id);
         return Ok(await _unitOfWork.CompleteAsync());
    }
    [HttpPut("{id:int}")]
    public async Task<ActionResult<PricingListDto>> UpdatePricingLidt([FromBody] PricingListUpdateDto pricingListUpdateDto,int id)
    {
        if (pricingListUpdateDto == null) return BadRequest();
       await _unitOfWork.PricingLists.GetById(pricingListUpdateDto.Id);
       var result = _mapper.Map<PricingList>(pricingListUpdateDto);
       await _unitOfWork.PricingLists.Update(result);
       await _unitOfWork.CompleteAsync();
       return Ok(_mapper.Map<PricingListDto>(result));
    }
}