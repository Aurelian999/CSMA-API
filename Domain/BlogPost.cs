using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSMA_API.Domain
{
    public class BlogPost
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string AuthorId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; } // TODO use html content?

        [ForeignKey(nameof(AuthorId))]
        public IdentityUser User { get; set; }

        // TODO find some primitive type to use instead of list, so EF can create a DB column for this
        //public List<string> Tags { get; set; } 
    }
}
