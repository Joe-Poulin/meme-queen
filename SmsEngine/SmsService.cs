using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Converters;
using Twilio.Rest.Api.V2010.Account;

namespace SmsEngine
{
    public class SmsService
    {
        public SmsService()
        {
            var accountSid = "AC52fa9f6b88167da3c629f2f07d531241";
            var authToken = "f1183c12c9fd7eb7696f00ffb4a3b4cf";

            TwilioClient.Init(accountSid, authToken);
        }

        /// <summary>
        /// Sends a text message
        /// </summary>
        /// <param name="message"></param>
        /// <param name="toNumber"></param>
        /// <param name="fromNumber"></param>
        public void SendText(string message, string toNumber, string fromNumber)
        {
            var result = MessageResource.Create(
                body: message,
                from: new Twilio.Types.PhoneNumber(fromNumber),
                to: new Twilio.Types.PhoneNumber(toNumber)
            );

            Console.WriteLine(result);
        }

        /// <summary>
        /// Sends an image
        /// </summary>
        /// <param name="imgUrl"></param>
        /// <param name="toNumber"></param>
        /// <param name="fromNumber"></param>
        public void SendMedia(string imgUrl, string toNumber, string fromNumber)
        {
            var message = MessageResource.Create(
                body: "Hello there!",
                from: new Twilio.Types.PhoneNumber(fromNumber),
                mediaUrl: Promoter.ListOfOne(new Uri(imgUrl)),
                to: new Twilio.Types.PhoneNumber(toNumber)
            );
        }

        /// <summary>
        /// Sends multiple images
        /// </summary>
        /// <param name="imgUrls"></param>
        /// <param name="toNumber"></param>
        /// <param name="fromNumber"></param>
        public void SendMedia(IEnumerable<string> imgUrls, string toNumber, string fromNumber)
        {
            foreach(var url in imgUrls)
            {
                SendMedia(url, toNumber, fromNumber);
            }
        }
    }
}
