using FluentAssertions;
using SistemaGestionTH.Domain.Entities;
using SistemaGestionTH.Domain.Validations;
using Xunit;

namespace SistemaGestionTH.Tests
{
    public class AreasEntityUnitTests
    {
        [Fact]
        public void EntityArea_NameParameter_ResultObjectValidState()
        {
            Action action = () => new Areas(1, null);
              action.Should()
                    .Throw<DomainExceptionValidation>()
                    .WithMessage("El nombre del area es requerido");

        }
        [Fact]
        public void EntityArea_ShortNameParameter_ResultObjectValidState()
        {
            Action action = () => new Areas(1, "Ca");
            action.Should()
                  .Throw<DomainExceptionValidation>()
                  .WithMessage("El nombre del area es muy corto");

        }

    }
}