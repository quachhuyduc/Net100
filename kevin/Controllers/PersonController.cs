using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using kevin.Models;

namespace kevin.Controllers;

    public class PersonController : Controller
    {
         //khai báo các action để làm việc với các Object
         //Thao tác Create,Read,Update,Delete
         public IActionResult Index()
         {
            
           List<Person> perList = new List<Person>(){
            new Person {PersonID = 1,PersonName = "Nguyen Van A", Age =18},
            new Person {PersonID = 2,PersonName = "Nguyen Van B", Age =18},
            new Person {PersonID = 3,PersonName = "Nguyen Van V", Age =18},
            new Person {PersonID = 4,PersonName = "Nguyen Van F", Age =18},
            new Person {PersonID = 5,PersonName = "Nguyen Van H", Age =18},

           };
           ViewData["Person"] = perList;
           
            return View();
         }
         public IActionResult Create(){
           return View();
         }
         [HttpPost]
         public IActionResult Create(Person per)
         {
            //string message = per.PersonID + "_";
            //message += per.PersonName + "_";
           // message += per.Age;
           // ViewBag.TT = message;
            return View();
         }
    }
    
