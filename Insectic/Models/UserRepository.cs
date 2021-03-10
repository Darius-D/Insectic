using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Insectic.Models
{
    public class UserRepository
    {
        private static List<User> users = new List<User>();

        public static IEnumerable<User> Users => users;

        public static void AddUser(User user)
        {
            users.Add(user);
        }
    }
}
