using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectN.Domain.Common
{
    public class AuditableEntity
    {
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }   
        public string LastUpdatedBy { get; set; }
        public DateTime? LastUpdatedDate { get; set; }   
    }
}
