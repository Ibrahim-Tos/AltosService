using System.Collections.Generic;

namespace Altos.Api.Framework.Infrastructure.Authorization
{
    public interface IPermissionPolicy
    {
        bool CanAccessEndpoint(Dictionary<string, object> arguments);
    }
}
