using Autofac;

namespace AddressLookup.Api.Addresses
{
    class DependencyRegistration : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ElasticsearchSearcher>().AsImplementedInterfaces().SingleInstance();
        }
    }
}
