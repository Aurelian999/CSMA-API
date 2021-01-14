using System.Collections.Generic;

namespace CSMA_API.Controllers.v1.Responses
{
    public class AuthFailedResponse
    {
        public IEnumerable<string> Errors { get; set; }
    }
}
