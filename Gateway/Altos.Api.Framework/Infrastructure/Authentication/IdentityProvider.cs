using System.Threading;

namespace Altos.Api.Framework.Infrastructure.Authentication
{
    public static class IdentityProvider
    {
        public static AuthorizationAttributes GetAccessToken()
        {
            var identityUser = Thread.CurrentPrincipal as IdentityUser;

            return identityUser?.Authorization;
        }

        public static CurrentUser GetCurrentUser()
        {
            var identityUser = Thread.CurrentPrincipal as IdentityUser;

            return identityUser == null ? null : new CurrentUser
            {
                UserId = identityUser.Id,
                UserGuid = identityUser.UserGuid,
                Username = identityUser.UserName,
                UserRoles = identityUser.UserRoles
            };
        }
    }
}
