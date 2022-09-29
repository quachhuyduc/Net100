
using System.Text.RegularExpressions;
namespace kevin.Models
{
    public class StringProcess{
        public string RemoveRemainingWhiteSpace(string strInput){
            string strResult ="";
            strInput = strInput.Trim();
            while(strInput.IndexOf("  ") >0){
            strInput = strInput.Replace("  "," ");
            }
            strResult = strInput;
            return strInput;
            
        }
        public string LowerToUpper (string strInput){
            string strResult ="";
            strInput = strInput.ToUpper();
            strResult = strInput;
            return strInput;
        }
         public string UpperToLower (string strInput){
            string strResult ="";
            strInput = strInput.ToLower();
            strResult = strInput;
            return strInput;
        }
        public string CapitalizeOneFirstCharacter (string strInput){
           string strResult ="";
           string strInput1 = strInput.Substring(0, 1);
           string strInput2 = strInput.Substring(1);

           strInput1 = strInput1.ToUpper();
           strInput = strInput1 + strInput2;
           strResult = strInput;
           return strInput;
        }
        public string CapitalizeFirstCharacter (string strInput){
             string result = "";

            //lấy danh sách các từ  

            string[] words = strInput.Split(' ');

            foreach (string word in words)
            {
                // từ nào là các khoảng trắng thừa thì bỏ  
                if (word.Trim() != "")
                {
                    if (word.Length > 1)
                        result += word.Substring(0, 1).ToUpper() + word.Substring(1).ToLower() + " ";
                    else
                        result += word.ToUpper() + " ";
                }

            }
            return result.Trim();
        }
        public string RemoveVietnameseAccents (string strInput){
            string result = strInput.ToLower();
         result = Regex.Replace(result, "à|á|ạ|ả|ã|â|ầ|ấ|ậ|ẩ|ẫ|ă|ằ|ắ|ặ|ẳ|ẵ|/g", "a");
         result = Regex.Replace(result, "è|é|ẹ|ẻ|ẽ|ê|ề|ế|ệ|ể|ễ|/g", "e");
         result = Regex.Replace(result, "ì|í|ị|ỉ|ĩ|/g", "i");
         result = Regex.Replace(result, "ò|ó|ọ|ỏ|õ|ô|ồ|ố|ộ|ổ|ỗ|ơ|ờ|ớ|ợ|ở|ỡ|/g", "o");
        result = Regex.Replace(result, "ù|ú|ụ|ủ|ũ|ư|ừ|ứ|ự|ử|ữ|/g", "u");
         result = Regex.Replace(result, "ỳ|ý|ỵ|ỷ|ỹ|/g", "y");
         result = Regex.Replace(result, "đ", "d");
                return result;

        }
    }
}