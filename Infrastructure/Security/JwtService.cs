using ApplicationCore.Interfaces.ISecurity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Security
{
    public class JwtService : ITokenClaimsService
    {
        public Task<string> GetTokenAsync(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
