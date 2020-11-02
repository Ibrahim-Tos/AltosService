using System;
using System.IdentityModel.Tokens.Jwt;

namespace Altos.Api.Framework.Infrastructure.Authentication
{
    public class AccessTokensResponse
    {
        /// <summary>
        /// Initializes a new instance of <seealso cref="AccessTokensResponse"/>.
        /// </summary>
        /// <param name="securityToken"></param>
        public AccessTokensResponse(JwtSecurityToken securityToken)
        {
            AccessToken = new JwtSecurityTokenHandler().WriteToken(securityToken);
            TokenType = "Bearer";
            ExpiresIn = Math.Truncate((securityToken.ValidTo - DateTime.UtcNow).TotalSeconds);
        }

        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public string TokenType { get; set; }
        public double ExpiresIn { get; set; }
    }
}
