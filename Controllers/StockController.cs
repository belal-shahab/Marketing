using AutoMapper;
using marketing_api.Data;
using marketing_api.DTOs.StockDTOs;
using Marketing_api.Models;
using marketing_api.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace marketing_api.Controllers;

[ApiController]
[Route("[controller]")]
public class StockController : BaseController
{

    public StockController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<StockDto>>> GetStcok()
    {
        var respones = await _unitOfWork.Stock.IncludeAsync(s =>s.Product);
        var getsStock = _mapper.Map<List<StockDto>>(respones);
       return Ok(getsStock);
        
    }
}