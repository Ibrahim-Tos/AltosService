using System.Collections.Generic;
using Altos.Api.Framework.Infrastructure.Authorization;
using Altos.Domain.Features.Security;

namespace Altos.Api.Features.Products.CreateProductInstance
{
    public class CreateProductInstancePermissionPolicy : BasePermissionPolicy
    {
        public CreateProductInstancePermissionPolicy(
            IPermissionRepository permissionRepository) : base(permissionRepository)
        {
            var test = "test";
        }

        public override bool CanAccessEndpoint(Dictionary<string, object> arguments)
        {
            //ToDo: check if current user is in the current company (Organization)
            return this.HaveAccess(Permission.CreateProductInstances);
        }
    }
}
