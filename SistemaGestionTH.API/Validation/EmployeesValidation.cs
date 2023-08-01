using SistemaGestionTH.Application.EntitiesDtos;
using SistemaGestionTH.Domain.Enum;
using System.Text.RegularExpressions;

namespace SistemaGestionTH.APIResfull.Validation
{
    public static class EmployeesValidation
    {

        public static bool ValidationCreateEmployeesDto(EmployeesDto employeesDto)
        {
            if ((employeesDto.Name == null || employeesDto.Name == "string") || (employeesDto.Lastname == null || employeesDto.Lastname == "string") || !ValidateNumber(employeesDto.Phone) || employeesDto.AreaId == 0)
                return true;
            else if (!ValidateNumber(employeesDto.Identification) || (employeesDto.Email == null || employeesDto.Email == "string") || !ValidationEmail(employeesDto.Email) )
                return true;
            else if (!ValidateEnums(typeof(TypeIdentificactionEnum), employeesDto.TypeIdentification))
                return true;
            else
                return false;
        }

        public static bool ValidationUpdateEmployeesDto(EmployeesDto employeesDto)
        {
            if ((employeesDto.Name == null || employeesDto.Name == "string") || (employeesDto.Lastname == null || employeesDto.Lastname == "string") || !ValidateNumber(employeesDto.Phone) || employeesDto.AreaId == 0 || employeesDto.Id == 0)
                return true;
            else if (!ValidateNumber(employeesDto.Identification) || (employeesDto.Email == null || employeesDto.Email == "string") || !ValidationEmail(employeesDto.Email))
                return true;
            else if (!ValidateEnums(typeof(TypeIdentificactionEnum), employeesDto.TypeIdentification))
                return true;
            else
                return false;
        }

        public static bool ValidationIdEmployeesDto(long? id)
        {
            if (id == 0 || id == null)
                return true;
            else
                return false;
        }

        public static bool ValidateEnums(Type enumerable, int value)
        {
            if (System.Enum.IsDefined(enumerable, value))
                return true;
            else
                return false;
        }

        public static bool ValidateNumber(string phone)
        {
            string pattern = "^[0-9]+$";

            return Regex.IsMatch(phone, pattern);
        }

        public static bool ValidationEmail(string email)
        {
            return Regex.IsMatch(email,
                              @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                              RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
        }
    }
}
