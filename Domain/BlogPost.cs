using Microsoft.AspNetCore.Identity;
using System;
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
        /// <summary>
        /// Comma separated tags
        /// </summary>
        public string Tags { get; set; }
    }
}
