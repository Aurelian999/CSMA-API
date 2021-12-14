using CSMA_API.Application.Models;
using MediatR;

namespace CSMA_API.Application.Queries
{
    public class GetAppointmentByIdQuery : IRequest<AppointmentDto>
    {
        public int Id { get; set; }

        public GetAppointmentByIdQuery(int id)
        {
            Id = id;
        }
    }
}
