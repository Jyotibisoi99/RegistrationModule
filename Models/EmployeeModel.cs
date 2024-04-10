using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;


namespace Registration_Project.Models
{
    public class EmployeeModel
    {
        public int EmployeeId { set; get; }
        public string EmpId { get; set; }
        public string EmpName { set; get; }

        //[Remote("IsEmailAvailable", "Registration", ErrorMessage="Email is already exist")]
        public string EmailId { set; get; }
        public string Password { set; get; }
        public string ConfirmPassword { set; get; }
        public int Age { set; get; }
        public string Phone { set; get; }
        public string Address { set; get; }
        public string Gender { set; get; }
        public string BloodGroup { set; get; }
        public string Designation { set; get; }
        public string DOJ { set; get; }
        public decimal Salary { set; get; }
        public bool ISactive { set; get; } 
        public int DepartmentId { set; get; }
        public string DepartmentName { set; get; }

       
    }
}