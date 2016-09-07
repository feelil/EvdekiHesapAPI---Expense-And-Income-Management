using Entity;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.Owin.Security;
using System.Collections.Generic;

namespace Butce.OAuth
{


    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
          
            // validate client credentials
            // should be stored securely (salted, hashed, iterated)
            string clientId, clientSecret;
            if (!context.TryGetBasicCredentials(out clientId, out clientSecret))
            {
                context.TryGetFormCredentials(out clientId, out clientSecret);
            }
           
                if (clientSecret == "test_secret")
                {
                    context.Validated();
                }
            




        }

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
                    //  user = new User { UserName = "ilhan", PassWord = "123" };
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
                    identity.AddClaim(new Claim("Password", user.PassWord));
                    // create metadata to pass on to refresh token provider
                    var props = new AuthenticationProperties(new Dictionary<string, string>
                            {
                                { "as:client_id", context.ClientId }
                            });




                    var ticket = new AuthenticationTicket(identity, props);
                    context.Validated(ticket);
                    // user.Token = ???  At this point I want to save the genereted token to the DB. ??
                    //   _repo.SaveChanges();
                    //vacontext.Response.Body.ToString();
                }
                else
                {
                    context.Rejected();
                    context.SetError("invalid_grant", "The user name or password is incorrect.");
                    return;
                }
            }
        }

        public override async Task GrantRefreshToken(OAuthGrantRefreshTokenContext context)
        {
            var originalClient = context.Ticket.Properties.Dictionary["as:client_id"];
            var currentClient = context.ClientId;

            // enforce client binding of refresh token
            if (originalClient != currentClient)
            {
                context.Rejected();
                return;
            }

            // chance to change authentication ticket for refresh token requests
            var newId = new ClaimsIdentity(context.Ticket.Identity);
            var newTicket = new AuthenticationTicket(newId, context.Ticket.Properties);
            context.Validated(newTicket);
        }
    }
    /*
    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        // OAuthAuthorizationServerProvider sınıfının client erişimine izin verebilmek için ilgili ValidateClientAuthentication metotunu override ediyoruz.       

        public override  Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            string clientId = string.Empty;
            string clientSecret = string.Empty;
            string symmetricKeyAsBase64 = string.Empty;

            if (!context.TryGetBasicCredentials(out clientId, out clientSecret))
            {
                context.TryGetFormCredentials(out clientId, out clientSecret);
            }

            if (context.ClientId == null)
            {
                context.SetError("invalid_clientId", "client_Id is not set");
                return Task.FromResult<object>(null);
            }
          var   user = new User { UserName = "ilhan", PassWord = "123" };
            //  var audience = AudiencesStore.FindAudience(context.ClientId);

            if (user == null)
            {
                context.SetError("invalid_clientId", string.Format("Invalid client_id '{0}'", context.ClientId));
                return Task.FromResult<object>(null);
            }

            context.Validated();
            return Task.FromResult<object>(null);
        }

        

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
                  //  user = new User { UserName = "ilhan", PassWord = "123" };
                  user= _repo.Users.Where(x => x.UserName == context.UserName && x.PassWord == context.Password).FirstOrDefault();
                }
                catch (Exception ex)
                {

                    throw;
                }
               

                if (user != null)
                {
                    var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                    identity.AddClaim(new Claim("UserName", user.UserName));
                    identity.AddClaim(new Claim("Password", user.PassWord));
                   



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


        
    }
    */
}