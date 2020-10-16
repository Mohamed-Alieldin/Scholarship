using ScholarshipApp.DataAccess;
using ScholarshipApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ScholarshipApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserRepository _userRepository;
        public HomeController()
        {
            _userRepository = new UserRepository();
        }
        public ActionResult Index()
        {            
            return View();
        }

        public ActionResult AdminSignIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminSignIn(string email, string password)
        {
            // we will use tempdata to keep both email and passwords as needed
            // This should be changed when sessions are configured
            User adminUser = _userRepository.AdminSignIn(email, password);
            if(adminUser != null)
            {
                // got to applications list
            }
            else
            {
                TempData["AdminSignInError"] = "True";
                return RedirectToAction("AdminSignIn");
            }
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(string email, string password)
        {
            // we will use tempdata to keep both email and passwords as needed
            // This should be changed when sessions are configured
            User studentUser = _userRepository.StudentSignIn(email, password);
            if(studentUser != null)
            {
                // go to student application to edit

            }
            else
            {
                TempData["StudentSignInError"] = "True";
                return RedirectToAction("Index");
            }


            return View();
        }
    }
}