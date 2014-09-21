namespace CodingKata
{
    using System.Reflection;

    using Autofac;
    using Autofac.Integration.WebApi;

    using CodingKata.Core;

    public static class AutofacSetup
    {
        public static AutofacWebApiDependencyResolver Get()
        {
            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.Register(c => new CodingKataContext()).AsSelf().InstancePerRequest();
            builder.RegisterType<PersonService>().As<IPersonService>();
            builder.RegisterType<ColourService>().As<IColourService>();

            var container = builder.Build();

            return new AutofacWebApiDependencyResolver(container);
        }
    }
}