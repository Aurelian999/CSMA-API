using System.ComponentModel.DataAnnotations;

namespace CSMA_API.Controllers.v1.Requests
{
    public class UserLoginRequest
    {
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
