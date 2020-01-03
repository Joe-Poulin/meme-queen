using Repository.Repositories;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemeCrawler
{
    public class Crawler
    {
        private UserService UserService;

        public Crawler()
        {
            UserService = new UserService();
        }

        public void DoAction()
        {
            // get all users with MemeTime of Now
            var users = UserService.GetUsersWithMemeTimeOfNow();

            foreach(var user in users)
            {
                // grab memes for user

            }
        }
    }
}
