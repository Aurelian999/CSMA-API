using AutoMapper;
using CSMA_API.Application.Common.Interfaces;
using CSMA_API.Application.Models;
using CSMA_API.Application.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CSMA_API.Application.Handlers.Queries
{
    public class GetAllEmployeeWorkingHoursHandler : IRequestHandler<GetAllEmployeeWorkingHoursQuery, List<EmployeeWorkingHoursDto>>
    {
        private readonly ISalonDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAllEmployeeWorkingHoursHandler(ISalonDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<EmployeeWorkingHoursDto>> Handle(GetAllEmployeeWorkingHoursQuery request, CancellationToken cancellationToken)
        {
            return await _mapper.ProjectTo<EmployeeWorkingHoursDto>(_dbContext.WorkingHours).ToListAsync();
        }
    }
}
