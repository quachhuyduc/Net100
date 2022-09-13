using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using kevin.Models;

namespace kevin.Controllers;

public class HomeController : Controller
{
   

    public IActionResult Index()
    {
        return View();
    }
    
public IActionResult Create(){
    return View();
}
[HttpPost]
public IActionResult Create(String FullName)
{
    string Message = "Heloo" + FullName;
    //Sử dụng viewbag để gửi dữ liệu từ controller
    ViewBag.ThongBao = Message;
    return View();
}
    
}

