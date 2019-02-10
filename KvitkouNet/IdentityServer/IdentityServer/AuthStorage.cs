using System.Collections.Generic;
using System.Security.Claims;
using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Test;

namespace IdentityServer
{
	public static class AuthStorage
	{
		public static IEnumerable<IdentityResource> GetIdentityResources()
		{
			return new IdentityResource[]
			{
				new IdentityResources.OpenId(),
				new IdentityResources.Profile(),
				new IdentityResource
				{
					Name = "role",
					UserClaims = new List<string> {"role"}
				}
			};
		}

		public static IEnumerable<ApiResource> GetApis()
		{
			return new ApiResource[]
			{
				new ApiResource
				{
					Name = "apiResource",
					DisplayName = "Custom API",
					Description = "Custom API Access",
					UserClaims = new List<string> {"role"},
					ApiSecrets = new List<Secret> {new Secret("scopeSecret".Sha256())},
					Scopes = new List<Scope>
					{
						new Scope("api")
					}
				}
			};
		}

		public static IEnumerable<Client> GetClients()
		{
			return new[]
			{
				new Client
				{
					ClientId = "oauthClient",
					ClientName = "Example Client Credentials Client Application",
					AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
					ClientSecrets = new List<Secret>
					{
						new Secret("superSecretPassword".Sha256())
					},
					AllowedScopes = new List<string> {"openid", "api"}
				}
			};
		}
		public static List<TestUser> Users = new List<TestUser>
		{
			new TestUser {
				SubjectId = "5BE86359-073C-434B-AD2D-A3932222DABE",
				Username = "admin",
				Password = "admin",
				Claims = new List<Claim> {
					new Claim(JwtClaimTypes.Email, "scott@scottbrady91.com"),
					new Claim(JwtClaimTypes.Role, "admin")
				}
			},
			new TestUser {
				SubjectId = "5BE86359-073C-434B-AD2D-A3932222DAEB",
				Username = "user1",
				Password = "user1",
				Claims = new List<Claim> {
					new Claim(JwtClaimTypes.Email, "bob@bobbrady91.com"),
					new Claim(JwtClaimTypes.Role, "user")
				}
			}
		};
	}
}