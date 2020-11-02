using System.Collections.Generic;
using System.Linq;
using Altos.Domain.Features.Security;
using Altos.Services.Features.UserRoles.Dtos;

namespace Altos.Api.Framework.Infrastructure.Authorization
{
    public class GlobalPermissionRepository : IPermissionRepository
    {
        public static readonly Dictionary<string, UserRoleDto> roles = new List<UserRoleDto>
        {
            new UserRoleDto
            {
                Name = "Administrator",
                IsActive = true,
                IsSystemRole = true,
                SystemName = "administrator",
                Permissions = new List<Permission>
                {
                    Permission.AccessAdminPanel,
                    Permission.AccessAdminPanel,
                    Permission.CreateProducts,
                    Permission.ReadProducts,
                    Permission.UpdateProducts,
                    Permission.DeleteProducts,

                    Permission.CreateProductInstances,
                    Permission.ReadProductInstances,
                    Permission.UpdateProductInstances,
                    Permission.DeleteProductInstances,

                    Permission.ReadOrders,
                    Permission.ManageOrders
                }
            },
            new UserRoleDto
            {
                Name = "Guest",
                IsActive = true,
                IsSystemRole = true,
                SystemName = "guest",
                Permissions = new List<Permission>
                {
                    Permission.ReadProducts
                }
            }
        }.ToDictionary(x => x.Name);

        public IEnumerable<Permission> GetAllPermissionsForRole(string role)
        {
            return roles.ContainsKey(role) ? roles[role].Permissions : new List<Permission>();
        }

        public IEnumerable<string> GetAllRolesThatHavePermission(Permission permission)
        {
            var rolesThatHaveGivenPermission = new List<string>();

            foreach (var role in roles)
            {
                if (role.Value.Permissions.Contains(permission))
                {
                    rolesThatHaveGivenPermission.Add(role.Key);
                }
            }

            return rolesThatHaveGivenPermission;
        }
    }
}
