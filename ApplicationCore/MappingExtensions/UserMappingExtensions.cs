using ApplicationCore.DTOs.Auth;
using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.MappingExtensions
{
    public static class UserMappingExtensions
    {
        public static User MapUserRegisterToUser(this UserRegisterDto userRegisterDto, int portalId)
        {
            if (userRegisterDto == null)
            {
                return null;
            }

            return new User()
            {
                FirstName = userRegisterDto.FirstName,
                LastName = userRegisterDto.LastName,
                NickName = userRegisterDto.NickName,
                BirthDate = userRegisterDto.BirthDate,
                Email = userRegisterDto.Email,
                Password = userRegisterDto.Password,
                PortalId = portalId,
                RoleId = userRegisterDto.RoleId
            };
        }

        public static UserLoginResponseDto MapUserToUserLoginResponse(this User user)
        {
            if (user == null)
            {
                return null;
            }

            return new UserLoginResponseDto()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                NickName = user.NickName,
                BirthDate = user.BirthDate,
                Email = user.Email,
                PortalId = user.PortalId,
                RoleId = user.RoleId,
                IsLegalAge = user.IsLegalAge
            };
        }
    }
}
