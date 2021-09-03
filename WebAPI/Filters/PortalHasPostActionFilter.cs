using ApplicationCore.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Filters
{
    public class PortalHasPostActionFilter : IActionFilter
    {
        private readonly IPostService _postService;
        public PortalHasPostActionFilter(IPostService postService)
        {
            _postService = postService;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var portalIdClaim = context.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "PortalId")?.Value;
            int portalId = int.Parse(portalIdClaim);

            int postId = (int)context.ActionArguments["postId"];

            if (!(_postService.PostBelongsToPortal(postId, portalId)))
            {
                //context.Result = new NotFoundObjectResult("Post was not found"); 
                ControllerBase controller = context.Controller as ControllerBase;
                context.Result = controller.Problem("Post was not found", statusCode : 404);
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            //throw new NotImplementedException();
        }
    }
}
