using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiProjekt4.Extensions
{
    public static class GeneralExtensions
    {
        public static string GetUserId(this HttpContext htttpContext)
        {
            if(htttpContext.User == null)
            {
                return string.Empty;
            }

            //returns userid from token
            return htttpContext.User.Claims.Single(x => x.Type == "id").Value;
        }
    }
}
