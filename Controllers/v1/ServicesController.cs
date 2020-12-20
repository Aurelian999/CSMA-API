using CSMA_API.Contracts;
using CSMA_API.Services;
using Microsoft.AspNetCore.Mvc;

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
    }
}
