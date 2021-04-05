using System;
using System.Threading.Tasks;
using AutomobileClassification.Core.Application.ViewModels;
using AutomobileClassification.Core.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
         private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IdentityService _identityService;
        private readonly JwtTokenService _tokenService;
        public AuthController(SignInManager<ApplicationUser> signInManager, JwtTokenService tokenService, IdentityService identityService)
        {
            _signInManager = signInManager;
            _tokenService = tokenService;
            _identityService = identityService;
        }
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult> Login([FromBody] LoginViewModel entity)
        {
            var result = await _signInManager.PasswordSignInAsync(entity.UserName, entity.Password, true, false);
            if (result.Succeeded)
            {
                var user = await _identityService.GetUserByUsername(entity.UserName);
                return Ok(new { token = _tokenService.GenerateJSONWebToken(user), UserInfo = user });
            }
            return BadRequest();
        }

    }
}