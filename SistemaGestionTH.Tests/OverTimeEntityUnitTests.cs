using SistemaGestionTH.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAssertions;
using SistemaGestionTH.Domain.Enum;
using SistemaGestionTH.Domain.Validations;

namespace SistemaGestionTH.Tests
{
    public class OverTimeEntityUnitTests
    {
        [Fact]
        public void EntityOverTime_ReasonParameter_ResultObjectValidState()
        {
            string reason = string.Empty;
            Action action = () => ValidateOverTimeEntity.Reason(reason);
            action.Should().Throw<DomainExceptionValidation>()
                  .WithMessage("El motivo es requerido");

        }

        [Fact]
        public void EntityOverTime_ShortReasonParameter_ResultObjectValidState()
        {
            string reason ="cd";
            Action action = () => ValidateOverTimeEntity.Reason(reason);
            action.Should().Throw<DomainExceptionValidation>()
                  .WithMessage("El motivo es muy corto");

        }

        [Fact]
        public void EntityOverTime_AddicionalTimeParameter_ResultObjectValidState()
        {
            int addTime = 0;
            Action action = () => ValidateOverTimeEntity.AdditionalTime(addTime);
            action.Should().Throw<DomainExceptionValidation>()
                  .WithMessage("Aun no has ingresado las horas extras de manera correcta");

        }

        [Fact]
        public void EntityOverTime_NameParameter_ResultObjectValidState()
        {
            var date = DateTime.Now;

            DateTime dateOfRequest = DateTime.Now.AddDays(1);
            Action action = () => ValidateOverTimeEntity.DateOfRequest(dateOfRequest);
            action.Should().Throw<DomainExceptionValidation>()
                  .WithMessage("la fecha de solicitud no puede ser mayor a la actual");

        }
    }
}
