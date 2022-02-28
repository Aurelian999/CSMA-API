using CSMA_API.Application.Models;
using MediatR;

namespace CSMA_API.Application.Commands
{
    public class DeleteServiceCommand : IRequest<Result>
    {
        public int ServiceId { get; set; }

        public DeleteServiceCommand(int serviceId)
        {
            ServiceId = serviceId;
        }
    }
}
