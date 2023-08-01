using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionTH.Domain.Validations
{
    public static class ValidateOverTimeEntity
    {
        public static void Reason(string reason)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(reason),
                "El motivo es requerido");
            DomainExceptionValidation.When(reason.Length < 10,
                "El motivo es muy corto");
        }

        public static void AdditionalTime(int additionalTime)
        {

            DomainExceptionValidation.When(additionalTime <= 0,
                "Aun no has ingresado las horas extras de manera correcta");
        }

        public static void DateOfRequest(DateTime dateOfRequest)
        {
            DomainExceptionValidation.When(dateOfRequest > DateTime.Now,
                "la fecha de solicitud no puede ser mayor a la actual");

        }
        
    }
}
