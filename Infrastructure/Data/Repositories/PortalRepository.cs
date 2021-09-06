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
    public class PortalRepository : GenericRepository<Portal>, IPortalRepository
    {
        public PortalRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<bool> IsLegalAgeRequired(int portalId)
        {
            bool IsLegalAgeRequired = await (from p in _dbContext.Portals
                                             where p.Id == portalId
                                             select p.IsLegalAgeRequired).FirstOrDefaultAsync();
            return IsLegalAgeRequired;
        }
    }
}
