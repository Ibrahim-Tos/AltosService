using Altos.Domain.Features.Users;

namespace Altos.Domain.Features.UserRoles
{
    /// <summary>
    /// Represents a user-user role mapping class
    /// </summary>
    public partial class UserRoleMapping : BaseEntity
    {
        public UserRoleMapping() { }

        public UserRoleMapping(int userId, int userRoleId)
        {
            UserId = userId;
            UserRoleId = userRoleId;
        }

        /// <summary>
        /// Gets or sets the user identifier
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the user role identifier
        /// </summary>
        public int UserRoleId { get; set; }

        /// <summary>
        /// Gets or sets the customer
        /// </summary>
        public virtual User User { get; set; }

        /// <summary>
        /// Gets or sets the customer role
        /// </summary>
        public virtual UserRole UserRole { get; set; }
    }
}
