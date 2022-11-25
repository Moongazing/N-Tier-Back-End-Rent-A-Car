using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using TAO_Business.Abstract;
using TAO_Entities.Concrete;

namespace TAO_WebAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class RentalsController : ControllerBase
  {
    IRentalService _rentalService;
    public RentalsController(IRentalService rentalService) 
    {
      _rentalService = rentalService;
    }

    [HttpGet("getall")]
    public IActionResult GetAllRentals()
    {
      var result = _rentalService.GetAll();
      if(result.Success)
      {
        return Ok(result.Data);
      }
      return BadRequest(result.Message);
    }
    [HttpGet("availabledate")]
    public IActionResult AvailableDate(DateTime min, DateTime max)
    {
      var result = _rentalService.AvailableDate(min, max);
      if(result.Success)
      {
        return Ok(result.Data);
      }
      return BadRequest(result.Message);
    }

    [HttpGet("getbyid")]
    public IActionResult GetById(int rentalId)
    {
      var result = _rentalService.GetById(rentalId);
      if (result.Success)
      {
        return Ok(result.Data);
      }
      return BadRequest(result.Message);
    }

    [HttpPost("add")]
    public IActionResult Add(Rental rental)
    {
      var result = _rentalService.Add(rental);
      if (result.Success)
      {
        return Ok(result.Message);
      }
      return BadRequest(result.Message);
    }
    [HttpPost("update")]
    public IActionResult Update(Rental rental)
    {
      var result = _rentalService.Update(rental);
      if (result.Success)
      {
        return Ok(result.Message);
      }
      return BadRequest(result.Message);
    }


    [HttpPost("delete")]
    public IActionResult Delete(Rental rental)
    {
      var result = _rentalService.Delete(rental);
      if (result.Success)
      {
        return Ok(result.Message);
      }
      return BadRequest(result.Message);
    }

  }
}
