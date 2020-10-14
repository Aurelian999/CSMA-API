namespace CSMA_API.Controllers.v1.Responses
{
    public class ServiceResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        /// <summary>
        /// Ammount of time in minutes
        /// </summary>
        public int Duration { get; set; }
        public string Description { get; set; }
    }
}
