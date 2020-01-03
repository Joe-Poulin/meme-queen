using System;
using System.Collections.Generic;
using EmailEngine;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.EmailEngine
{
    [TestClass]
    public class EmailServiceTests
    {
        private EmailService emailService;

        [TestInitialize]
        public void Init()
        {
            this.emailService = new EmailService();
        }

        [TestMethod]
        public void TestSendEmail()
        {
            this.emailService.SendEmail("josephdpoulin@gmail.com", "You're a big weenie", "You're a doodoohead");
        }

        [TestMethod]
        public void TestSendEmailWithImagesInBody()
        {
            this.emailService.SendEmailWithImagesInBody(
                "josephdpoulin@gmail.com",
                "testing multiple images",
                new List<string>() {
                    "https://i.redd.it/vjlumlxeyfj11.jpg",
                    "https://i.redd.it/ho1mabdopbj11.jpg",
                    "https://i.redd.it/thd526nw1fj11.jpg"
                }
            );
        }
    }
}
