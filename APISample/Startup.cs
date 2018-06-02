using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Cors;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Microsoft.AspNet.SignalR;

[assembly: OwinStartup(typeof(APISample.Startup))]

namespace APISample
{
    //It is for startup owin context validate security 
    public class Startup
    {
        //this function run after application run
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
            app.UseCors(CorsOptions.AllowAll);

            SystemAuthorizationServerProvider provider = new SystemAuthorizationServerProvider();
            OAuthAuthorizationServerOptions option = new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                TokenEndpointPath = new PathString("/token"),
                Provider = provider,
                //AuthorizeEndpointPath = new PathString("")
            };
            app.UseOAuthAuthorizationServer(option);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);

            var hubConfiguration = new HubConfiguration
            {
                EnableDetailedErrors = true,
                EnableJavaScriptProxies = true
            };
            app.MapSignalR(hubConfiguration);
        }
    }
}
