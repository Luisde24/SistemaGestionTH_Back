using SistemaGestionTH.Application.EntitiesDtos;
using SistemaGestionTH.Domain.Enum;

namespace SistemaGestionTH.API.Validation
{
    public static class OverTimeValidation
    {
        public static bool ValidationCreateOverTimeDto(ManagementOfOverTimeDto overTimeDto)
        {
            if ((overTimeDto.Reason == null || overTimeDto.Reason == "string") || (overTimeDto.Leader == null || overTimeDto.Leader == "string") )
                return true;
            else if (overTimeDto.EmployeesId == 0 || overTimeDto.AreaId == 0 || overTimeDto.AdditionalTime > 40 )
                return true;
            else if (!ValidateEnums(typeof(StateEnum), overTimeDto.State) || !ValidateEnums(typeof(TypeRemunerationEnum), overTimeDto.TypeRemuneration))
                return true;
            else
                return false;
        }

        public static bool ValidationUpdateOverTimeDto(ManagementOfOverTimeDto overTimeDto)
        {
            if ((overTimeDto.Reason == null || overTimeDto.Reason == "string") || (overTimeDto.Leader == null || overTimeDto.Leader == "string") || overTimeDto.Id == 0)
                return true;
            else if (overTimeDto.EmployeesId == 0 || overTimeDto.AreaId == 0 || (overTimeDto.AdditionalTime > 40 && overTimeDto.TypeRemuneration == 1) || (overTimeDto.AdditionalTime > 40 && overTimeDto.TypeRemuneration == 2))
                return true;
            else if (!ValidateEnums(typeof(StateEnum), overTimeDto.State) || !ValidateEnums(typeof(TypeRemunerationEnum), overTimeDto.TypeRemuneration))
                return true;
            else
                return false;
        }

        public static bool ValidationIdOverTimeDto(long? id)
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

    }
}
