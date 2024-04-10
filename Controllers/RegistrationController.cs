using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Registration_Project.Models;
using Registration_Project.DAL;


namespace Registration_Project.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: Registration
        [HttpGet]
        public ActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Insert(EmployeeModel emp)
        {


            Registrationdal obj = new Registrationdal();
            emp.ISactive = true;
            obj.InsertEmployee(emp);
            TempData["imessage"] = "Record inserted successfuly";

            return RedirectToAction("DisplayEmpList");
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            Registrationdal obj1 = new Registrationdal();
            var str = obj1.DisplayEmployee(id).Find(e => e.EmployeeId == id);
            return View(str);
        }
        [HttpPost]
        public ActionResult Update(EmployeeModel obj)
        {
            Registrationdal obj1 = new Registrationdal();
            obj.ISactive = true;
            obj1.UpdateEmployee(obj);
            TempData["umessage"] = "Employee spdated successfully";
            return RedirectToAction("DisplayEmpList");
        }
        // [Route("EmployeeRecords")]
        // [ActionName ("DisplayEmpRecords")]
        public ActionResult DisplayEmpList(int? id)
        {
            Registrationdal obj = new Registrationdal();
            var model = obj.DisplayEmployee(id);
            return View(model);

            //return View(obj.Display());
        }

        public JsonResult FindActiveStatus(int? AtiveResult, int? txtSearchResult)
        {

            Registrationdal obj = new Registrationdal();
            var ActiveStatus = obj.DisplayEmployee(AtiveResult, txtSearchResult);
            return Json(ActiveStatus, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        //public ActionResult Find(int id)
        //{
        //    Registrationdal obj = new Registrationdal();
        //    EmployeeModel emp = obj.GetEmployee(id);
        //    return View(emp);
        //}

        public ActionResult Delete(int id)
        {
            EmployeeModel obj = new EmployeeModel() { EmployeeId = id, ISactive = false };
            Registrationdal obj1 = new Registrationdal();
            obj1.DeleteEmp(obj);
            TempData["dmessage"] = "Record deleted successfully";
            return RedirectToAction("DisplayEmpList");

        }
        public JsonResult IsEmailAvailable(string email)
        {
            Registrationdal obj = new Registrationdal();
            //bool isEmailAvailable = obj.CheckEmail(email);
            if (obj.CheckEmail(email))
                return Json("Found", JsonRequestBehavior.AllowGet);
            else
                return Json("Not found", JsonRequestBehavior.AllowGet);
        }
        public RedirectToRouteResult GetDeptEmployee(int id, string deptName)
        {
            if (deptName == "IT")
            {
                Registrationdal dalobj = new Registrationdal();
                var itResult = dalobj.DisplayEmployee(id).Find(e => e.EmployeeId == id);
                TempData["getItEmp"] = itResult;
                return RedirectToAction("ITDepartment", "Department");

            }
            else if (deptName == "Operation")
            {
                Registrationdal dalobj = new Registrationdal();
                var optResult = dalobj.DisplayEmployee(id).Find(model => model.EmployeeId == id);
                TempData["getOptEmp"] = optResult;
                return RedirectToAction("OperationsDepartment", "Department");
            }
            else
            {

            }
            return RedirectToAction("ITDepartment", "Department");
        }
        public ActionResult Find2(int id)
        {
            Registrationdal obj = new Registrationdal();
          var str=obj.DisplayEmployee(id).Find(emp => emp.EmployeeId == id);

            return View(str);

        }
    }
}