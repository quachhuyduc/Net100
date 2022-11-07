using System.ComponentModel.DataAnnotations;
namespace QuachHuyDucBTH2.Models
{
    public class Student {
        public string StudentID {get;set;}
        public string StudentName {get;set;}
         public string StudentAddress { get; set; }
        public string StudentPhone { get; set; }
        public string StudentEmail { get; set; }
    }
}