using ApplicationCore.DTOs.CommentDtos;
using ApplicationCore.Interfaces.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Filters;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService _commentService;
        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        // GET: api/Posts/{id}/Comments
        [Authorize(Policy = "Registered")]
        [ServiceFilter(typeof(PortalHasPostActionFilter))]
        [HttpGet("/Posts/{postId}/Comments")]
        public async Task<IActionResult> GetCommentsByPost(int postId)
        {
            try
            {
                //int portalId = int.Parse(HttpContext.User.Claims.FirstOrDefault(c => c.Type == "PortalId")?.Value);
                var commentsReponseList = await _commentService.GetCommentsByPostAsync(postId);
                return Ok(commentsReponseList);
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        // GET api/<CommentsController>/5
        [HttpGet("{id}")]
        public string GetComment(int id)
        {
            return "value";
        }


        // POST api/Posts/{id}/Comments
        [Authorize(Policy = "Registered")]
        [HttpPost("/Posts/{postId}/Comments")]
        public async Task<IActionResult> Post(int postId, [FromBody] CommentRequestDto commentsRequestDto)
        {
            try
            {
                int portalId = int.Parse(HttpContext.User.Claims.FirstOrDefault(c => c.Type == "PortalId")?.Value);
                int userId = int.Parse(HttpContext.User.Claims.FirstOrDefault(c => c.Type == "UserId")?.Value);
                var commentResponse = await _commentService.AddCommentAsync(userId, portalId, postId, commentsRequestDto);
                
                return CreatedAtAction(nameof(GetComment), new { id = commentResponse.Id}, commentResponse);
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        //// PUT api/<CommentsController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<CommentsController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
