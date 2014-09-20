using Microsoft.Owin;

[assembly: OwinStartup(typeof(CodingKata.Startup))]

namespace CodingKata
{
    using System.Web.Http;

    using Owin;

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}", new { id = RouteParameter.Optional });

            app.UseWebApi(config);
        }
    }
}
