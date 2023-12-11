using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Dtos.RequestDto;
using Service.Abstract;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BlocksController : BaseController
{
    private readonly IBlockService _blockService;

    public BlocksController(IBlockService blockService)
    {
        _blockService = blockService;
    }

    [HttpPost("add")]
    public IActionResult Add([FromBody]BlockAddRequest blockAddRequest)
    {
        var result = _blockService.Add(blockAddRequest);

        return ActionResultInstance(result);
    }

    [HttpPut]
    public IActionResult Update([FromBody]BlockUpdateRequest blockUpdateRequest)
    {
        var result = _blockService.Update(blockUpdateRequest);

        return ActionResultInstance(result);
    }

    [HttpDelete]
    public IActionResult Delete([FromQuery]int id)
    {
        var result = _blockService.Delete(id);

        return ActionResultInstance(result);
    }

    [HttpGet("getbyid")]
    public IActionResult GetById([FromQuery]int id)
    {
        var result = _blockService.GetById(id);

        return ActionResultInstance(result);
    }

    [HttpGet("getall")]
    public IActionResult GetAll()
    {
        var result = _blockService.GetAll();

        return ActionResultInstance(result);
    }
}

