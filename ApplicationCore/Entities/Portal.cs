using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Portal : BaseEntity
    {
        public string Name { get; set; }
        public bool IsLegalAgeRequired { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
