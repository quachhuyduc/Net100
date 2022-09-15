namespace kevin.Models
{
       public class GiaiPhuongTrinh{
        public string GiaiPhuongTrinhBacNhat(string heSoA, string heSoB){
            double a,b,x;
            string ThongBao;
            a = Convert.ToDouble(heSoA);
            b = Convert.ToDouble(heSoB);
           
            if(a == 0){
                if(b != 0){
                    ThongBao = "PHUONG trinh vo nghiem";
                }else{
                    ThongBao = "Phuong trinh vo so nghiem";
                }

            }else{
                 x = -b/a;
                 ThongBao = "Phuong trinh co nghiem x = " + x;
            }
            return ThongBao;


        }
        public string GiaiPhuongTrinhBacHai(string heSoA, string heSoB,string heSoC){
            double a,b,c;
            double x1,x2,delta;
            string ThongBao;
            a = Convert.ToDouble(heSoA);
            b = Convert.ToDouble(heSoB);
            c = Convert.ToDouble(heSoC);
           
            if(a == 0){
                if(b == 0){
                    if(c == 0){
                        ThongBao = "Phuong trinh vo so nghiem";
                    }else{
                  ThongBao = "PHUONG trinh vo nghiem";
                }

            }else{
                x1 = (double)-c / b;
                ThongBao = " Phuong trinh co nghiem duy nhat x =" + Math.Round(x1, 2);              
            }
            }else{
                delta = (b*b) - (4*a*c);
                if (delta < 0)
                {
                     ThongBao = "Phuong trinh vo nghiem.";
                }
                
                else if (delta == 0)
                {
                    x1 = x2 = -b / (2 * a);
                    ThongBao = "Phuong trinh co nghiem kep x1 = x2 = " + x1;
                }
                
                else
                {
                    x1 = (-b + Math.Sqrt(delta)) / (2 * a);
                    x2 = (-b - Math.Sqrt(delta)) / (2 * a);
                    ThongBao = "Phuong trinh hai nghiem phan biet:X1 = " + x1 +" và " + "X2 = " + x2;
                }
            }
            return ThongBao;

       }
}
}