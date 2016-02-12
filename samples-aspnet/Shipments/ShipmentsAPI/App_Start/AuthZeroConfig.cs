using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataHandler.Encoder;
using Microsoft.Owin.Security.Jwt;
using Owin;

namespace ShipmentsAPI
{
    public partial class Startup
    {
        private void ConfigureAuthZero(IAppBuilder app)
        {
            // The keys and values are taken directly from Web.config.
            var issuer = "https://" + ConfigurationManager.AppSettings["auth0:Domain"] + "/";
            var audience = ConfigurationManager.AppSettings["auth0:ClientId"];
            var secret =
                TextEncodings.Base64.Encode(
                    TextEncodings.Base64Url.Decode(ConfigurationManager.AppSettings["auth0:ClientSecret"]));

            // We have to configure the web token barrier middleware to our Owin server.
            app.UseJwtBearerAuthentication(new JwtBearerAuthenticationOptions()
            {
                // This configures the middleware to check every incoming request and attempt to authenticate
                // the call and if it's successful, create a principal that represent a current user and assign 
                // that principal to the hosting environment. 
                AuthenticationMode = AuthenticationMode.Active,
                AllowedAudiences = new[] { audience },
                IssuerSecurityTokenProviders = new[]
                {
                    // This will be used to sign the generated json web token. 
                    new SymmetricKeyIssuerSecurityTokenProvider(issuer, secret)
                }

            });
        }
    }
}