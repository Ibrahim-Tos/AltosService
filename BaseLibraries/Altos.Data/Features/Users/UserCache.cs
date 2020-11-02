using System.Linq;
using System.Threading.Tasks;
using Altos.Domain.Features.UserRoles;
using Altos.Domain.Features.Users;

namespace Altos.Data.Features.Users
{
    public class UserCache : IUserCache
    {
        private readonly UserTable userTable;

        public UserCache()
        {
            userTable = new UserTable();

            if(!userTable.GetAll().Any())
                AddTestData();
        }

        public Task<User> Add(User request)
        {
            var user = userTable.Add(request);

            return Task.FromResult(user);
        }

        public Task<User> Update(User request)
        {
            var user = userTable.Update(request);

            return Task.FromResult(user);
        }

        public Task<IQueryable<User>> GetAll()
        {
            var users = userTable.GetAll();

            return Task.FromResult(users);
        }

        private void AddTestData()
        {
            var adminUser = new User("Admin", "admin@altos.com", "Admin");
            adminUser.UserRoles.Add(UserRoleDefaults.AdminRole);
            userTable.Add(adminUser);

            var clientUser = new User("Client", "client@altos.com", "Client");
            clientUser.UserRoles.Add(UserRoleDefaults.ClientRole);
            userTable.Add(adminUser);
        }
    }
}
