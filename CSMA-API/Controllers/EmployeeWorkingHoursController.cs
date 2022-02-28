using CSMA_API.Application.Queries;
using Microsoft.AspNetCore.Mvc;

namespace CSMA_API.Controllers
{
    public class EmployeeWorkingHoursController : ApiBaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllEmployeeWorkingHoursQuery()));
        }

        [HttpGet("id")] // TODO decide endpoint route
        public async Task<IActionResult> GetByEmployeeId(int employeeId)
        {
            // TODO
            throw new NotImplementedException();
        }
    }
}
