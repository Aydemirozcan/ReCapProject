using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Core.Extensions
{
    public static class ClaimsPrincipalExtensions

    {
        public static List<string> Claims(this ClaimsPrincipal claimsPrincipal, string claimType)        // Bir kişini JWT den gelen claimlerini okumak için  ClaimsPrincipal adında.Net de olan bir class ı kullanırız.(Extend ediyorum)
        {
            var result = claimsPrincipal?.FindAll(claimType)?.Select(x => x.Value).ToList();
            return result;
        }

        public static List<string> ClaimRoles(this ClaimsPrincipal claimsPrincipal)   //Roller lazım olduğunda claimsPrincipal.ClaimRoles  yazdığımızda direk rolleri döndüren birşey yazdık.
        {
            return claimsPrincipal?.Claims(ClaimTypes.Role);
        }
    }




}
