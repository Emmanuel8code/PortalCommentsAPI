using ApplicationCore.Entities;
using ApplicationCore.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public async Task<User> GetUserById(int userId)
        {
            return await (from c in _dbContext.Users
                          where c.Id == userId && c.DeletedAt == null
                          select c).FirstOrDefaultAsync();
        }

        public async Task<User> GetUserByPortalId(int userId, int portalId, bool deleteNull = true)
        {
            var queryable = _dbContext.Users.AsQueryable();

            queryable = queryable.Where(u => u.Id == userId && u.PortalId == portalId);
            
            if (deleteNull)
            {
                queryable = queryable.Where(u => u.DeletedAt == null);
            }

            return await queryable.FirstOrDefaultAsync();
        }

        public async Task SoftDelete(User user)
        {
            user.DeletedAt = DateTime.Now;
            _dbContext.Entry(user).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
        
        public bool NickNameExists(string nickname, int portalId)
        {
            return _dbContext.Users.Any(u => u.NickName == nickname && u.PortalId == portalId);
        }

        public bool EmailExists(string email, int portalId)
        {
            return _dbContext.Users.Any(u => u.Email == email && u.PortalId == portalId);
        }
    }
}
