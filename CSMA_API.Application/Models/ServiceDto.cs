namespace CSMA_API.Application.Models
{
    public class ServiceDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        /// <summary>
        /// Ammount of time in minutes
        /// </summary>
        public int Duration { get; set; }
        public string Description { get; set; }
        public int Sessions { get; set; }
        public byte[]? DisplayImage { get; set; }
    }
}
