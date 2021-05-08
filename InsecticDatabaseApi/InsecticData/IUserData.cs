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

        Task<User> GetUser(string id);

        List<User> GetUsersBySupervisor(string supervisor);

        List<User> GetUserByResourceGroup(string group);

        //List<User> GetUserByRole(string role);


        Task DeleteUser(string userEmail);

        void EditUser(User userId);
        

       
    }
}
