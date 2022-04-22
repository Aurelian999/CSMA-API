using CSMA_API.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CSMA_API.Controllers
{
    public class AccountsController : ApiBaseController
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly IMediator _mediator;

        public AccountsController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IConfiguration configuration, IMediator mediator)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserCommand request)
        {
            var result = _mediator.Send(request);

            return Ok(result);
        }
    }
}
