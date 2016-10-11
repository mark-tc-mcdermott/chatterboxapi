using Microsoft.Owin.Security.OAuth;

namespace Providers.AuthProvider
{
    public class AuthProvider : OAuthAuthorizationServerProvider 
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {

            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            using (AuthRepository _repo = new AuthRepository())
            {
                IdentityUser user = await _repo.FindUser(context.UserName, context.Password);

                if (user == null)
                {
                    context.SetError("invalid_grant", "The user name or password is incorrect.");
                    return;
                }
            }

            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            ///identity.AddClaim(new Claim("username", context.UserName));
            identity.AddClaim(new Claim("user_id", context.userId));

            context.Validated(identity);
        }
    }
}