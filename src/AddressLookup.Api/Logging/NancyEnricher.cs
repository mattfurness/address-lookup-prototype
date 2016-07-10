using System;
using Nancy;
using Serilog.Core;
using Serilog.Events;

namespace AddressLookup.Api.Logging
{
    public abstract class NancyEnricher : ILogEventEnricher
    {
        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            if (logEvent == null) throw new ArgumentNullException("logEvent");

            NancyContext nancyContext = CallContextSink.NancyContext;
            if (nancyContext == null) return;

            Enrich(nancyContext, logEvent);
        }

        protected abstract void Enrich(NancyContext context, LogEvent logEvent);
    }
}