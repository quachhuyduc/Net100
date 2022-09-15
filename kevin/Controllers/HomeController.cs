using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using kevin.Models;

namespace kevin.Controllers;

public class HomeController : Controller
{
    GiaiPhuongTrinh gpt = new GiaiPhuongTrinh();
   

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
public IActionResult GiaiPhuongTrinh(){
    return View();
    
}
[HttpPost]
public IActionResult GiaiPhuongTrinh(string heSoA,string heSoB,string heSoC){
    string thongBaoBacNhat = gpt.GiaiPhuongTrinhBacNhat(heSoA,heSoB);
    string thongBaoBacHai = gpt.GiaiPhuongTrinhBacHai(heSoA,heSoB,heSoC);

    ViewBag.Message = thongBaoBacNhat;
    ViewBag.Message = thongBaoBacHai;
    
    return View();

}
    
}

