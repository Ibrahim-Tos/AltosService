using System.Collections.Generic;
using Altos.Domain.Features.Security;
using Altos.Domain.Features.UserRoles;
using Altos.Util.Application.Dto;
using AutoMapper;

namespace Altos.Services.Features.UserRoles.Dtos
{
    [AutoMap(typeof(UserRole))]
    public class UserRoleDto : EntityDto
    {
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

        public bool EnablePasswordLifetime { get; set; }

        public IList<Permission> Permissions { get; set; }

        public override string ToString()
        {
            return $"{Id}-{Name}";
        }
    }
}
