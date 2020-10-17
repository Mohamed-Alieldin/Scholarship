
using ScholarshipApp.DataAccess;
using ScholarshipApp.Models.Application;
using ScholarshipApp.Repository;
using ScholarshipApp.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace ScholarshipApp.Controllers
{
    public class ApplicationController : Controller
    {
        private readonly FileUtility _fileUtility;
        private readonly UserRepository _userRepository;
        private readonly ApplicationRepository _applicationRepository;

        public ApplicationController()
        {
            _fileUtility = new FileUtility();
            _userRepository = new UserRepository();
            _applicationRepository = new ApplicationRepository();
        }

        [HttpGet]
        public ActionResult Apply()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Apply(ApplicationViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Save PDF File
                string resumeFileName = _fileUtility.SaveResume(model.Resume);

                // Add User
                User user = new User {
                    Email = model.Email,
                    Password = model.Password,
                    Role = "student"
                };

                int? userId = _userRepository.AddStudent(user);

                if(userId != null)
                {
                    DataAccess.Application applicationModel = new DataAccess.Application
                    {
                        UserId = (int)userId,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        BirthDate = model.BirthDate.ToShortDateString(),
                        NationalId = model.NationalId,
                        University = model.University,
                        Major = model.Major,
                        GPA = model.GPA,
                        ResumeFileName = resumeFileName,
                        IsAccepted = null
                    };

                    int? applicationId = _applicationRepository.AddApplication(applicationModel);

                    if(applicationId != null)
                    {
                        // Do something when submitted
                        TempData["SubmitSuccess"] = "True";
                        return RedirectToAction("Index", "Home");
                    }

                }
            }

            TempData["SubmitError"] = "True";
            return View();
        }

        public ActionResult Edit(int id)
        {
            var userApplication = _applicationRepository.GetApplication(id);
            if(userApplication != null)
            {
                ApplicationViewModel model = new ApplicationViewModel()
                {                    
                    Email = TempData["Email"].ToString(),
                    Password = TempData["Password"].ToString(),
                    FirstName = userApplication.FirstName,
                    LastName = userApplication.LastName,
                    BirthDate = Convert.ToDateTime(userApplication.BirthDate).Date,
                    NationalId = userApplication.NationalId,
                    University= userApplication.University,
                    Major = userApplication.Major,
                    GPA = userApplication.GPA
                };

                TempData["ApplicationId_TobeEdited"] = userApplication.Id;
                return View(model);
            }
            else
            {
                TempData["StudentGetApplicationError"] = "True";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult Edit(ApplicationViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Save PDF File
                
                string resumeFileName = model.Resume == null? null: _fileUtility.SaveResume(model.Resume);
                
                if (TempData["ApplicationId_TobeEdited"] != null)
                {
                    int? applicationId = _applicationRepository.EditApplication(model, (int)TempData["ApplicationId_TobeEdited"], resumeFileName);

                    if (applicationId != null)
                    {
                        TempData["EditSuccess"] = "True";
                        return RedirectToAction("Index", "Home");
                    }

                }
            }

            TempData["SubmitError"] = "True";
            return View();

        }
    }
}