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
        Task<User> GetUserById(int userId);
        Task<User> GetUserBySpec(int userId, int portalId, bool deleteNull = true);
        Task SoftDelete(User user);
        bool NickNameExists(string nickname, int portalId);
        bool EmailExists(string email, int portalId);
    }
}
