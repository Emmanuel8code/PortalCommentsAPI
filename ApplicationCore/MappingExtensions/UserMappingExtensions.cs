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
        public static User MapUserRegisterToUser(this UserRegisterDto userRegisterDto)
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
                PortalId = userRegisterDto.PortalId,
                RoleId = userRegisterDto.RoleId
            };
        }
    }
}
