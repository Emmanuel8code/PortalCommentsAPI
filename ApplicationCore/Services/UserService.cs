using ApplicationCore.DTOs.Auth;
using ApplicationCore.Entities;
using ApplicationCore.Exceptions;
using ApplicationCore.Interfaces.IRepositories;
using ApplicationCore.Interfaces.ISecurity;
using ApplicationCore.Interfaces.IServices;
using ApplicationCore.MappingExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPortalService _portalService;
        private readonly IRoleService _roleService;
        private readonly IPasswordService _passwordService;
        public UserService(
            IUserRepository userRepository, 
            IPortalService portalService, 
            IRoleService roleService, 
            IPasswordService passwordService)
        {
            _userRepository = userRepository;
            _portalService = portalService;
            _roleService = roleService;
            _passwordService = passwordService;
        }
        public async Task RegisterUserAsync(UserRegisterDto userRegister, int portalId)
        {
            if (!(_portalService.PortalExists(portalId)))
            {
                throw new ArgumentException("Portal Id Invalid");
            }

            if (!(_roleService.RoleExists(userRegister.RoleId)) || userRegister.RoleId == 1)
            {
                throw new ArgumentException("Role Id invalid");
            }

            bool IsLegalAgeRequired = await _portalService.IsPortalLegalAgeRequired(portalId);
            if (IsLegalAgeRequired)
            {
                if (!(ageControl(userRegister.BirthDate)))
                {
                    throw new AgeNotAllowedException("Age not allowed");
                }
            }

            userRegister.Password = _passwordService.Hash(userRegister.Password);

            User user = userRegister.MapUserRegisterToUser(portalId);

            await _userRepository.AddAsync(user);
        }

        public async Task<UserLoginResponseDto> Login(UserLoginDto userLogin, int portalId)
        {
            userLogin.Password = _passwordService.Hash(userLogin.Password);

            var user = await _userRepository.GetUserByEmailPassword(userLogin.Email, userLogin.Password, portalId);
            if (user == null)
            {
                throw new InvalidOperationException("Incorrect Email or Password");
            }

            var userResponse = user.MapUserToUserLoginResponse();
            
            return userResponse;
        }

        public async Task<User> GetUserById(int UserId)
        {
            return await _userRepository.GetByIdAsync(UserId);
        }

        public bool ageControl(DateTime birthDate)
        {
            return true;
        }

    }
}
