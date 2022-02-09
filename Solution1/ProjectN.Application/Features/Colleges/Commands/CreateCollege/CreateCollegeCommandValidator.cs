using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using ProjectN.Application.Contracts.Persistance;

namespace ProjectN.Application.Features.Colleges.Commands.CreateCollege
{
    public class CreateCollegeCommandValidator : AbstractValidator<CreateCollegeCommand>
    {
        private readonly ICollegeRepository _collegeRepository;
        
        public CreateCollegeCommandValidator(ICollegeRepository collegeRepository)
        {
            _collegeRepository = collegeRepository;

            RuleFor(p => p.CollegeName)
                .NotEmpty().WithMessage("{PropertyName} is Required")
                .NotNull()
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");

            RuleFor(p => p.CollegeLocation)
               .NotEmpty().WithMessage("{PropertyName} is Required")
               .NotNull()
               .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

            RuleFor(p => p)
                .MustAsync(CollegeNameUnique)
                .WithMessage("College with same name already created");
        }

        private async Task<bool> CollegeNameUnique(CreateCollegeCommand e, CancellationToken token)
        {
            return !(await _collegeRepository.IsCollegeNameUnique(e.CollegeName));
        }
    }
}
