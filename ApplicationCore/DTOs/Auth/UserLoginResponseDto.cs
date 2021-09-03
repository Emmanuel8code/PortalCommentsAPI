using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.DTOs.Auth
{
    public class UserLoginResponseDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
        public string Email { get; set; }
        public string BirthDate { get; set; }
        public int PortalId { get; set; }
        public int RoleId { get; set; }
        public bool IsLegalAge { get; set; }
    }
}
