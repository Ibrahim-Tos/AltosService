using System.Linq;
using Altos.Domain.Features.Users;
using System.Threading.Tasks;

namespace Altos.Data.Features.Users
{
    public interface IUserCache
    {
        Task<User> Add(User user);
        Task<User> Update(User request);
        Task<IQueryable<User>> GetAll();
    }
}
