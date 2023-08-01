using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionTH.Domain.Interfaces
{
    public interface IAuthenticate
    {
        Task<bool> Authentication(string email, string password);
        Task<bool> RegisterUser(string email, string password);
        Task Logout();

    }
}
