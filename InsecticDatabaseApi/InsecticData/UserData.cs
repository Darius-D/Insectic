using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InsecticDatabaseApi.Models;

namespace InsecticDatabaseApi.InsecticData
{
    public class UserData : IUserData
    {

        private InsecticContext _insecticContext;
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

        public void AddUser(User user)
        {
            
            _insecticContext.UsersList.Add(user);
            _insecticContext.SaveChanges();
        }

        public void DeleteUser(string userId)
        {
            var existingUser = _insecticContext.Tickets.Find(userId);

            _insecticContext.Tickets.Remove(existingUser);
            _insecticContext.SaveChanges();
        }

        public void EditUser(string userId)
        {
            var existingUser = _insecticContext.Tickets.Find(userId);


            _insecticContext.Tickets.Update(existingUser);
            _insecticContext.SaveChanges();
        }
    }
}
