using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace ProjectN.Application.Features.Colleges.Commands.CreateCollege
{
    public class CreateCollegeCommand : IRequest<Guid>
    {
        public Guid CollegeId { get; set; }
        public string CollegeCode { get; set; }
        public string CollegeName { get; set; }
        public sbyte CollegeType { get; set; }
        public string CollegeLocation { get; set; }
        public Guid CountryId { get; set; }
        public override string ToString()
        {
            return $"College name: {CollegeName}; CollegeType: {CollegeType}; CollegeLocation: {CollegeLocation};";
        }
    }
}
