using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using kevin.Models;

namespace kevin.Controllers;

    public class EmployeeController : Controller
    {
         //khai báo các action để làm việc với các Object
         //Thao tác Create,Read,Update,Delete
         public IActionResult Index()
         {
           List<Employee> eplList = new List<Employee>(){
            new Employee {EmployeeID = 1,EmployeeName = "Nguyen Van A", Age =18},
            new Employee {EmployeeID = 2,EmployeeName = "Nguyen Van V", Age =18},
            new Employee {EmployeeID = 3,EmployeeName = "Nguyen Van B", Age =18},
            new Employee {EmployeeID = 4,EmployeeName = "Nguyen Van C", Age =18},
            new Employee {EmployeeID = 5,EmployeeName = "Nguyen Van D", Age =18}


           };
           ViewData["Employee"] = eplList;
            return View();
         }
         public IActionResult Create(){
           return View();
}
         [HttpPost]
         public IActionResult Create(Employee epl)
         {
           // string message = epl.EmployeeID + "_";
           // message += epl.EmployeeName + "_";
           // message += epl.Age;
            //ViewBag.TT = message;
            return View();
         }
    }
