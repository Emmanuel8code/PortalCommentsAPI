using ApplicationCore.Entities;
using ApplicationCore.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
        public async Task<User> GetUserByEmailPassword(string Email, string Password, int PortalId)
        {
            return await _dbContext.Users
                .Where(x => x.Email == Email && x.Password == Password && x.PortalId == PortalId && x.DeletedAt == null)
                .FirstOrDefaultAsync();
        }
    }
}
