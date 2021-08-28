using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.ISecurity
{
    public interface ITokenClaimsService
    {
        Task<string> GetTokenAsync(int userId, string key);
    }
}
