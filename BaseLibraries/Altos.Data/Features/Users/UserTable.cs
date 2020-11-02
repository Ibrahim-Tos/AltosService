using System;
using System.Collections.Concurrent;
using System.Linq;
using Altos.Domain.Features.Products;
using Altos.Domain.Features.Users;

namespace Altos.Data.Features.Users
{
    public class UserTable
    {
        private readonly ConcurrentDictionary<int, User> userTable = new ConcurrentDictionary<int, User>();

        public User Add(User user)
        {
            user.Id = userTable.Values.Count + 1;
            userTable[user.Id] = user;

            return userTable[user.Id];
        }

        public User Update(User user)
        {
            userTable[user.Id] = user;

            return userTable[user.Id];
        }

        public User Get(int id)
        {
            if (userTable.TryGetValue(id, out User user))
            {
                return user;
            }
            throw new Exception("Product not found");
        }

        public IQueryable<User> GetAll()
        {
            var users = userTable.Values;

            return users.AsQueryable();
        }

    }
}
