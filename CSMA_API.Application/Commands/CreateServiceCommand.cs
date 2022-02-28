using MediatR;

namespace CSMA_API.Application.Commands
{
    public class CreateServiceCommand : IRequest<Unit>
    {
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
