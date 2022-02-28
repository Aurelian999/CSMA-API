using AutoMapper;
using CSMA_API.Application.Commands;
using CSMA_API.Application.Common.Interfaces;
using CSMA_API.Domain;
using MediatR;

namespace CSMA_API.Application.Handlers.Commands
{
    public class CreateServiceHandler : IRequestHandler<CreateServiceCommand, Unit>
    {
        private readonly ISalonDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateServiceHandler(ISalonDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateServiceCommand request, CancellationToken cancellationToken)
        {
            var newService = _mapper.Map<Service>(request);

            _dbContext.Services.Add(newService);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return await Unit.Task;
        }
    }
}
