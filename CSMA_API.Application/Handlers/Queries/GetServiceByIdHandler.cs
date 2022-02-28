using AutoMapper;
using CSMA_API.Application.Common.Interfaces;
using CSMA_API.Application.Models;
using CSMA_API.Application.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CSMA_API.Application.Handlers.Queries
{
    public class GetServiceByIdHandler : IRequestHandler<GetServiceByIdQuery, ServiceDto>
    {
        private readonly ISalonDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetServiceByIdHandler(ISalonDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ServiceDto> Handle(GetServiceByIdQuery request, CancellationToken cancellationToken)
        {
            var service = await _dbContext.Services.FirstOrDefaultAsync(s => s.Id == request.ServiceId, cancellationToken);

            if (service == null)
            {
                return null;
            }

            var serviceDto = _mapper.Map<ServiceDto>(service);

            return serviceDto;
        }
    }
}
