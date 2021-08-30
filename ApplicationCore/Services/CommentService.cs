using ApplicationCore.Interfaces.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class CommentService
    {
        private readonly ICommentRepository _commentRepository;
        //private readonly IPortalService _portalService;
        
        public CommentService(ICommentRepository commentRepository) //, IPortalService portalService)
        {
            _commentRepository = commentRepository;
            //_portalService = portalService;
        }

        //public async Task<string> AddCommentAsync()
        //{

        //}
    }
}
