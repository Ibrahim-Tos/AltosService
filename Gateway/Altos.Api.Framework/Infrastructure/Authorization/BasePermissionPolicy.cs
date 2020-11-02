using System.Collections.Generic;
using System.Linq;
using Altos.Api.Framework.Infrastructure.Authentication;
using Altos.Domain.Features.Security;
using Altos.Domain.Features.UserRoles;

namespace Altos.Api.Framework.Infrastructure.Authorization
{
    public abstract class BasePermissionPolicy : IPermissionPolicy
    {
        private IPermissionRepository permissionRepository;

        protected BasePermissionPolicy(IPermissionRepository permissionRepository)
        {
            this.permissionRepository = permissionRepository;
        }

        public abstract bool CanAccessEndpoint(Dictionary<string, object> arguments);

        protected bool HaveAccess(Permission permission)
        {
            return this.GetCurrentUserRolesWithPermission(permission).Any();
        }

        protected IList<UserRole> GetCurrentUserRolesWithPermission(Permission permission)
        {
            var user = IdentityProvider.GetCurrentUser();

            return user.UserRoles
                .Where(userRole =>
                    this.permissionRepository.GetAllPermissionsForRole(userRole.Name).Contains(permission))
                .ToList();
        }
    }
}
