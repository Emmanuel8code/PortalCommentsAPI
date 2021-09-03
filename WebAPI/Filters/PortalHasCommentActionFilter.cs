using ApplicationCore.Interfaces.IRepositories;
using ApplicationCore.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Filters
{
    public class PortalHasCommentActionFilter : IAsyncActionFilter
    {
        private readonly IPostService _postService;
        private readonly ICommentRepository _commentRepository;
        public PortalHasCommentActionFilter(IPostService postService, ICommentRepository commentRepository)
        {
            _postService = postService;
            _commentRepository = commentRepository;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var portalIdClaim = context.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "PortalId")?.Value;
            int portalId = int.Parse(portalIdClaim);

            int commentId = (int)context.ActionArguments["commentId"];

            var comment = await _commentRepository.GetByIdAsync(commentId);

            if(comment != null)
            {
                if (!(_postService.PostBelongsToPortal(comment.PostId, portalId)))
                {
                    //context.Result = new NotFoundObjectResult(("Comment was not found"));
                    ControllerBase controller = context.Controller as ControllerBase;
                    context.Result = controller.Problem("Comment was not found", statusCode: 404);
                    return;
                }
            }
            
            var resultContext = await next();
        }
    }
}
