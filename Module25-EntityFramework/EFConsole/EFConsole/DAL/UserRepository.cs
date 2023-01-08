using EFConsole.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace EFConsole.DAL
{
    public class UserRepository
    {
        private readonly AppContext _db = new AppContext();

        public List<User> GetAllUsers()
        {
            return _db.Users.ToList();
        }

        public User GetUserById(int id)
        {
            return _db.Users.FirstOrDefault(u => u.Id == id);
        }

        public void AddUser(User user)
        {
            _db.Users.Add(new User
            {
                Name = user.Name,
                Email = user.Email,
                Role = user.Role,
            });

            _db.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            var user = new User { Id = id };
            _db.Entry(user).State = EntityState.Deleted;
            _db.SaveChanges();
        }
        
        public void UpdateUserLastName(int id, string newName)
        {
            var user = _db.Users.FirstOrDefault(u => u.Id == id);
            user.Name = newName;

            _db.Entry(user).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public List<User> GetUsersByCompanyId(int companyId)
        {
            var usersQuery =
                    from user in _db.Users
                    where user.CompanyId == companyId
                    select user;

            return usersQuery.ToList();
        }
    }
}
