using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.IRepositories
{
    public interface IUserRepository : IGenericRepositoryAsync<User>
    {
        Task<User> GetUserByEmailPassword(string Email, string Password, int PortalId);
    }
}
