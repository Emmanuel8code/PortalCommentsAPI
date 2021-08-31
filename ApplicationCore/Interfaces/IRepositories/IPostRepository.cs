using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.IRepositories
{
    public interface IPostRepository : IGenericRepositoryAsync<Post>
    {
        bool PostHasPortalId(int postId, int portalId);
    }
}
