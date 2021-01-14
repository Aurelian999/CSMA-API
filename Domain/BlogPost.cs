using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CSMA_API.Domain
{
    public class BlogPost
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public int AuthorId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; } // TODO use html content?
        public List<string> Tags { get; set; }
    }
}
