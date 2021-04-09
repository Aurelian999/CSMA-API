using System.Collections.Generic;

namespace CSMA_API.Controllers.v1.Requests
{
    public class UpdateBlogPostRequest
    {

        public string Title { get; set; }
        public string Content { get; set; }
        public List<string> Tags { get; set; }
    }
}
