using CSMA_API.Application.Models;
using MediatR;

namespace CSMA_API.Application.Queries
{
    public class GetServiceByIdQuery : IRequest<ServiceDto>
    {
        public int ServiceId { get; set; }

        public GetServiceByIdQuery(int serviceId)
        {
            ServiceId = serviceId;
        }
    }
}
