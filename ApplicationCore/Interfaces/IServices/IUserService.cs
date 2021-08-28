using ApplicationCore.DTOs.Auth;
using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.IServices
{
    public interface IUserService
    {
        Task AddUserAsync(UserRegisterDto userRegisterDto, int portalId);
        Task<User> GetUserById(int UserId);
    }
}
