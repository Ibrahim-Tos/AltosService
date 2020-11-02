using Microsoft.AspNetCore.Mvc;

namespace Altos.Api.Framework.Infrastructure.Authorization
{
    public class AltosAuthorizationAttribute : TypeFilterAttribute
    {
        public AltosAuthorizationAttribute(string permission) : base(typeof(AltosAuthorizationFilter))
        {
            Arguments = new object[] { permission };
        }
    }

}
