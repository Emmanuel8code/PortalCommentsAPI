using ApplicationCore.Entities;
using ApplicationCore.Interfaces.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class PostRepository : GenericRepository<Post>, IPostRepository
    {
        public PostRepository(AppDbContext dbContext) : base(dbContext)
        {

        }
        
        public bool PostHasPortalId(int postId, int portalId)
        {
            return _dbContext.Posts.Any(x => x.Id == postId && x.PortalId == portalId);
        }
    }
}
