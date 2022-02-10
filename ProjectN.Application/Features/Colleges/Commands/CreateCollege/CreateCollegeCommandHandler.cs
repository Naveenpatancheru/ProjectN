using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using ProjectN.Application.Contracts.Persistance;
using AutoMapper;
using System.Threading;
using ProjectN.Domain.Entities;
using ProjectN.Application.Contracts.Infrastructure;
using ProjectN.Application.Models;

namespace ProjectN.Application.Features.Colleges.Commands.CreateCollege
{
    public class CreateCollegeCommandHandler : IRequestHandler<CreateCollegeCommand, Guid>
    {
        private readonly IMapper _mapper;
        private readonly ICollegeRepository _collegeRepository;
        private readonly IEmailService _emailService;

        public CreateCollegeCommandHandler(IMapper mapper, ICollegeRepository collegeRepository, IEmailService emailService)
        {
            _mapper = mapper;
            _collegeRepository = collegeRepository;
            _emailService = emailService;   

        }
        public async Task<Guid> Handle(CreateCollegeCommand request, CancellationToken cancellationToken)
        {

            var createCollegeCommandResponse = new CreateCollegeCommandResponse();
            var createCollegeCommand = new CreateCollegeCommand();
            var validator = new CreateCollegeCommandValidator(_collegeRepository);
            var validatorResult = await validator.ValidateAsync(request);

            if (validatorResult.Errors.Count > 0)
            {
                createCollegeCommandResponse.Success = false;
                createCollegeCommandResponse.ValidationErrors = new List<string>();

            }
               // throw new Exceptions.ValidationException(validatorResult);
            var @event = _mapper.Map<College>(request);
            @event = await _collegeRepository.AddAsync(@event);

            var email = new Email()
            {
                To = "Patan.Naveen@gmail.com",
                Subject = "A new Event Added",
                Body = "This is the body for adding new event",
            };
            //try
            //{
                await _emailService.SendEmail(email);
           // }
            //catch (Exception ex)
            //{
               
            //}

            return @event.CollegeId;
        }
    }
}
