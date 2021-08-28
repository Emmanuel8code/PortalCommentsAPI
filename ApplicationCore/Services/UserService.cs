using ApplicationCore.DTOs.Auth;
using ApplicationCore.Entities;
using ApplicationCore.Exceptions;
using ApplicationCore.Interfaces.IRepositories;
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
        private readonly IGenericRepositoryAsync<User> _userRepository;
        private readonly IPortalService _portalService;
        private readonly IRoleService _roleService;
        public UserService(IGenericRepositoryAsync<User> userRepository, IPortalService portalService, IRoleService roleService)
        {
            _userRepository = userRepository;
            _portalService = portalService;
            _roleService = roleService;
        }
        public async Task AddUserAsync(UserRegisterDto userRegister, int portalId)
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

            User user = userRegister.MapUserRegisterToUser(portalId);

            await _userRepository.AddAsync(user);
        }

        public async Task Login(UserLoginDto userLogin)
        {
            //User user = userRegister.MapUserRegisterToUser();

            //await _userRepository.AddAsync(user);
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
