using MediatR;

namespace CSMA_API.Application.Handlers.Commands
{
    public class UpdateAppointmentCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int ClientId { get; set; }
        public int EmployeeId { get; set; }
        public int ServiceId { get; set; }
        public int LocationId { get; set; }
        public string Details { get; set; }
        public bool NoShow { get; set; }
    }
}
