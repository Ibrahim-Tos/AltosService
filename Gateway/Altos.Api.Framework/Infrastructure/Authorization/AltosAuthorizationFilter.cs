using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Altos.Api.Framework.Infrastructure.Authorization
{
    public class AltosAuthorizationFilter : IAuthorizationFilter
    {
        private string permission;

        public AltosAuthorizationFilter(string permission)
        {
            this.permission = permission;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            //we should round it no matter of "ShoppingCartSettings.RoundPricesDuringCalculation" setting
            //var _permissionService = EngineContext.Current.Resolve<IPermissionService>();

            var isAuthorize = true;// _permissionService.Authorize("permission"); // resolve permission service
            if (!isAuthorize)
            {
                context.Result = new ForbidResult();
            }

        }
    }
}
