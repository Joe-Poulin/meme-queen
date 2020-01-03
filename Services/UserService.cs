using Repository.DataModels;
using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class UserService
    {
        private UserRepository UserRepository;

        public UserService()
        {
            UserRepository = new UserRepository();
        }

        public IEnumerable<User> GetAllUsers()
        {
            return UserRepository.GetUsers();
        }

        public User GetUserById(int id)
        {
            var user = this.GetAllUsers().Where(x => x.Id == id).FirstOrDefault();

            return user;
        }

        public int SaveUser(User user)
        {
            var result = 0;

            if(user.Id == -1)
            {
                result = this.UserRepository.AddUser(user);
            }
            else
            {

            }

            return result;
        }

        public IEnumerable<User> GetUsersWithMemeTimeOfNextMinute()
        {
            return GetAllUsers()
                .Where(x => x.MemeTime.Hour == DateTime.Now.Hour &&
                x.MemeTime.Minute == DateTime.Now.AddMinutes(1).Minute)
                .ToList();
        }

        public IEnumerable<CustomMessage> GetCustomMessageForUser(int userId, DateTime date)
        {
            var messages = UserRepository.GetCustomMessagesForUser(userId);

            var todaysMessages = messages.Where(x => x.Date.DayOfYear == date.DayOfYear).ToList();

            return todaysMessages;
        }
    }
}
