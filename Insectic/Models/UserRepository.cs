using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Insectic.Models
{
    public class UserRepository
    {
        private static List<UserJsonModel> users = new List<UserJsonModel>();

        public static IEnumerable<UserJsonModel> Users => users;

        public static void AddUser(UserJsonModel user)
        {
            users.Add(user);
        }
    }
}
