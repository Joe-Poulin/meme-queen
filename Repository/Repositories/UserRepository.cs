using Repository.DataContexts;
using Repository.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class UserRepository
    {
        public IEnumerable<User> GetUsers()
        {
            using(var context = new MainDataContext())
            {
                var users = context.Users.ToList();

                // append custom messages
                foreach(var user in users)
                {
                    //user.CustomMessages = GetCustomMessagesForUser(user.Id);
                }

                return users;
            }
        }

        public IEnumerable<CustomMessage> GetCustomMessagesForUser(int userId)
        {
            using (var context = new MainDataContext())
            {
                var result = context.CustomMessages.Where(x => x.User.Id == userId).ToList();
                return result;
            }
        }

        public int AddUser(User user)
        {
            using(var context = new MainDataContext())
            {
                user.MemeTime = DateTime.Now;

                context.Users.Add(user);

                context.SaveChanges();

                return user.Id;
            }
        }

        public User GetUserById(int id)
        {
            using (var context = new MainDataContext())
            {
                return context.Users.Where(x => x.Id == id).FirstOrDefault();
            }
        }

        public int AddCustomMessage(CustomMessage message)
        {
            using(var context = new MainDataContext())
            {
                message.UserId = message.User.Id;
                message.User = null;

                context.CustomMessages.Add(message);

                context.SaveChanges();

                return message.Id;
            }
        }
    }
}
