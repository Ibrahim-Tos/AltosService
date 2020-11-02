namespace Altos.Api.Features.Users.Authenticate
{
    public class AuthenticationRequest
    {
        public string Email { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }
    }
}
