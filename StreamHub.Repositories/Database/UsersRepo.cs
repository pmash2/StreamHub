using StreamHub.Database;
using StreamHub.Database.Models;
using System;
using System.Linq;

namespace StreamHub.Repositories.Database
{
    public class UsersRepo
    {
        public bool UserInDatabase(string username)
        {
            Users user = GetUser(username);

            return !(user is null);
        }

        public void AddUser(string username)
        {
            var user = new Users
            {
                Name = username,
                EntryDate = DateTime.Now
            };

            using (var context = new mashDbContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
        }

        public Users GetUser(string username)
        {
            Users user;
            using (var context = new mashDbContext())
            {
                user = context.Users.Where(x => x.Name == username).FirstOrDefault();
            }

            return user;
        }
    }
}
