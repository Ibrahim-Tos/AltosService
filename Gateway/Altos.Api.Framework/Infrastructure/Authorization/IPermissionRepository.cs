using System.Collections.Generic;
using Altos.Domain.Features.Security;

namespace Altos.Api.Framework.Infrastructure.Authorization
{
    public interface IPermissionRepository
    {
        IEnumerable<Permission> GetAllPermissionsForRole(string role);
        IEnumerable<string> GetAllRolesThatHavePermission(Permission permission);
    }
}
