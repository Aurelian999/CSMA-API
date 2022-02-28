using CSMA_API.Application.Commands;
using CSMA_API.Application.Common.Interfaces;
using CSMA_API.Application.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CSMA_API.Application.Handlers.Commands
{
    public class DeleteServiceHandler : IRequestHandler<DeleteServiceCommand, Result>
    {
        private readonly ISalonDbContext _dbContext;

        public DeleteServiceHandler(ISalonDbContext salonDbContext)
        {
            _dbContext = salonDbContext;
        }

        public async Task<Result> Handle(DeleteServiceCommand request, CancellationToken cancellationToken)
        {
            var serviceToDelete = await _dbContext.Services.FirstOrDefaultAsync(s => s.Id == request.ServiceId, cancellationToken);

            if (serviceToDelete == null)
            {
                // TODO move message somewhere
                return Result.Failure(new string[] { "Service to be deleted was not found." }, 412);
            }

            _dbContext.Services.Remove(serviceToDelete);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
}
