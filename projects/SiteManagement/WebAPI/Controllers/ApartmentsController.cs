using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Dtos.RequestDto;
using Service.Abstract;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ApartmentsController : BaseController
{
    private readonly IApartmentService _apartmentService;

    public ApartmentsController(IApartmentService apartmentService)
    {
        _apartmentService = apartmentService;
    }

    [HttpPost]
    public IActionResult Add([FromBody] ApartmentAddRequest apartmentAddRequest)
    {
        var result = _apartmentService.Add(apartmentAddRequest);

        return ActionResultInstance(result);
    }

    [HttpPut]
    public IActionResult Update([FromBody] ApartmentUpdateRequest apartmentUpdateRequest)
    {
        var result = _apartmentService.Update(apartmentUpdateRequest);

        return ActionResultInstance(result);
    }

    [HttpDelete]
    public IActionResult Delete([FromQuery] Guid id)
    {
        var result = _apartmentService.Delete(id);

        return ActionResultInstance(result);
    }

    [HttpGet("Getbyid")]
    public IActionResult GetById([FromQuery] Guid id)
    {
        var result = _apartmentService.GetById(id);

        return ActionResultInstance(result);
    }

    [HttpGet("getall")]
    public IActionResult GetAll()
    {
        var result = _apartmentService.GetAll();

        return ActionResultInstance(result);
    }

    [HttpGet("getbyrentrange")]
    public IActionResult GetAllByRentRange([FromQuery] int min, [FromQuery] int max)
    {
        var result = _apartmentService.GetAllByRentRange(min, max);

        return ActionResultInstance(result);
    }

    [HttpGet("getbydetailid")]
    public IActionResult GetByDetailId([FromQuery] Guid id)
    {
        var result = _apartmentService.GetByDetailId(id);

        return ActionResultInstance(result);
    }

    [HttpGet("details")]
    public IActionResult GetAllDetails()
    {
        var result = _apartmentService.GetAllDetails();

        return ActionResultInstance(result);
    }

    [HttpGet("getdetailsbyblock")]
    public IActionResult GetAllDetailsByBlockId([FromQuery] int blockId)
    {
        var result = _apartmentService.GetAllDetailsByBlockId(blockId);

        return ActionResultInstance(result);
    }
}
