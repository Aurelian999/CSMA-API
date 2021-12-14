using CSMA_API.Application.Models;
using MediatR;

namespace CSMA_API.Application.Queries
{
    public  class GetAllAppointmentsQuery : IRequest<List<AppointmentDto>>
    {

    }
}
