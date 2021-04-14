using System.Collections.Generic;
using InsecticDatabaseApi.Models;

namespace InsecticDatabaseApi.InsecticData
{
    public interface IUserData
    {
        List<User> GetAllUsers();

        User GetUser(string id);

        List<User> GetUsersBySupervisor(string supervisor);

        List<User> GetUserByResourceGroup(string group);

        List<User> GetUserByRole(string role);

        void AddUser(User user);

        void DeleteUser(string userId);

        void EditUser(User userId);
        

       
    }
}
