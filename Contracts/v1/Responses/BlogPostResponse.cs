using System;
using System.Collections.Generic;

namespace CSMA_API.Controllers.v1.Responses
{
    public class BlogPostResponse
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string AuthorId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Tags { get; set; }
    }
}
