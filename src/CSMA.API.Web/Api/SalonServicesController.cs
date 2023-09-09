using CSMA.API.Core.SalonServiceAggregate;
using CSMA.API.SharedKernel.Interfaces;
using CSMA.API.Web.ApiModels;
using Microsoft.AspNetCore.Mvc;

namespace CSMA.API.Web.Api;

public class SalonServicesController : BaseApiController
{
  private readonly IRepository<SalonService> _repository;

  public SalonServicesController(IRepository<SalonService> repository)
  {
      _repository = repository;
  }

  [HttpGet]
  public async Task<IActionResult> List()
  {
    var salonServicesDTOs = (await _repository.ListAsync())
      .Select(service => new SalonServiceDTO(service.Name, service.Price)
      {
        Id = service.Id,
        Description = service.Description,
        Duration = service.Duration,
        DisplayImage = service.DisplayImage
      }).ToList();

    return Ok(salonServicesDTOs);
  }

  //[HttpGet("{id:int}")]
  //public async Task<IActionResult> GetById(int id)
  //{
  //  // TODO
  //  return Ok();
  //}
}
