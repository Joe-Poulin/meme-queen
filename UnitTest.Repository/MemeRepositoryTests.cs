using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository.DataModels;
using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Repository
{
    [TestClass]
    public class MemeRepositoryTests
    {
        MemeRepository repository;

        [TestInitialize]
        public void Init()
        {
            repository = new MemeRepository();
        }

        [TestMethod]
        public void TestAddMeme()
        {
            var meme = new Meme()
            {
                Url = "https://i.redd.it/9gwmg9kkijj11.jpg",
            };

            var result = repository.AddMeme(meme);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestAddMemes()
        {
            var memes = new List<Meme>() {
                new Meme() { Url = "https://i.redd.it/ez1464l4urn11.jpg" },
                new Meme() { Url = "https://i.redd.it/lefq32uzepn11.jpg" },
                new Meme() { Url = "https://i.redd.it/rg85up4v6rn11.jpg" },
                new Meme() { Url = "https://i.redd.it/puyt923bbon11.jpg" },
                new Meme() { Url = "https://i.redd.it/0o8zejxupnn11.jpg" },
                new Meme() { Url = "https://i.redd.it/1ronik0bdon11.jpg" },
                new Meme() { Url = "https://i.redditmedia.com/qPbPsiuyiKxTELUxtCHVQ-ccRLbfCMBoqf1KziNn0HU.jpg?s=7c7dd94e0911bfa192f568d001d29861" },
            };

            repository.AddMemes(memes);

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void TestGetMemes()
        {
            var result = repository.GetMemes();

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestGetMemeById()
        {
            var result = repository.GetMemeById(1);

            Assert.IsNotNull(result);
        }
    }
}
