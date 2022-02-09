using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectN.Application.Features.Colleges.Queries.GetCollegesList
{
    public class CollegeListVm
    {
        public Guid CollegeId { get; set; }
        public string CollegeCode { get; set; }
        public string CollegeName { get; set; }
        public string CollegeType { get; set; }
        public string CollegeLocation { get; set; }
    }
}
