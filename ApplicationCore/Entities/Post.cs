using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Post : BaseEntity
    {
        public string Description { get; set; }
        public int PortalId { get; set; }
        public Portal Portal { get; set; }
    }
}
