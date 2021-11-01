using System;

namespace CSMA_API.Controllers.v1.Requests
{
    public class CreateBlogPostRequest
    {
        public DateTime Date { get; set; }
        public string AuthorId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        /// <summary>
        /// Comma separated tags
        /// </summary>
        public string Tags { get; set; } 
    }
}
