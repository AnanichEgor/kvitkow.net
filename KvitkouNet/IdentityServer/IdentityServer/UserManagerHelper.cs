using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using IdentityServer.SecurityClient.Model;

namespace IdentityServer
{
    public class UserManagerHelper
    {
        public static async Task<IList<Claim>> GetClaims(UserRightsResponse userRightsResponse, CancellationToken cancellationToken)
        {
            var userRights = userRightsResponse.UserRights;
            if (userRights == null)
            {
                throw new InvalidOperationException(userRightsResponse.Message);
            }

            var roles = userRights.Roles.Select(l => new Claim( "role", l.Name));
            var functions = userRights.Roles.SelectMany(l => l.AccessFunctions)
                .Union(userRights.AccessFunctions).Select(l => l.FeatureName)
                .Distinct()
                .Select(l=> new Claim("function", l));

            var rights = userRights.Roles.SelectMany(l => l.AccessRights)
                .Union(userRights.AccessFunctions.SelectMany(l => l.AccessRights))
                .Union(userRights.AccessRights)
                .Select(l => l.Name)
                .Distinct()
                .Except(userRights.DeniedRights.Select(l => l.Name))
                .Select(l => new Claim("right", l));

            var result = new List<Claim>();

            result.AddRange(roles);
            result.AddRange(functions);
            result.AddRange(rights);
            return result;
        }
    }
}
