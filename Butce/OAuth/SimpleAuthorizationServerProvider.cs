using Entity;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.Owin.Security;

namespace Butce.OAuth
{
    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        // OAuthAuthorizationServerProvider sınıfının client erişimine izin verebilmek için ilgili ValidateClientAuthentication metotunu override ediyoruz.
        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            return base.ValidateClientAuthentication(context);
        }

        //public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        //{
        //    string clientId = string.Empty;
        //    string clientSecret = string.Empty;


        //    if (!context.TryGetBasicCredentials(out clientId, out clientSecret))
        //    {
        //        context.TryGetFormCredentials(out clientId, out clientSecret);
        //    }

        //    if (context.ClientId == null)
        //    {
        //        //Remove the comments from the below line context.SetError, and invalidate context 
        //        //if you want to force sending clientId/secrects once obtain access tokens. 
        //        context.Validated();
        //        //context.SetError("invalid_clientId", "ClientId should be sent.");
        //        return Task.FromResult<object>(null);
        //    }
        //    context.Validated();
        //}

        // OAuthAuthorizationServerProvider sınıfının kaynak erişimine izin verebilmek için ilgili GrantResourceOwnerCredentials metotunu override ediyoruz.
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            // CORS ayarlarını set ediyoruz.
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            // Kullanıcının access_token alabilmesi için gerekli validation işlemlerini yapıyoruz.
          
            using (EvdekiHesapContext _repo = new EvdekiHesapContext())
            {
                User user = null;
                try
                {
                    user = _repo.Users.Where(x => x.UserName == context.UserName && x.PassWord == context.Password).FirstOrDefault();
                }
                catch (Exception ex)
                {

                    throw;
                }
               

                if (user != null)
                {
                    var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                    identity.AddClaim(new Claim("UserName", user.UserName));
                    identity.AddClaim(new Claim("role", "user"));
                 
                    var ticket = new AuthenticationTicket(identity, new AuthenticationProperties());
                    context.Validated(ticket);
                    // user.Token = ???  At this point I want to save the genereted token to the DB. ??
                 //   _repo.SaveChanges();
                    //vacontext.Response.Body.ToString();
                }
                else
                {
                    context.SetError("invalid_grant", "The user name or password is incorrect.");
                    return;
                }
            }
           
        }


        //public override Task TokenEndpointResponse(OAuthTokenEndpointResponseContext context)
        //{
        //    string ttoken = context.AccessToken;
        //    using (EvdekiHesapContext _repo = new EvdekiHesapContext())
        //    {
        //        User user = null;
        //        try
        //        {
        //            user = _repo.Users.Where(x => x.UserName == context. && x.PassWord == context.Password).FirstOrDefault();
        //        }
        //        catch (Exception ex)
        //        {

        //            throw;
        //        }


        //        if (user != null)
        //        {
        //            user.Token = ttoken;
        //        }
        //    }
        //            return base.TokenEndpointResponse(context);
        //}
    }
}