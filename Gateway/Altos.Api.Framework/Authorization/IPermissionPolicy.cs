using System.Collections.Generic;

namespace Altos.Api.Framework.Authorization
{
    public interface IPermissionPolicy
    {
        bool CanAccessEndpoint(Dictionary<string, object> arguments);
    }
}
