
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ScholarshipApp.Controllers
{
    public class ApplicationController : Controller
    {
        [HttpGet]
        public ActionResult Apply()
        {
            return View();
        }
    }
}