using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Registration_Project.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
      
        public ActionResult ITDepartment()
        {
            ViewBag.itResult  = TempData["getemp"];
            return View();
        }
        public ActionResult OperationsDepartment()
        {
            ViewData["OperationResult"] = TempData["getOptEmp"];
            return View();
        }
        public ActionResult HRDepartment()
        {
            return View();
        }
    }
}