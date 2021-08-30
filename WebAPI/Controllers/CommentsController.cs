using ApplicationCore.DTOs.CommentDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        //// GET: api/<CommentsController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<CommentsController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}


        // POST api/<CommentsController>
        [Authorize(Policy = "Registered")]
        [HttpPost("/Posts/{id}/Comments")]
        public async Task<IActionResult> Post(int id, [FromBody] CommentRequestDto commentsRequestDto)
        {
            //Usar el claim portalid de User para pasarle al servicio de comentario y comparar si el comentario
            //tiene un postId con un portal de tal portalId
            return Ok();
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
