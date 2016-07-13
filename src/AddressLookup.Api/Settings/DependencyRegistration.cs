using Autofac;
using Newtonsoft.Json;

namespace AddressLookup.Api.Settings
{
    class DependencyRegistration : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AppConfigSettings>().AsImplementedInterfaces().SingleInstance();
            builder.RegisterType<CustomJsonSerializer>().As<JsonSerializer>().SingleInstance();
        }
    }
}
