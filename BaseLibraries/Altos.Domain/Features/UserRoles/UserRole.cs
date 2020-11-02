using System.Collections.Generic;
using Altos.Domain.Features.Security;

namespace Altos.Domain.Features.UserRoles
{
    /// <summary>
    /// Represents a customer role
    /// </summary>
    public partial class UserRole : BaseEntity
    {
        private ICollection<PermissionRecordUserRoleMapping> _permissionRecordUserRoleMappings;
        private ICollection<UserRoleMapping> _userRoleMappings;

        /// <summary>
        /// Gets or sets the user role name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the user role is active
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the user role is system
        /// </summary>
        public bool IsSystemRole { get; set; }

        /// <summary>
        /// Gets or sets the user role system name
        /// </summary>
        public string SystemName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the users must change passwords after a specified time
        /// </summary>
        public bool EnablePasswordLifetime { get; set; }

        #region Navigation properties

        /// <summary>
        /// Gets or sets the permission record-user role mappings
        /// </summary>
        public virtual ICollection<PermissionRecordUserRoleMapping> PermissionRecordUserRoleMappings
        {
            get => _permissionRecordUserRoleMappings ?? (_permissionRecordUserRoleMappings = new List<PermissionRecordUserRoleMapping>());
            set => _permissionRecordUserRoleMappings = value;
        }

        /// <summary>
        /// Gets or sets user-user role mappings
        /// </summary>
        public virtual ICollection<UserRoleMapping> UserRoleMappings
        {
            get => _userRoleMappings ?? (_userRoleMappings = new List<UserRoleMapping>());
            protected set => _userRoleMappings = value;
        }

        #endregion
    }
}
