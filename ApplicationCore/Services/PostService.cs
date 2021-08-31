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
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        public bool PostExists(int postId)
        {
            return _postRepository.EntityExists(postId);
        }

        public bool PostBelongsToPortal(int postId, int portalId)
        {
            return _postRepository.PostHasPortalId(postId, portalId);
        }
    }
}
