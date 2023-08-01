using SistemaGestionTH.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SistemaGestionTH.Domain.Validations
{
    public static class ValidateEmployeesEntity
    {
        public static void Name(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "El nombre del empledado es requerido");
            DomainExceptionValidation.When(name.Length < 3,
               "El nombre ingresado es muy corto, Digite su nombre correcto");
        }
        public static void LastName(string lastname)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(lastname),
              "El apellido del empleado es requerido");
            DomainExceptionValidation.When(lastname.Length < 3,
               "El apellido ingresado es muy corto, Digite su apellido correcto");
        }
        public static void TypeIdentification(TypeIdentificactionEnum typeIdentification)
        {
            DomainExceptionValidation.When(typeIdentification <= 0,
                "El tipo de identificación no es correcto");
        }
        public static void Identification(string identification)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(identification),
            "La identificación es requerido");
         
        }
        public static void Email(string email)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(email),
             "El correo electronico es requerido");
        }
        public static void Phone(string phone) 
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(phone),
                "El celular es requerido");
        }

    }
}
