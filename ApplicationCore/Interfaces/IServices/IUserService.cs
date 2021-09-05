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
        Task RegisterUserAsync(UserRegisterDto userRegisterDto, int portalId);
        Task<UserLoginResponseDto> Login(UserLoginDto userLogin, int portalId);
        Task<User> GetUserByIdAsync(int userId);
        Task DeleteUser(int userId, int portalId, bool permanent = false);
    }
}
