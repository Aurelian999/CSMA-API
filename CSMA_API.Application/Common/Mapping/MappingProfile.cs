using AutoMapper;
using CSMA_API.Application.Commands;
using CSMA_API.Application.Models;
using CSMA_API.Domain;

namespace CSMA_API.Application.Common.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Appointment, AppointmentDto>().ReverseMap();
            CreateMap<Service, ServiceDto>().ReverseMap();
            CreateMap<Service, CreateServiceCommand>().ReverseMap();
        }
    }
}
