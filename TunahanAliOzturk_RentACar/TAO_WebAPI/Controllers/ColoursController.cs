using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TAO_Business.Abstract;
using TAO_Entities.Concrete;

namespace TAO_WebAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ColoursController : ControllerBase
  {
    IColourService _colourService;
    public ColoursController(IColourService colourService)
    {
        _colourService = colourService;
    }

    [HttpGet("getall")]
    public IActionResult GetAll()
    {
      var result = _colourService.GetAll();
      if(result.Success)
      {
        return Ok(result.Data);
      }
      return BadRequest(result.Message);
    }

    [HttpGet("getbyid")]
    public IActionResult GetById(int colourId )
    {
      var result = _colourService.GetColor(colourId);
      if(result.Success)
      {
        return Ok(result.Data);
      }
      return BadRequest(result.Message);
    }

    [HttpPost("add")]
    public IActionResult Add(Colour colour)
    {
      var result = _colourService.Add(colour);
      if(result.Success)
      {
        return Ok(result.Message);
      }
      return BadRequest(result.Message);
    }

    [HttpPost("delete")]
    public IActionResult Delete(Colour colour)
    {
      var result = _colourService.Delete(colour);
      if (result.Success)
      {
        return Ok(result.Message);
      }
      return BadRequest(result.Message);
    }

    [HttpPost("update")]
    public IActionResult Update(Colour colour)
    {
      var result = _colourService.Update(colour);
      if (result.Success)
      {
        return Ok(result.Message);
      }
      return BadRequest(result.Message);
    }


  }
}
