using Microsoft.AspNet.Mvc;
using System;
using System.Linq;
using TheWorld.Models;
using TheWorld.Services;
using TheWorld.ViewModels;

namespace TheWorld.Controllers.Web
{
    public class AppController : Controller
    {
        private IMailService _mailService;
        private WorldRepository _repository;

        public AppController(IMailService service,WorldRepository repository)
        {
            _mailService = service;
            _repository = repository;
        }
        public IActionResult Index()
        {
            var trips = _repository.GetAllTrips();
            return View(trips);
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                var email = Startup.Configuration["AppSettings:SiteEmailAddress"];


                if (_mailService.SendMail(email
                      , model.Email
                      , $"Contact Page from {model.Name} ({model.Email})", model.Message))
                {
                    ModelState.Clear();

                    ViewBag.Message = "Message Send.Thanks!";
                }
            }
            return View();
        }
    }
}