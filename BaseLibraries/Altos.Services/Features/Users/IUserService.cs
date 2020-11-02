using System.Threading.Tasks;
using Altos.Domain.Features.Users;

namespace Altos.Services.Features.Users
{
    public interface IUserService
    {
        Task<User> GetByEmailTaskAsync(string email);
    }
}
