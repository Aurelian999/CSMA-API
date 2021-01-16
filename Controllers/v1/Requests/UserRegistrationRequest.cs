using System.ComponentModel.DataAnnotations;

namespace CSMA_API.Controllers.v1.Requests
{
    public class UserRegistrationRequest
    {
        //public string Name { get; set; }
        //public string Surname { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
