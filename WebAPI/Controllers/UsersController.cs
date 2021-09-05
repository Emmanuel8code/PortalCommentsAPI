using ApplicationCore.DTOs.Auth;
using ApplicationCore.Exceptions;
using ApplicationCore.Interfaces.ISecurity;
using ApplicationCore.Interfaces.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Filters;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Produces("application/json")]
    [ProducesResponseType(500)]
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ITokenClaimsService _tokenService;
        private readonly IConfiguration _configuration;
        public UsersController(IUserService userService, ITokenClaimsService tokenService, IConfiguration configuration)
        {
            _userService = userService;
            _tokenService = tokenService;
            _configuration = configuration;
        }


        // POST api/<PortalsController>/{id}/register
        /// <summary>
        /// Register a User in the specified Portal. 
        /// </summary>
        /// <param name="portalId">A intenger number that identifies a Portal.</param>
        /// <param name="userRegisterDto">A type of UserRegisterDto object.</param>
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        [ProducesResponseType(typeof(ProblemDetails), 401)]
        [ProducesResponseType(typeof(ProblemDetails), 403)]
        [HttpPost("/Portals/{portalId}/register")]
        public async Task<IActionResult> UserRegister(int portalId, [FromBody] UserRegisterDto userRegisterDto)
        {
            try
            {
                await _userService.RegisterUserAsync(userRegisterDto, portalId);
                return Ok("User registered");
            }
            catch (ArgumentException e)
            {
                return this.Problem(e.Message, statusCode: 400);
            }
            catch (AgeNotAllowedException e)
            {
                return this.Problem(e.Message, statusCode: 403);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        // POST api/<PortalsController>/{id}/login
        /// <summary>
        /// Login a User in the specified Portal. 
        /// </summary>
        /// <param name="portalId">A intenger number that identifies a Portal.</param>
        /// <param name="userLoginDto">A type of UserLoginDto object.</param>
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        [ProducesResponseType(typeof(ProblemDetails), 401)]
        [HttpPost("/Portals/{portalId}/login")]
        public async Task<IActionResult> UserLogin(int portalId, [FromBody] UserLoginDto userLoginDto)
        {
            try
            {
                var user = await _userService.Login(userLoginDto, portalId);
                var token = await _tokenService.GetTokenAsync(user.Id, _configuration.GetValue<string>("SecretKey"));
                return Ok(token);
            }
            catch (InvalidOperationException e)
            {
                return Unauthorized(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        // DELETE /<PortalsController>/5
        /// <summary>
        /// Disable a user in a Portal. Authorize: only Admin. 
        /// </summary>
        /// <param name="userId">A intenger number that identifies a User.</param>
        /// <param name="permanent">A boolean to confirm hard delete.</param>
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(ProblemDetails), 404)]
        [Authorize(Policy = "Admin")]
        [HttpDelete("{userId}")]
        public async Task<IActionResult> Delete(int userId, [FromQuery] bool permanent)
        {
            try
            {
                var portalIdClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "PortalId")?.Value;
                int portalId = int.Parse(portalIdClaim);
                await _userService.DeleteUser(userId, portalId, permanent);
                return NoContent();
            }
            catch (EntityNotFoundException e)
            {
                return this.Problem(e.Message, statusCode: 404);
            }
        }
    }
}
