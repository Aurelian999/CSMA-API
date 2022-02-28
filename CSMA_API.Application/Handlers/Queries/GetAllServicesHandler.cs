using AutoMapper;
using AutoMapper.QueryableExtensions;
using CSMA_API.Application.Common.Interfaces;
using CSMA_API.Application.Models;
using CSMA_API.Application.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CSMA_API.Application.Handlers.Queries
{
    public class GetAllServicesHandler : IRequestHandler<GetAllServicesQuery, List<ServiceDto>>
    {
        private readonly ISalonDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAllServicesHandler(ISalonDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<ServiceDto>> Handle(GetAllServicesQuery request, CancellationToken cancellationToken)
        {
            var services = await _dbContext.Services.ProjectTo<ServiceDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);

            return services;
        }
    }
}
