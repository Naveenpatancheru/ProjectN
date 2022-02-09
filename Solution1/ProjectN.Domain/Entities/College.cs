using ProjectN.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectN.Domain.Entities
{
    public class College : AuditableEntity
    {
        public Guid CollegeId { get; set; }
        public string CollegeCode { get; set; }
        public string CollegeName { get; set; }
        public string CollegeType { get; set; }  
        public string CollegeLocation { get; set; } 
        public Guid CountryId { get; set;}
        public Country Country { get; set; }
    }
}
