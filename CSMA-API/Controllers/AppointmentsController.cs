using CSMA_API.Application.Commands;
using CSMA_API.Application.Handlers.Commands;
using CSMA_API.Application.Queries;
using Microsoft.AspNetCore.Mvc;

namespace CSMA_API.Controllers
{
    public class AppointmentsController : ApiBaseController
    {
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllAppointmentsQuery()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetAppointmentByIdQuery(id)));
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateAppointmentCommand command)
        {
            var result = await Mediator.Send(command);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateAppointmentCommand command)
        {
            var updated = await Mediator.Send(command);

            return updated ? Ok() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await Mediator.Send(new DeleteAppointmentCommand(id));

            return deleted ? Ok() : NotFound();
        }
    }
}
