using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DataAccess;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using Microsoft.Owin.Security.OAuth.Messages;
using System;

namespace WebAPI
{
    public class MyAuthProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            await Task.Run(()=> context.Validated()); //validate the client 
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            //validate credentials and generate token
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);

            InventdbEntities dbContext = new InventdbEntities();
            
            try
            {
                var userData = dbContext.UserLogins.FirstOrDefault(u=>u.UserName == context.UserName);

                if (userData != null)
                {
                    identity.AddClaim(new Claim(ClaimTypes.Role, userData.UserRole));
                    identity.AddClaim(new Claim(ClaimTypes.Name, userData.UserName));
                    identity.AddClaim(new Claim("LoggedOn", DateTime.Now.ToString()));
                    identity.AddClaim(new Claim("ID",userData.ID.ToString()));
                    await Task.Run(() => context.Validated(identity));
                }
                else
                {
                    context.SetError("Wrong Credentials", "Provided username and password is incorrect");
                }
            }
            catch
            {
                context.SetError("Wrong Credentials", "Provided username and password is incorrect");
            }
            return;

        }

    }  
  
}