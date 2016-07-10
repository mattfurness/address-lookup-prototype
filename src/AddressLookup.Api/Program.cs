using System.Configuration;
using AddressLookup.Api.Logging;
using Serilog;
using Topshelf;

namespace AddressLookup.Api
{
    class Program
    {

        public static void Main(string[] args)
        {
            ConfigureLogging();

            HostFactory.Run(c =>
            {
                c.Service<AddressLookupApiService>(s =>
                {
                    var serviceHostName = ConfigurationManager.AppSettings["ServiceHostname"];
                    s.ConstructUsing(() => new AddressLookupApiService(serviceHostName));
                    s.WhenStarted((service, control) => service.Start());
                    s.WhenStopped((service, control) => service.Stop());
                });

                c.UseSerilog();
                c.SetDisplayName("AddressLookup.Api.Service");
                c.SetServiceName("AddressLookup.Api.Service");
                c.SetDescription("AddressLookup.Api.Service");
            });
        }

        private static void ConfigureLogging()
        {
            var config = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.ColoredConsole()
                .Enrich.WithProperty("Application", "AddressLookup.Api.Service")
                .Enrich.WithMachineName()
                .Enrich.WithProcessId()
                .Enrich.WithThreadId()
                .Enrich.With<UrlEnricher>()
                .Enrich.With<HeadersEnricher>()
                .Enrich.With<ParametersEnricher>()
                .Enrich.With<TracingEnricher>()
                .Enrich.With<UserHostAddressEnricher>();

            Log.Logger = config.CreateLogger();
        }
    }
}
