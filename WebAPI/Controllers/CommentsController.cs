using ApplicationCore.DTOs.CommentDtos;
using ApplicationCore.Exceptions;
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
    [Route("[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService _commentService;
        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        
        // GET: /Posts/{id}/Comments
        /// <summary>
        /// Get Comments from a Post. Authorize: any registered User. 
        /// </summary>
        /// <param name="postId">A integer number.</param>
        [ProducesResponseType(typeof(IEnumerable<CommentResponseDto>), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        [ProducesResponseType(500)]
        [Authorize(Policy = "Registered")]
        [ServiceFilter(typeof(PortalHasPostActionFilter))]
        [HttpGet("/Posts/{postId}/Comments")]
        public async Task<IActionResult> GetCommentsByPost(int postId)
        {
            try
            {
                var commentsReponseList = await _commentService.GetCommentsByPostAsync(postId);
                return Ok(commentsReponseList);
            }
            catch (ArgumentException e)
            {
                return this.Problem(e.Message, statusCode: 400);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        
        // GET: /Comments?search=word
        /// <summary>
        /// Get Comments that have the search word in their content. Authorize: only Admin. 
        /// </summary>
        /// <param name="search">A string word.</param>
        [ProducesResponseType(typeof(IEnumerable<CommentResponseDto>), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        [ProducesResponseType(500)]
        [Authorize(Policy = "Admin")]
        [HttpGet()]
        public async Task<IActionResult> GetCommentsByWord([FromQuery] string search)
        {
            try
            {
                var commentsReponseList = await _commentService.GetCommentsByWordAsync(search);
                return Ok(commentsReponseList);
            }
            catch (ArgumentException e)
            {
                return this.Problem(e.Message, statusCode: 400);
            }
            //catch (Exception e)
            //{
            //    return StatusCode(500, e.Message);
            //}
        }


        // POST /Posts/{id}/Comments
        /// <summary>
        /// Create a Comment on a Post. Authorize: any registered User. 
        /// </summary>
        /// <param name="postId">A intenger number.</param>
        /// <param name="commentRequestDto">A type CommentRequestDto object.</param>
        [ProducesResponseType(typeof(CommentResponseDto), 201)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        [ProducesResponseType(500)]
        [Authorize(Policy = "Registered")]
        [ServiceFilter(typeof(PortalHasPostActionFilter))]
        [HttpPost("/Posts/{postId}/Comments")]
        public async Task<IActionResult> Post(int postId, [FromBody] CommentRequestDto commentRequestDto)
        {
            try
            {
                int userId = int.Parse(HttpContext.User.Claims.FirstOrDefault(c => c.Type == "UserId")?.Value);
                var commentResponse = await _commentService.AddCommentAsync(userId, postId, commentRequestDto);
                
                return CreatedAtAction(nameof(GetComment), new { id = commentResponse.Id}, commentResponse);
            }
            catch (ArgumentException e)
            {
                return this.Problem(e.Message, statusCode: 400);
            }
            //catch (Exception e)
            //{
            //    return StatusCode(500, e.Message);
            //}
        }

        // GET /<CommentsController>/5
        [Authorize(Policy = "Registered")]
        [HttpGet("{id}")]
        public string GetComment(int id)
        {
            return "value";
        }

        // PATCH /<CommentsController>/5
        /// <summary>
        /// Update a content of a Comment. Authorize: any registered User. 
        /// </summary>
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(ProblemDetails), 404)]
        [ProducesResponseType(500)]
        [Authorize(Policy = "Registered")]
        [HttpPatch("{id}")]
        public async Task<IActionResult> CommentPatch(int id, [FromBody] string content)
        {
            try
            {
                int userId = int.Parse(HttpContext.User.Claims.FirstOrDefault(c => c.Type == "UserId")?.Value);
                await _commentService.UpdateCommentContent(id, content, userId);
                return NoContent();
            }
            catch (EntityNotFoundException e)
            {
                return this.Problem(e.Message, statusCode: 404);
            }
            catch (ArgumentException e)
            {
                return this.Problem(e.Message, statusCode: 400);
            }
        }

        
        // DELETE /<CommentsController>/5
        /// <summary>
        /// Delete a Comment on a Portal. Authorize: only Admin. 
        /// </summary>
        /// <param name="commentId">A intenger number.</param>
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(ProblemDetails), 404)]
        [ProducesResponseType(500)]
        [Authorize(Policy = "Admin")]
        [ServiceFilter(typeof(PortalHasCommentActionFilter))]
        [HttpDelete("{commentId}")]
        public async Task<IActionResult> Delete(int commentId)
        {
            try
            {
                await _commentService.SoftDeleteComment(commentId);
                return NoContent();
            }
            catch (EntityNotFoundException e)
            {
                return this.Problem(e.Message, statusCode : 404);
            }
        }
    }
}
