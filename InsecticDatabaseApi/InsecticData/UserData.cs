using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InsecticDatabaseApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


//todo: This entire class should be tested again
namespace InsecticDatabaseApi.InsecticData
{
    public class UserData : IUserData
    {

        private UserManager<User> UserMgr { get; }
        private SignInManager<User> SignInMgr { get; }
        public UserData(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            UserMgr = userManager;
            SignInMgr = signInManager;
        }
        public  List<User> GetAllUsers()
        {
            var results = UserMgr.Users.ToListAsync();
            return results.Result;

        }

        public async Task<User> GetUser(string userName)
        {
            var result = await UserMgr.FindByNameAsync(userName);
            return result;
        }

        public List<User> GetUsersBySupervisor(string supervisor)
        { 
            return GetAllUsers().Where(u => u.Supervisor == supervisor).ToList();
        }


        public List<User> GetUserByResourceGroup(string resourceGroup)
        {
            return GetAllUsers().Where(u => u.ResourceGroup == resourceGroup).ToList();
        }

        //todo: insert Identity Role manager
        //public List<User> GetUserByRole(string role)
        //{
        //    return GetAllUsers().Where(u => u.UserRoles == role).ToList();
        //}

        //todo:test out method
        public async Task DeleteUser(string userEmail)
        {
            var existingUser  = await UserMgr.FindByEmailAsync(userEmail);
            await UserMgr.DeleteAsync(existingUser);
        }

        //todo: test method
        public async void EditUser(User user)
        {
            var existingUser = await UserMgr.UpdateAsync(user);
        }
    }
}
