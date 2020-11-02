using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Altos.Domain.Features.UserRoles;

namespace Altos.Domain.Features.Users
{
    /// <summary>
    /// Represents a customer
    /// </summary>
    public partial class User : BaseEntity
    {
        private ICollection<UserRoleMapping> _userRoleMappings;
        private IList<UserRole> _userRoles;

        public User()
        {
            UserGuid = Guid.NewGuid();
        }

        public User(string username,
            string email,
            string password)
        {
            UserGuid = Guid.NewGuid();
            Username = username;
            Email = email;
            Password = password;
        }

        /// <summary>
        /// Gets or sets the User GUID
        /// </summary>
        public Guid UserGuid { get; set; }

        /// <summary>
        /// Gets or sets the username
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the password
        /// </summary>
        public string Password { get; set; }


        #region Navigation properties

        /// <summary>
        /// Gets or sets user roles
        /// </summary>
        [NotMapped]
        public virtual IList<UserRole> UserRoles
        {
            get => _userRoles ?? (_userRoles = UserRoleMappings.Select(mapping => mapping.UserRole).ToList());
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

        #region Methods

        /// <summary>
        /// Add user role and reset user roles cache
        /// </summary>
        /// <param name="userRoleMapping">User role mapping</param>
        public void AddUserRoleMapping(UserRoleMapping userRoleMapping)
        {
            UserRoleMappings.Add(userRoleMapping);
            _userRoles = null;
        }

        /// <summary>
        /// Remove user role and reset user roles cache
        /// </summary>
        /// <param name="userRoleMapping">User role mapping</param>
        public void RemoveUserRoleMapping(UserRoleMapping userRoleMapping)
        {
            UserRoleMappings.Remove(userRoleMapping);
            _userRoles = null;
        }

        #endregion
    }
}
