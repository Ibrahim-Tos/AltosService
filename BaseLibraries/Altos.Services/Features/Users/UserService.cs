using System.Linq;
using System.Threading.Tasks;
using Altos.Data.Features.Users;
using Altos.Domain.Features.Users;

namespace Altos.Services.Features.Users
{
    public class UserService : IUserService
    {
        private readonly IUserCache _userCache;

        public UserService(IUserCache userCache)
        {
            _userCache = userCache;
        }

        public async Task<User> GetByEmailTaskAsync(string email)
        {
            return (await _userCache.GetAll()).FirstOrDefault(user => user.Email == email);
        }
    }
}
