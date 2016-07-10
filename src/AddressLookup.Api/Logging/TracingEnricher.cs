using Serilog.Core;
using Serilog.Events;

namespace AddressLookup.Api.Logging
{
    public class TracingEnricher : ILogEventEnricher
    {
        public const string PropertyName = "TraceId";

        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            var property = new LogEventProperty(PropertyName, new ScalarValue(CallContextSink.TraceId));
            logEvent.AddPropertyIfAbsent(property);
        }
    }
}