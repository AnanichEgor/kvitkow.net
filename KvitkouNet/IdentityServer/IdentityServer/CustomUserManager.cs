
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using IdentityServer.SecurityClient.Api;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace IdentityServer
{
    internal class CustomUserManager : UserManager<IdentityUser>
    {
        private IUserRightsApi _userRightsApi;

        public CustomUserManager(IUserStore<IdentityUser> store,
            IOptions<IdentityOptions> optionsAccessor,
            IPasswordHasher<IdentityUser> passwordHasher, 
            IEnumerable<IUserValidator<IdentityUser>> userValidators,
            IEnumerable<IPasswordValidator<IdentityUser>> passwordValidators, 
            ILookupNormalizer keyNormalizer,
            IdentityErrorDescriber errors, 
            IServiceProvider services, 
            ILogger<UserManager<IdentityUser>> logger,
            IUserRightsApi userRightsApi) : base(
            store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services,
            logger)
        {
            _userRightsApi = userRightsApi;
        }

        public override async Task<IList<Claim>> GetClaimsAsync(IdentityUser user)
        {
            this.ThrowIfDisposed();
            if ((object)user == null)
                throw new ArgumentNullException(nameof(user));
            CancellationToken cancellationToken = this.CancellationToken;
            return await UserManagerHelper.GetClaims(_userRightsApi.UserRightsGetUserRights(user.Id), cancellationToken);
        }
    }
}