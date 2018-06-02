using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Security.Claims;

namespace APISample
{
    public class SystemAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(
            OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(
            OAuthGrantResourceOwnerCredentialsContext context)
        {
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            if (context.UserName == "admin" && context.Password == "admin")
            {
                identity.AddClaims(new Claim[]
                {
                    new Claim(ClaimTypes.Role, "admin"),
                    new Claim("username", "admin"),
                    new Claim(ClaimTypes.Name, "Sothea")
                });
                context.Validated(identity);
            }
            else if (context.UserName == "user" && context.Password == "user")
            {
                identity.AddClaims(new Claim[]
                {
                    new Claim(ClaimTypes.Role, "user"),
                    new Claim("username", "user"),
                    new Claim(ClaimTypes.Name, "Manith")
                });
                context.Validated(identity);
            }
            else
            {
                context.SetError("invalid_grant", "Provided invalid username or password");
                return;
            }
        }
    }
}