using ScholarshipApp.DataAccess;
using ScholarshipApp.Models.Admin;
using ScholarshipApp.Models.Application;
using ScholarshipApp.Repository;
using ScholarshipApp.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace ScholarshipApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationRepository _applicationRepository;
        private readonly UserRepository _userRepository;
        private readonly EmailUtility _emailUtility;

        public AdminController()
        {
            _applicationRepository = new ApplicationRepository();
            _userRepository = new UserRepository();
            _emailUtility = new EmailUtility();
        }


        public ActionResult PreviewApplications()
        {
            ApplicationsListViewModel applications = _applicationRepository.GetAllApplications();
            return View(applications);
        }

        [HttpPost]
        public ActionResult DecideOnApplication(int id, int status)
        {
            if (id != 0 && (status == 1 || status == 0))
            {
                var userId = _applicationRepository.updateApplicationStatus(id, status);

                if (userId != null)
                {
                    // Send email to student
                    var user = _userRepository.GetUser((int)userId);
                    var isEmailSent = _emailUtility.SendEmail(user.Email, status);
                    return Json(new { success = true });
                }
            }
            return Json(new { success = false });
        }
    }
}