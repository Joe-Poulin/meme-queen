using EmailEngine;
using Repository.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MemeWorker
{
    public class Worker
    {
        private EmailService emailService;

        private List<User> queuedUsers;

        public Worker()
        {
            emailService = new EmailService();

            queuedUsers = new List<User>();
        }

        public void GetMemes()
        {
            while(true)
            {
                // if any users are queued, send their memes
                foreach (var user in queuedUsers)
                {
                    if (user.UseEmailAddress)
                    {
                        //get memes
                        var memes = GetImageUrls("http://www.reddit.com/r/me_irl/top/", 5);

                        //send memes
                        emailService.SendEmailWithImagesInBody(
                            user.EmailAddress,
                            string.Format("{0}'s Memes - {1}", user.FirstName, DateTime.Now.DayOfWeek),
                            memes
                        );
                    }
                }

                // clear queue
                queuedUsers = new List<User>();

                // get all users with MemeTime 1 minute from now

                // store that user in queue

                // wait until next minute
            }
        }

        public IEnumerable<string> GetImageUrls(string baseUrl, int amount)
        {
            var memeUrls = new List<string>();

            string html = "";

            // download HTML
            using (WebClient client = new WebClient())
            {
                html = client.DownloadString(baseUrl);
            }

            var containerClass = "<div class=\"scrollerItem ";
            var imgTag = "<img class=\"";

            var i = 0;

            while(i < amount)
            {
                // go to container
                var onlyContainer = html.Substring(html.IndexOf(containerClass));

                // go to img
                var img = onlyContainer.Substring(onlyContainer.IndexOf(imgTag));

                if(img.Contains(" media-element"))
                {
                    // go to img src
                    var src = img.Substring(img.IndexOf(" src=\"") + 6);

                    // go to url
                    var url = src.Substring(0, src.IndexOf('\"'));

                    if (url.Contains("renderTimingPixel") == false)
                    {
                        memeUrls.Add(url);

                        i++;
                    }

                    html = onlyContainer.Substring(onlyContainer.IndexOf(url));
                }
                else
                {
                    html = img;
                }


            }
        
            return memeUrls;
        }
    }
}
