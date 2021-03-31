using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InsecticDatabaseApi.Models;

namespace InsecticDatabaseApi.InsecticData
{
    public interface IUserData
    {
        List<User> GetAllUsers();

        User GetUser(string id);

        void AddUser(User user);

        void DeleteUser(string userId);

        void EditUser(string userId);
    }
}
