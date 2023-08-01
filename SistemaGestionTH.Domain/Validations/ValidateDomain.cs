using SistemaGestionTH.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SistemaGestionTH.Domain.Validations
{
    public static class ValidateDomain
    {
        public static void ValidateDominanId(long Id)
        {
            DomainExceptionValidation.When(Id < 0, "El Id se ha implementado de manera Incorrecta");
        }

        public static void validationEmployees( string name, string lastName, TypeIdentificactionEnum typeIdenification, string identifiction, string email, string phone)
        {
            ValidateEmployeesEntity.Name(name);
            ValidateEmployeesEntity.LastName(lastName);
            ValidateEmployeesEntity.TypeIdentification(typeIdenification);
            ValidateEmployeesEntity.Identification(identifiction);
            ValidateEmployeesEntity.Email(email);
            ValidateEmployeesEntity.Phone(phone);
        }

        public static void validationAreas(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "El nombre del area es requerido");
            DomainExceptionValidation.When(name.Length < 3,
                "El nombre del area es muy corto");
        }

        public static void validationManejoHorasExtras(string reason, int additionalTime, DateTime dateOfRequest)
        {
            ValidateOverTimeEntity.Reason(reason);
            ValidateOverTimeEntity.AdditionalTime(additionalTime);
            ValidateOverTimeEntity.DateOfRequest(dateOfRequest);
        }

    }
}
