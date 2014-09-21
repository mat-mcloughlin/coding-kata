using Microsoft.Owin;

[assembly: OwinStartup(typeof(CodingKata.Startup))]

namespace CodingKata
{
    using System.Data.Entity;
    using System.Web.Http;

    using CodingKata.Core;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    using Owin;

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            Database.SetInitializer<CodingKataContext>(null);

            var config = new HttpConfiguration();

            var jsonFormatter = config.Formatters.JsonFormatter;
            var settings = jsonFormatter.SerializerSettings;
            settings.Formatting = Formatting.Indented;
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            config.DependencyResolver = AutofacSetup.Get();

            config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}", new { id = RouteParameter.Optional });

            app.UseWebApi(config);
        }
    }
}
