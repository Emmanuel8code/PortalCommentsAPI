using ApplicationCore.Entities;
using ApplicationCore.Interfaces.IRepositories;
using ApplicationCore.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class RoleService : IRoleService
    {
        private readonly IGenericRepositoryAsync<Role> _roleRepository;
        public RoleService(IGenericRepositoryAsync<Role> roleRepository)
        {
            _roleRepository = roleRepository;
        }
        public bool RoleExists(int RoleId)
        {
            return _roleRepository.EntityExists(RoleId);
        }
    }
}
