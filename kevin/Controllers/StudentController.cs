using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using kevin.Models;

namespace kevin.Controllers;

    public class StudentController : Controller
    {
         //khai báo các action để làm việc với các Object
         //Thao tác Create,Read,Update,Delete
         public IActionResult Index()
         {
           
            return View();
         }
         public IActionResult Create(){
           return View();
}
         [HttpPost]
         public IActionResult Create(Student std)
         {
            string message = std.StudentID + "_";
            message += std.StudentName + "_";
            message += std.Age;
            ViewBag.TT = message;
            return View();
         }
    }
