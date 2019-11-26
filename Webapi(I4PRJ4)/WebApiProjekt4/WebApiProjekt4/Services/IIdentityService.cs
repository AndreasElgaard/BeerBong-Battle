using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiProjekt4.Data.Dto;

namespace WebApiProjekt4.Services
{
    public interface IIdentityService
    {
        Task<AutehnticationResult> RegisterAsync(string userName, string passWord);
        Task<AutehnticationResult> LoginAsync(string userName, string passWord);
    }
}
