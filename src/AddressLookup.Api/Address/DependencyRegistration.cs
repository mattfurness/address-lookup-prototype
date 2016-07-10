using AddressLookup.Api.Address.ElasticSearch;
using Autofac;

namespace AddressLookup.Api.Address
{
    class DependencyRegistration : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ElasticsearchSearcher>().AsImplementedInterfaces().SingleInstance();
        }
    }
}
