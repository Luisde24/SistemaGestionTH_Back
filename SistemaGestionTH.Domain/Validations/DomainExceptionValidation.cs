using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionTH.Domain.Validations
{
    public class DomainExceptionValidation : Exception
    {
        public DomainExceptionValidation(string err): base(err)
        {

        }

        public static void When(bool hasError, string err)
        {
            if (hasError)
                throw new DomainExceptionValidation(err);
        }
    }
}
