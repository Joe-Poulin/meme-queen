using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmsEngine;

namespace UnitTests.SmsEngine
{
    [TestClass]
    public class SmsServiceTests
    {
        SmsService smsService;

        [TestInitialize]
        public void Init()
        {
            this.smsService = new SmsService();
        }

        [TestMethod]
        public void TestSendSms()
        {
            smsService.SendText("Joe is a dipshit", "+17152205642", "+16514136903");
        }

        [TestMethod]
        public void TestSendMedia()
        {
            smsService.SendMedia("https://i.redd.it/vjlumlxeyfj11.jpg", "+17152205642", "+16514136903");
        }

        [TestMethod]
        public void TestSendMedias()
        {
            var imgList = new List<string>()
            {
                "https://i.redd.it/vjlumlxeyfj11.jpg",
                "https://i.redd.it/ho1mabdopbj11.jpg",
                "https://i.redd.it/thd526nw1fj11.jpg"
            };

            smsService.SendMedia(imgList, "+17152205642", "+16514136903");
        }
    }
}
