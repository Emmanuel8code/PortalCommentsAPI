using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class User : AuditableEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime BirthDate { get; set; }
        public int PortalId { get; set; }
        public Portal Portal { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public bool IsLegalAge { get; set; }
    }
}
