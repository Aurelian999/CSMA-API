using MediatR;

namespace CSMA_API.Application.Handlers.Commands
{
    public class CreateAppointmentCommand : IRequest<Unit>
    {
        public DateTime Date { get; set; }
        public int ClientId { get; set; }
        public int EmployeeId { get; set; }
        public int ServiceId { get; set; }
        public int LocationId { get; set; }
        public string Details { get; set; }
    }
}
