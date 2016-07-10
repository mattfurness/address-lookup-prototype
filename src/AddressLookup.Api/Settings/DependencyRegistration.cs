using AddressLookup.Api.Address.ElasticSearch;
using AddressLookup.Api.Settings.AppConfig;
using Autofac;

namespace AddressLookup.Api.Settings
{
    class DependencyRegistration : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AppConfigSettings>().AsImplementedInterfaces().SingleInstance();
        }
    }
}
