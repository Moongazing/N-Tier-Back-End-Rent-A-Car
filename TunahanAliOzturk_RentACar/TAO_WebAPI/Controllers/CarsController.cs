using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TAO_Business.Abstract;
using TAO_Entities.Concrete;

namespace TAO_WebAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CarsController : ControllerBase
  {
    ICarService _carService;
    public CarsController(ICarService carService)
    {
      _carService = carService;
    }

    [HttpGet("getallcars")]
    public IActionResult GetAll()
    {
      var result = _carService.GetAll();
      if(result.Success)
      {
        return Ok(result.Data);
      }
      return BadRequest(result.Message);
    }

    [HttpGet("getcarbyid")]
    public IActionResult GetById(int carId)
    {
      var result = _carService.GetById(carId);
      if(result.Success)
      {
        return Ok(result.Data);
      }
      return BadRequest(result.Message);
    }

    [HttpPost("addcar")]
    public IActionResult Add(Car car)
    {
      var result = _carService.Add(car);
      if(result.Success)
      {
        return Ok(result.Message);
      }
      return BadRequest(result.Message);
    }

    [HttpPost("deletecar")]
    public IActionResult Delete(Car car)
    {
      var result = _carService.Delete(car);
      if(result.Success)
      {
        return Ok(result.Message);
      }
      return BadRequest(result.Message);
    }

    [HttpPost("updatecar")]
    public IActionResult Update(Car car)
    {
      var result = _carService.Update(car);
      if (result.Success)
      {
        return Ok(result.Message);
      }
      return BadRequest(result.Message);
    }
    
    [HttpGet("getbybrandid")]
    public IActionResult GetByBrandId(int brandId)
    {
      var result = _carService.GetByBrandId(brandId);
      if(result.Success)
      {
        return Ok(result.Message);
      }
      return BadRequest(result.Message);
    }

    [HttpGet("getbycolorid")]
    public IActionResult GetByColorId(int colorId)
    {
      var result = _carService.GetByBrandId(colorId);
      if (result.Success)
      {
        return Ok(result.Message);
      }
      return BadRequest(result.Message);
    }
    [HttpGet("getcardetails")]
    public IActionResult GetCarDetails()
    {
      var result = _carService.GetCarDetails();
      if(result.Success)
      {
        return Ok(result.Data);
      }
      return BadRequest(result.Message);
    }




  }
}
