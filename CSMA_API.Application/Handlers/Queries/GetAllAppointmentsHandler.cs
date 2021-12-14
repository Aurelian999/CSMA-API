using AutoMapper;
using AutoMapper.QueryableExtensions;
using CSMA_API.Application.Common.Interfaces;
using CSMA_API.Application.Models;
using CSMA_API.Application.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CSMA_API.Application.Handlers.Queries
{
    public class GetAllAppointmentsHandler : IRequestHandler<GetAllAppointmentsQuery, List<AppointmentDto>>
    {
        private readonly ISalonDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAllAppointmentsHandler(ISalonDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<AppointmentDto>> Handle(GetAllAppointmentsQuery request, CancellationToken cancellationToken)
        {
            var appointments = await _dbContext.Appointments.ProjectTo<AppointmentDto>(_mapper.ConfigurationProvider).ToListAsync();

            return appointments;
        }
    }
}
