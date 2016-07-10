using System;
using Nancy;
using Nancy.Hosting.Self;
using Serilog;

namespace AddressLookup.Api
{
    class AddressLookupApiService
    {
        private readonly string _serviceHost;
        private readonly NancyHost _host;


        public AddressLookupApiService(string serviceHost)
        {
            StaticConfiguration.DisableErrorTraces = false;

            var bootstrapper = new AddressLookupBootstrap();
            _serviceHost = serviceHost;
            _host = new NancyHost(bootstrapper, new Uri(_serviceHost));
        }

        public bool Start()
        {
            _host.Start();
            Log.Logger.Information("Service started on {0}.", _serviceHost);

            return true;
        }

        public bool Stop()
        {
            Log.Logger.Information("Service shutting down.");
            _host.Stop();

            return true;
        }
    }
}
