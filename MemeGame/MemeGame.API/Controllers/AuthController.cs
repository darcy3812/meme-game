using MemeGame.Infrastructure.Persistance.Migrations;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System;
using System.Threading.Tasks;
using MemeGame.Domain.Users.Dto;
using MemeGame.Application.Users;

namespace MemeGame.API.Controllers
{
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("api/login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var userId = await _userService.SignIn(loginDto);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, loginDto.Name),
                new Claim(ClaimTypes.NameIdentifier, userId.ToString())
            };

            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                AllowRefresh = true,
                IsPersistent = true
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);

            return Ok();
        }

        [HttpGet("api/me")]
        public IActionResult GetCurrentUser()
        {
            if (HttpContext.User.Identity?.IsAuthenticated == false)
            {
                return Unauthorized();
            }

            return Ok();
        }
    }
}
