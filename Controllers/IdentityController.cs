using CSMA_API.Contracts;
using CSMA_API.Controllers.v1.Requests;
using CSMA_API.Controllers.v1.Responses;
using CSMA_API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CSMA_API.Controllers
{
    public class IdentityController : Controller
    {
        private readonly IIdentityService _identityService;

        public IdentityController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        [HttpPost(ApiRoutes.Identity.Register)]
        public async Task<IActionResult> Register([FromBody]UserRegistrationRequest registrationRequest)
        {
            var registrationResponse = await _identityService.RegisterAsync(registrationRequest.Email, registrationRequest.Password);

            if (!registrationResponse.Success)
            {
                return BadRequest(new AuthFailedResponse
                {
                    Errors = registrationResponse.Errors
                });
            }



            return Ok(new AuthSuccessResponse { 
                Token = registrationResponse.Token
            });
        }
    }
}
