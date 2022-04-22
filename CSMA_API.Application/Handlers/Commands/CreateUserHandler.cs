using AutoMapper;
using CSMA_API.Application.Commands;
using CSMA_API.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSMA_API.Application.Handlers.Commands
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, Unit>
    {
        private readonly ISalonDbContext _salonDbContext;
        private IMapper _mapper;

        public CreateUserHandler(ISalonDbContext salonDbContext, IMapper mapper)
        {
            _salonDbContext = salonDbContext;
            _mapper = mapper;
        }

        public Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            // TODO add validators
            var userToCreate = _mapper.Map<IIdentityUser>(request);
            if (userToCreate == null)
            {
                throw new Exception();
            }

        }
    }
}
