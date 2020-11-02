using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Altos.Api.Framework.Infrastructure.Authentication;
using Altos.Services.Features.Authentication;
using Altos.Services.Features.Authentication.Dtos;
using Microsoft.IdentityModel.Tokens;

namespace Altos.Api.Features.Users.Authenticate
{
    /// <summary>
    /// Authentication controller
    /// </summary>
    [Route("api/authenticate")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        /// <summary>
        /// AuthenticationController
        /// </summary>
        /// <param name="authenticationService"></param>
        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        /// <summary>
        /// Authenticate
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<AccessTokensResponse>> Authenticate([FromBody] AuthenticationRequest request)
        {
            var result = await _authenticationService.LoginAsync(request.Email, request.Password);

            switch (result.LoginResult)
            {
                case LoginResult.Successful:
                    {
                        var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.NameIdentifier, result.User.Id.ToString()),
                            new Claim(ClaimTypes.Name, result.User.Username),
                            new Claim(ClaimTypes.Email, result.User.Email),
                            new Claim(ClaimTypes.Role , result.User.UserRoles.FirstOrDefault()?.SystemName)
                        };

                        var now = DateTime.UtcNow;
                        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("v563f7cf-51fd-43ea-894f-b3f541307dex"));
                        var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                        var token = new JwtSecurityToken(
                            claims: claims,
                            notBefore: now,
                            expires: now.AddMinutes(10),
                            signingCredentials: signingCredentials);

                        return Ok(new AccessTokensResponse(token));
                    }
                case LoginResult.UserNotExist:
                    ModelState.AddModelError("", "Account.Login.WrongCredentials.CustomerNotExist");
                    break;
                case LoginResult.WrongPassword:
                default:
                    ModelState.AddModelError("", "Account.Login.WrongCredentials");
                    break;
            }

            return Ok(ModelState);
        }

        /// <summary>
        /// Logout
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [Route("logout")]
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            if (User.Identity.IsAuthenticated)
            {
                var authorizationHeader = HttpContext.Request.Headers["authorization"];
                //ToDo: implement a way to destroy the token (ex. update expire time to 0)
            }

            return Ok();
        }
    }
}
