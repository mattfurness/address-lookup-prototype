using Nancy;
using Newtonsoft.Json;
using Serilog.Events;

namespace AddressLookup.Api.Logging
{
    public class ParametersEnricher : NancyEnricher
    {
        public const string PropertyName = "Parameters";

        protected override void Enrich(NancyContext context, LogEvent logEvent)
        {
            dynamic parameters = JsonConvert.SerializeObject(context.Parameters);
            var property = new LogEventProperty(PropertyName, new ScalarValue(parameters));
            logEvent.AddPropertyIfAbsent(property);
        }
    }
}