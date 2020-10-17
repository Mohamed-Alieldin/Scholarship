using ScholarshipApp.DataAccess;
using ScholarshipApp.Models.Admin;
using ScholarshipApp.Models.Application;
using ScholarshipApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ScholarshipApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationRepository _applicationRepository;

        public AdminController()
        {
            _applicationRepository = new ApplicationRepository();
        }


        public ActionResult PreviewApplications()
        {
            ApplicationsListViewModel applications = _applicationRepository.GetAllApplications();
            return View(applications);
        }

        [HttpPost]
        public ActionResult DecideOnApplication(int id, int status)
        {
            if(id != 0 && (status == 1 || status == 0))
            {
                var isStatusUpdated = _applicationRepository.updateApplicationStatus(id, status);

                if (isStatusUpdated)
                {
                    return Json(new { success = true });
                }
            }
            return Json(new { success = false });
        }
    }
}