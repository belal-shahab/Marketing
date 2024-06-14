using AutoMapper;
using marketing_api.DTOs.SupplierDTOs;
using Marketing_api.Models;
using marketing_api.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Mono.Security.X509;

namespace marketing_api.Controllers;

[ApiController]
[Route("[controller]")]
public class SupplierController : BaseController
{
    public SupplierController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }


    [HttpGet("{id:int}", Name = "GetSupplierById")]
    public async Task<ActionResult<SupplierDto>> GetSupplierById(int id)
    {
        var Supplier = await _unitOfWork.Suppliers.GetById(id);

        if (Supplier == null)
            return NotFound();

        var SupplierDto = _mapper.Map<SupplierDto>(Supplier);
        return Ok(SupplierDto);
    }


    [HttpGet]
    public async Task<ActionResult<IEnumerable<SupplierDto>>> GetSuppliers()
    {
        var Supplierdto = await _unitOfWork.Suppliers.GetAll();
        var SupplierReadDtos = _mapper.Map<IEnumerable<SupplierDto>>(Supplierdto).ToList();
        return Ok(SupplierReadDtos);
    }

    [HttpPost]
    public async Task<ActionResult<bool>> CreateSupplier([FromBody] SupplierCreateDto newSupplier)
    {
        if (newSupplier == null)
            return BadRequest();

        var supplierToCreate = _mapper.Map<Supplier>(newSupplier);

        await _unitOfWork.Suppliers.Add(supplierToCreate);
        var result = await _unitOfWork.CompleteAsync();
        return Ok(result);
    }
    

    [HttpDelete]
    public async Task<ActionResult> DeleteSupplier(int id)
    {
        await _unitOfWork.Suppliers.Delete(id);

        return Ok(await _unitOfWork.CompleteAsync());
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<SupplierDto>> PutSupplier([FromBody] SupplierUpdateDto bodyEntity, int id)
    {
        var Supplier = await _unitOfWork.Suppliers.GetById(bodyEntity.Id);

        if (Supplier == null) return BadRequest();

        var updatedContent = _mapper.Map<Supplier>(bodyEntity);
        await _unitOfWork.Suppliers.Update(updatedContent);

        await _unitOfWork.CompleteAsync();

        return Ok(_mapper.Map<SupplierDto>(updatedContent));
    }

    [HttpGet("SupplierList")]
    public async Task<IActionResult> SupplierList()
    {
        var suppliers = await _unitOfWork.Suppliers.GetAll();
        var suppliersDto = _mapper.Map<IEnumerable<SupplierListDto>>(suppliers);

        return Ok(suppliersDto);
    }
}