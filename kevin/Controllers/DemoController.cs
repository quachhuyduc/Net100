using Microsoft.AspNetCore.Mvc;

namespace kevin.Controllers;


public class DemoController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Index(int a, int b)
    {
        
        if(a <= 0)
        {
            if(b==0)
                {
                     ViewBag.Result = "Phuong trinh co vo so nghiem !";
                }
                else
                {
                    ViewBag.Result = "Phuong trinh vo nghiem !";
                }
        } else
        {
            ViewBag.Result = "Kết quả:" + (- b / a);
        }
        
        
        return View();
    }

    [HttpGet]
    public IActionResult Bt2()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Bt2(int a, int b, int c)
    {
        
        double x1, x2, delta;
        if (a == 0)
            {
                if (b == 0)
                {
                    if (c == 0)
                    {
                        ViewBag.Result = "Phuong trinh co vo so nghiem.";
                        
                    }
                    else
                    {
                        ViewBag.Result = "Phuong trinh vo nghiem.";
                    }
                }
                else
                {
                    x1 = (double)-c / b;
                    ViewBag.Result = " Phuong trinh co nghiem duy nhat x =" + Math.Round(x1, 2);
                }
            }
            else
            {
                //tính delta
                delta = Math.Pow(b, 2) - 4 * a * c;
                //kiểm tra nếu delta < 0 thì phương trình vô nghiệm
                if (delta < 0)
                {
                     ViewBag.Result = "Phuong trinh vo nghiem.";
                }
                //nếu delta = 0 thì phương trình có hai nghiệm kép
                else if (delta == 0)
                {
                    x1 = x2 = -b / (2 * a);
                    ViewBag.Result = "Phuong trinh co nghiem kep x1 = x2 = " + x1;
                }
                //nếu delta > 0 thì phuong trình có hai nghiệm phân biệt
                else
                {
                    x1 = (-b + Math.Sqrt(delta)) / (2 * a);
                    x2 = (-b - Math.Sqrt(delta)) / (2 * a);
                    ViewBag.Result = "Phuong trinh hai nghiem phan biet:X1 = " + x1 +" và " + "X2 = " + x2;
                }
            }
         
        return View();
    }
}