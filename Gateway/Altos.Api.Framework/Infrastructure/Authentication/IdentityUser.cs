using Altos.Domain.Features.UserRoles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Altos.Api.Framework.Infrastructure.Authentication
{
    public class IdentityUser : ClaimsPrincipal
    {
        public IdentityUser(IEnumerable<Claim> userClaims, string authorizationToken, string authorizationType) : base(new ClaimsIdentity(userClaims, authorizationType, "name", "role"))
        {
            Authorization = new AuthorizationAttributes
            {
                Scheme = authorizationType,
                Token = authorizationToken
            };
        }

        public int Id => Convert.ToInt32(this.FindFirst("sub").Value);
        public Guid UserGuid => new Guid(this.FindFirst("userGuid").Value);
        public string UserName => this.FindFirst("name").Value;
        public string Email => this.FindFirst("email")?.Value;

        public List<UserRole> UserRoles
        {
            // Roles come in the format: [OrganizationalUnitId/]RoleName where OrganizationalUnitId exists only if the role is not tenant level
            get
            {
                var rolesClaims = GetRoleClaims();
                return rolesClaims.Select(x =>
                {
                    //OrganizationalUnitId organizationalUnitId = null;
                    string roleName = x;

                    return new UserRole
                    {
                        Name = roleName
                    };
                }).ToList();
            }
        }

        public AuthorizationAttributes Authorization { get; }

        public override bool IsInRole(string roleName)
        {
            var userRoles = GetRoleClaims();

            return userRoles.Contains(roleName);
        }

        public bool HasAnyRole()
        {
            var userRoles = GetRoleClaims();

            return userRoles.Any();
        }

        #region Private methods

        public List<string> GetRoleClaims()
        {
            return this.FindAll("role").Select(x => x.Value).ToList();
        }

        #endregion

    }
}
