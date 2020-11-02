using System.Collections.Generic;
using System.Linq;
using Altos.Domain.Features.Security;

namespace Altos.Domain.Features.UserRoles
{
    public static class UserRoleDefaults
    {
        public static readonly UserRole AdminRole = GetAdminRole();

        private static UserRole GetAdminRole()
        {
            var role = new UserRole
            {
                Name = "Administrator",
                IsActive = true,
                IsSystemRole = true,
                SystemName = "administrator"
            };

            AdminPermissions.ForEach(permission =>
            {
                role.PermissionRecordUserRoleMappings.Add(new PermissionRecordUserRoleMapping { PermissionRecord = new PermissionRecord { Name = permission.ToString() } });
            });

            return role;
        }

        public static readonly UserRole ClientRole = GetClientRole();

        private static UserRole GetClientRole()
        {
            var role = new UserRole
            {
                Name = "Guest",
                IsActive = true,
                IsSystemRole = true,
                SystemName = "guest"
            };

            ClientPermissions.ForEach(permission =>
            {
                role.PermissionRecordUserRoleMappings.Add(new PermissionRecordUserRoleMapping { PermissionRecord = new PermissionRecord { Name = permission.ToString() } });
            });

            return role;
        }
        public static readonly List<Permission> AdminPermissions =  new List<Permission>
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
        };

        public static readonly List<Permission> ClientPermissions = new List<Permission>
        {
            Permission.ReadProducts
        };

        public static readonly Dictionary<string, UserRole> Roles = new List<UserRole>
        {
            new UserRole
            {
                Name = "Administrator",
                IsActive = true,
                IsSystemRole = true,
                SystemName = "administrator",
                PermissionRecordUserRoleMappings = new List<PermissionRecordUserRoleMapping>
                {
                    new PermissionRecordUserRoleMapping { PermissionRecord = new PermissionRecord { Name = Permission.AccessAdminPanel.ToString()} },
                    new PermissionRecordUserRoleMapping { PermissionRecord = new PermissionRecord { Name = Permission.AccessAdminPanel.ToString()} },
                    new PermissionRecordUserRoleMapping { PermissionRecord = new PermissionRecord { Name = Permission.AccessAdminPanel.ToString()} },
                    new PermissionRecordUserRoleMapping { PermissionRecord = new PermissionRecord { Name = Permission.CreateProducts.ToString()} },
                    new PermissionRecordUserRoleMapping { PermissionRecord = new PermissionRecord { Name = Permission.ReadProducts.ToString()} },
                    new PermissionRecordUserRoleMapping { PermissionRecord = new PermissionRecord { Name = Permission.UpdateProducts.ToString()} },
                    new PermissionRecordUserRoleMapping { PermissionRecord = new PermissionRecord { Name = Permission.DeleteProducts.ToString()} },

                    new PermissionRecordUserRoleMapping { PermissionRecord = new PermissionRecord { Name = Permission.CreateProductInstances.ToString()} },
                    new PermissionRecordUserRoleMapping { PermissionRecord = new PermissionRecord { Name = Permission.ReadProductInstances.ToString()} },
                    new PermissionRecordUserRoleMapping { PermissionRecord = new PermissionRecord { Name = Permission.UpdateProductInstances.ToString()} },
                    new PermissionRecordUserRoleMapping { PermissionRecord = new PermissionRecord { Name = Permission.DeleteProductInstances.ToString()} },

                    new PermissionRecordUserRoleMapping { PermissionRecord = new PermissionRecord { Name = Permission.ReadOrders.ToString()} },
                    new PermissionRecordUserRoleMapping { PermissionRecord = new PermissionRecord { Name = Permission.ManageOrders.ToString()} }
                }
            },
            new UserRole
            {
                Name = "Guest",
                IsActive = true,
                IsSystemRole = true,
                SystemName = "guest",
                PermissionRecordUserRoleMappings = new List<PermissionRecordUserRoleMapping>
                {
                    new PermissionRecordUserRoleMapping { PermissionRecord = new PermissionRecord { Name = Permission.ReadProducts.ToString()} },
                }
            }
        }.ToDictionary(x => x.Name);
    }
}
