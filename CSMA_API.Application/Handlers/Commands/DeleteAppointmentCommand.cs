using MediatR;

namespace CSMA_API.Application.Handlers.Commands
{
    public class DeleteAppointmentCommand : IRequest<bool>
    {
        public int Id { get; set; }

        public DeleteAppointmentCommand(int id)
        {
            Id = id;
        }
    }
}
