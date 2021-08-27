using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Comment : AuditableEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}
