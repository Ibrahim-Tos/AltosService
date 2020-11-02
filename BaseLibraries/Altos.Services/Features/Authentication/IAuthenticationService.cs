using System.Threading.Tasks;
using Altos.Services.Features.Authentication.Dtos;

namespace Altos.Services.Features.Authentication
{
    public interface IAuthenticationService
    {
        Task<UserLoginResult> LoginAsync(string email, string password);
        void Logout();
    }
}
