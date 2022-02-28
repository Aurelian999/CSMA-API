using CSMA_API.Application.Commands;
using CSMA_API.Application.Queries;
using Microsoft.AspNetCore.Mvc;

namespace CSMA_API.Controllers
{
    public class ServicesController : ApiBaseController
    {
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllServicesQuery()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetServiceByIdQuery(id)));
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateServiceCommand command)
        {
            var result = await Mediator.Send(command);

            return Ok(result);
        }

        //[HttpPut]
        //public async Task<IActionResult> Update([FromBody] UpdateAppointmentCommand command)
        //{
        //    var updated = await Mediator.Send(command);

        //    return updated ? Ok() : NotFound();
        //}

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await Mediator.Send(new DeleteServiceCommand(id));

            if (!result.Succeeded)
            {
                return StatusCode(result.StatusCode, result.Errors);
            }

            return Ok(result);
        }
    }
}
