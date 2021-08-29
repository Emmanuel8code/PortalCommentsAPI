﻿using ApplicationCore.DTOs.Auth;
using ApplicationCore.Exceptions;
using ApplicationCore.Interfaces.ISecurity;
using ApplicationCore.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortalsController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ITokenClaimsService _tokenService;
        private readonly IConfiguration _configuration;
        public PortalsController(IUserService userService, ITokenClaimsService tokenService, IConfiguration configuration)
        {
            _userService = userService;
            _tokenService = tokenService;
            _configuration = configuration;
        }


        // POST api/<PortalsController>/{id}/register
        [HttpPost("{id}/register")]
        public async Task<IActionResult> UserRegister(int id, [FromBody] UserRegisterDto userRegisterDto)
        {
            try
            {
                await _userService.RegisterUserAsync(userRegisterDto, id);
                return Ok();
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }
            catch (AgeNotAllowedException e)
            {
                return Unauthorized(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        // POST api/<PortalsController>/{id}/login
        [HttpPost("{id}/login")]
        public async Task<IActionResult> UserLogin(int id, [FromBody] UserLoginDto userLoginDto)
        {
            try
            {
                var user = await _userService.Login(userLoginDto, id);
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
    }
}
