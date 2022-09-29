using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using kevin.Models;
namespace kevin.Models;



public class StringController : Controller{
    StringProcess stPro = new StringProcess();
    public IActionResult XuLyChuoi(){
        return View();
    }
    [HttpPost]
    public IActionResult XuLyChuoi(string strInput){
       string str = stPro.RemoveRemainingWhiteSpace(strInput);
        str = stPro.LowerToUpper(strInput);
        str = stPro.UpperToLower(strInput);
        str = stPro.CapitalizeOneFirstCharacter(strInput);
        str = stPro.CapitalizeFirstCharacter(strInput);
        str = stPro.RemoveVietnameseAccents(strInput);
        
        ViewBag.ThongTin = str;
        return View();

    }


}
