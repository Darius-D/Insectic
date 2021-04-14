using System.Collections.Generic;
using System.Linq;
using InsecticDatabaseApi.Models;

namespace InsecticDatabaseApi.InsecticData
{
    public class UserData : IUserData
    {

        private readonly InsecticContext _insecticContext;
        public UserData(InsecticContext insecticContext)
        {
            _insecticContext = insecticContext;
        }
        public List<User> GetAllUsers()
        {
            return _insecticContext.UsersList.ToList();
        }

        public User GetUser(string id)
        {
            return _insecticContext.UsersList.Find(id);
        }

        public List<User> GetUsersBySupervisor(string supervisor)
        { 
            return GetAllUsers().Where(u => u.Supervisor == supervisor).ToList();
        }


        public List<User> GetUserByResourceGroup(string resourceGroup)
        {
            return GetAllUsers().Where(u => u.ResourceGroup == resourceGroup).ToList();
        }

        public List<User> GetUserByRole(string role)
        {
            return GetAllUsers().Where(u => u.UserRoles == role).ToList();
        }


        public void AddUser(User user)
        {
            
            _insecticContext.UsersList.Add(user);
            _insecticContext.SaveChanges();
        }

        public void DeleteUser(string userId)
        {
            var existingUser = _insecticContext.UsersList.Find(userId);

            _insecticContext.UsersList.Remove(existingUser);
            _insecticContext.SaveChanges();
        }


        public void EditUser(User user)
        {
            var existingUser = _insecticContext.UsersList.Find(user.UserId);

            
                existingUser.UserId = user.UserId;
                existingUser.ContactNumber = user.ContactNumber;
                existingUser.Email = user.Email;
                existingUser.FirstName = user.FirstName;
                existingUser.LastName = user.LastName;
                existingUser.ProfilePicture = user.ProfilePicture;
                existingUser.ResourceGroup = user.ResourceGroup;
                existingUser.UserRoles = user.UserRoles;
                existingUser.Supervisor = user.Supervisor;
                
                _insecticContext.UsersList.Update(existingUser);
                _insecticContext.SaveChanges();
            
        }
    }
}
