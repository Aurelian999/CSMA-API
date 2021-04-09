namespace CSMA_API.Controllers.v1.Requests
{
    public class CreateServiceRequest
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        /// <summary>
        /// Ammount of time in minutes
        /// </summary>
        public int Duration { get; set; }
        public string Description { get; set; }
    }
}
