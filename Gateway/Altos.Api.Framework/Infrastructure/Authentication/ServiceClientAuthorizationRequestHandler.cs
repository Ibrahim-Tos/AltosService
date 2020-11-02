namespace Altos.Api.Framework.Infrastructure.Authentication
{
    public static class ServiceClientAuthorizationRequestHandler
    {
        public static void AddAuthorizationRequestHandler()
        {
            //HttpServiceClient.AddPreRequestHandler(x =>
            //{
            //    // Keep Authorization header in case it already exists
            //    if (x.Headers.ContainsKey("Authorization"))
            //    {
            //        return;
            //    }

            //    // Add authorization headers
            //    var accessToken = IdentityProvider.GetAccessToken();

            //    // Do not add any headers if there is no current user (anononymous call)
            //    if (accessToken == null)
            //    {
            //        return;
            //    }

            //    if (!string.IsNullOrWhiteSpace(accessToken.Token))
            //    {
            //        x.AddHeader("Authorization", $"{accessToken.Scheme} {accessToken.Token}");
            //    }
            //});
        }
    }
}
