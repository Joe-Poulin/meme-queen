using System;
using MemeWorker;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.MemeWorker
{
    [TestClass]
    public class WorkerTests
    {
        Worker memeWorker;
        ImgurWorker imgurWorker;

        [TestInitialize]
        public void Init()
        {
            memeWorker = new Worker();
            imgurWorker = new ImgurWorker();
        }

        [TestMethod]
        public void TestGetUrls()
        {
            var result = memeWorker.GetImageUrls("http://www.reddit.com/r/me_irl/top/", 10);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestGetImgurUrls()
        {
            var result = imgurWorker.GetImageUrls("https://imgur.com/r/memes/top/day", 10);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestDoImgurProcess()
        {
            imgurWorker.GetMemes();

            Assert.IsNull(null);
        }
    }
}
