using Microsoft.Owin;

[assembly: OwinStartup(typeof(CodingKata.Startup))]

namespace CodingKata
{
    using System.Data.Entity;
    using System.Web.Http;

    using CodingKata.Core;

    using Owin;

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            Database.SetInitializer<CodingKataContext>(null);

            var config = new HttpConfiguration();

            config.DependencyResolver = AutofacSetup.Get();

            config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}", new { id = RouteParameter.Optional });

            app.UseWebApi(config);
        }
    }
}
