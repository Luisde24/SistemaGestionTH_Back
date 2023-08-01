using SistemaGestionTH.Application.EntitiesDtos;
using SistemaGestionTH.Domain.Enum;

namespace SistemaGestionTH.API.Validation
{
    public static class AreasValidation
    {

        public static bool ValidationIdAreaDto(long? id)
        {
            if ( id == null)
                return true;
            else
                return false;
        }

        public static bool ValidationCreateAreaDto(AreasDto areaDto)
        {
            if ((areaDto.Name == null || areaDto.Name == "string") )
                return true;
            else
                return false;
        }

        public static bool ValidationUpdateAreaDto(AreasDto areaDto)
        {
            if ((areaDto.Name == null || areaDto.Name == "string") || areaDto.Id == 0 )
                return true;
            else
                return false;
        }

    }
}
