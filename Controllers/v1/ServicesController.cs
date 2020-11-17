using System.Collections.Generic;
using CSMA_API.Contracts;
using CSMA_API.Domain;
using Microsoft.AspNetCore.Mvc;

namespace CSMA_API.Controllers.v1
{
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private List<Service> _services;

        public ServicesController()
        {
            _services = new List<Service>();
            for (int i = 0; i < 9; i++)
            {
                _services.Add(new Service { Id = i, Name = "Masaj" + i, Price = i * 20, Duration = i * 10, Description = "Title" + i });
            }
        }

        [HttpGet(ApiRoutes.Services.GetAll)]
        public IActionResult GetAll()
        {
            return Ok(_services);
        }
    }
}
