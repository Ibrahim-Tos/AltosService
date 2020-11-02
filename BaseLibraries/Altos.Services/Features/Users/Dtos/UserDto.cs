using System;
using System.Collections.Generic;
using Altos.Domain.Features.Users;
using Altos.Services.Features.UserRoles.Dtos;
using Altos.Util.Application.Dto;
using AutoMapper;

namespace Altos.Services.Features.Users.Dtos
{
    [AutoMap(typeof(User))]
    public class UserDto : EntityDto
    {
        public Guid UserGuid { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public virtual ICollection<UserRoleDto> UserRoles { get; protected set; } = new List<UserRoleDto>();

        public override string ToString()
        {
            return $"{Id}-{Username}";
        }
    }
}
