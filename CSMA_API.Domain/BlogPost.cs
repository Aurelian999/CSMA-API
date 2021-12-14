namespace CSMA_API.Domain
{
    public class BlogPost
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string AuthorId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; } // TODO use html content?

        // TODO handle post <-> user link
        //public IdentityUser User { get; set; }
        /// <summary>
        /// Comma separated tags
        /// </summary>
        public string Tags { get; set; }
    }
}
