using MemeWorker;
using Newtonsoft.Json;
using Repository.DataModels;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace MemeQueen.Controllers
{
    public class MainController : ApiController
    {
        private UserService UserService;
        private MemeService MemeService;

        private CancellationTokenSource WorkerTokenSource;
        private CancellationToken WorkerToken;
        private Task WorkerTask;

        public MainController()
        {
            this.UserService = new UserService();
            this.MemeService = new MemeService();
        }

        [System.Web.Http.HttpGet]
        public string Start()
        {
            var worker = new ImgurWorker();

            this.WorkerTokenSource = new CancellationTokenSource();

            WorkerTask = new Task(worker.GetMemes, WorkerTokenSource.Token);

            WorkerTask.Start();

            return "Started.";
        }

        [System.Web.Http.HttpGet]
        public string Stop()
        {
            WorkerTokenSource.Cancel();

            return "Stopped.";
        }

        [System.Web.Http.HttpGet]
        public HttpResponseMessage GetUsers()
        {
            var users = UserService.GetAllUsers();

            var response = new HttpResponseMessage();

            response.Content = new StringContent(JsonConvert.SerializeObject(users));
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return response;
        }

        [System.Web.Http.HttpGet]
        public HttpResponseMessage GetUserById(int id)
        {
            var user = UserService.GetUserById(id);

            var response = new HttpResponseMessage();

            response.Content = new StringContent(JsonConvert.SerializeObject(user));
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return response;
        }


        [System.Web.Http.HttpGet]
        public HttpResponseMessage GetMemes()
        {
            var memes = MemeService.GetAllMemess();

            var response = new HttpResponseMessage();

            response.Content = new StringContent(JsonConvert.SerializeObject(memes));
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return response;
        }

        [System.Web.Http.HttpGet]
        public HttpResponseMessage GetTest()
        {
            return new HttpResponseMessage() {
                Content = new StringContent("Successfully connected to MemeQueen controller."),
                StatusCode = HttpStatusCode.OK
            };
        }  
        
        [HttpPost]
        public HttpResponseMessage SaveUser(User user)
        {
            this.UserService.SaveUser(user);

            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
