using Altos.Services.Features.Users.Dtos;

namespace Altos.Services.Features.Authentication.Dtos
{
    public class UserLoginResult
    {
        public UserDto User { get; set; }
        public LoginResult LoginResult { get; set; }
        public string ErrorMessage { get; set; }
    }
}
