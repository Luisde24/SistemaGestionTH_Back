using FluentAssertions;
using SistemaGestionTH.Domain.Enum;
using SistemaGestionTH.Domain.Validations;

namespace SistemaGestionTH.Tests
{
    public class EmployeesEntityUnitTests
    {
        [Fact]
        public void EntityEmployees_NameParameter_ResultObjectValidState()
        {
            string name = string.Empty;
            Action action = () => ValidateEmployeesEntity.Name(name);
            action.Should().Throw<DomainExceptionValidation>()
                  .WithMessage("El nombre del empledado es requerido");

        }

        [Fact]
        public void EntityEmployees_ShortNameParameter_ResultObjectValidState()
        {
            string name = "cs";
            Action action = () => ValidateEmployeesEntity.Name(name);
            action.Should().Throw<DomainExceptionValidation>()
                  .WithMessage("El motivo ingresado es muy corto, Digite su nombre correcto");

        }

        [Fact]
        public void EntityEmployees_LastNameParameter_ResultObjectValidState()
        {
            string lastName = string.Empty;
            Action action = () => ValidateEmployeesEntity.LastName(lastName);
            action.Should().Throw<DomainExceptionValidation>()
                  .WithMessage("El apellido del empleado es requerido");
        }

        [Fact]
        public void EntityEmployees_ShortLastNameParameter_ResultObjectValidState()
        {
            string lastName = "ss";
            Action action = () => ValidateEmployeesEntity.LastName(lastName);
            action.Should().Throw<DomainExceptionValidation>()
                  .WithMessage("El apellido ingresado es muy corto, Digite su apellido correcto");
        }

        [Fact]
        public void EntityEmployees_TypeIdentificationParameter_ResultObjectValidState()
        {
            TypeIdentificactionEnum typeIdentification = 0;
            Action action = () => ValidateEmployeesEntity.TypeIdentification(typeIdentification);
            action.Should().Throw<DomainExceptionValidation>()
                  .WithMessage("El tipo de identificación no es correcto");
        }

        [Fact]
        public void EntityEmployees_IdentificationParameter_ResultObjectValidState()
        {
            string identification = string.Empty;
            Action action = () => ValidateEmployeesEntity.Identification(identification);
            action.Should().Throw<DomainExceptionValidation>()
                  .WithMessage("La identificación es requerido");
        }

        [Fact]
        public void EntityEmployees_EmailParameter_ResultObjectValidState()
        {
            string email = string.Empty;
            Action action = () => ValidateEmployeesEntity.Email(email);
            action.Should().Throw<DomainExceptionValidation>()
                  .WithMessage("El correo electronico es requerido");
        }

        [Fact]
        public void EntityEmployees_PhoneParameter_ResultObjectValidState()
        {
            string phone = string.Empty;
            Action action = () => ValidateEmployeesEntity.Phone(phone);
            action.Should().Throw<DomainExceptionValidation>()
                  .WithMessage("El celular es requerido");
        }

    }
    
}
