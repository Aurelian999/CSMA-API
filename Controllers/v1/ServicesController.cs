using CSMA_API.Contracts;
using CSMA_API.Contracts.v1.Requests;
using CSMA_API.Domain;
using CSMA_API.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CSMA_API.Controllers.v1
{
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IServicesService _servicesService;

        public ServicesController(IServicesService servicesService)
        {
            _servicesService = servicesService;
        }

        [HttpGet(ApiRoutes.Services.GetAll)]
        public IActionResult GetAll()
        {
            return Ok(_servicesService.GetAll());
        }

        [HttpGet(ApiRoutes.Services.Get)]
        public IActionResult GetById(int serviceId)
        {
            var service = _servicesService.GetById(serviceId);

            if (service == null)
            {
                return NotFound();
            }

            return Ok(service);
        }


        [HttpPut(ApiRoutes.Services.Update)]
        public IActionResult Update([FromRoute]int serviceId, [FromBody]UpdateServiceRequest updateServiceRequest)
        {
            var service = new Service
            {
                Id = serviceId,
                Description = updateServiceRequest.Description,
                Duration = updateServiceRequest.Duration,
                Name = updateServiceRequest.Name,
                Price = updateServiceRequest.Price,
                Sessions = updateServiceRequest.Sessions
            };

            var updated = _servicesService.UpdateService(service);

            if (updated)
            {
                return Ok(service); 
            }

            return NotFound();
        }
    }
}
