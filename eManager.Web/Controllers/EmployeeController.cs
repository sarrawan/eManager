using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eManager.Web.Controllers
{
    public class EmployeeController : Controller
    {
        public ActionResult Create()
        {
            return View();
        }
    }
}