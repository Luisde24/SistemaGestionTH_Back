using SistemaGestionTH.Application.EntitiesDtos;
using System.Text.RegularExpressions;

namespace SistemaGestionTH.API.Validation
{
    public static  class AccountValidation
    {
        public static bool validateLogin(LoginDto loginDto)
        {
            if ((loginDto.Email == null || loginDto.Email == "string") || !ValidationEmail(loginDto.Email))
                return true;
            else
                return false;

        }

        public static bool validateRegister(RegisterDto registerDto)
        {
            if ((registerDto.Email == null || registerDto.Email == "string") || !ValidationEmail(registerDto.Email))
                return true;
            else if((registerDto.Password  == null || registerDto.Password == "string") || !ValidationPassword(registerDto.Password)  || !ValidationComfirmPassword(registerDto.Password, registerDto.ConfirmPassword))
                return true;    
            else
                return false;

        }

        public static bool ValidationPassword(string password)
        {
            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMinimum8Chars = new Regex(@".{8,}");

           return  hasNumber.IsMatch(password) && hasUpperChar.IsMatch(password) && hasMinimum8Chars.IsMatch(password);
        }

        public static bool ValidationEmail(string email)
        {
            return Regex.IsMatch(email,
                              @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                              RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
        }

        public static bool ValidationComfirmPassword(string password, string comfirmPassword)
        {
            if (password.ToLower() == comfirmPassword.ToLower())
                return true;
            else
                return false;   
        }
    }
}
