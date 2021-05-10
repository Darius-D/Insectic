using System.Collections.Generic;
using System.Threading.Tasks;
using InsecticDatabaseApi.Models;
using InsecticDatabaseApi.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace InsecticDatabaseApi.InsecticData
{
    public interface IUserData
    {
        List<User> GetAllUsers();

        List<User> GetUsersBySupervisor(string supervisor);

        List<User> GetUserByResourceGroup(string group);

        //List<User> GetUserByRole(string role);

        void EditUser(User userId);
        

       
    }
}
