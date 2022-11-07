using System.ComponentModel.DataAnnotations;
namespace QuachHuyDucBTH2.Models
{
    public class Employee 
    {
        [Key]
          public string EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeAddress { get; set; }
        public string EmployeePhone { get; set; }
        public string EmployeeEmail { get; set; }
    }
}