using System;
using System.Collections.Generic;
using Altos.Domain.Features.UserRoles;

namespace Altos.Api.Framework.Infrastructure.Authentication
{
    public class CurrentUser
    {
        public int UserId { get; set; }
        public Guid UserGuid { get; set; }
        public string Username { get; set; }
        public List<UserRole> UserRoles { get; set; }
    }
}
