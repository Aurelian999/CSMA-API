using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CSMA_API.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ApiBaseController : ControllerBase
    {
        private IMediator _mediator;

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    }
}
