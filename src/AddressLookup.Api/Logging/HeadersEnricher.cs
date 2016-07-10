using Nancy;
using Newtonsoft.Json;
using Serilog.Events;

namespace AddressLookup.Api.Logging
{
    public class HeadersEnricher : NancyRequestEnricher
    {
        public const string PropertyName = "Headers";

        protected override void EnrichInternal(NancyContext context, LogEvent logEvent)
        {
            var request = context.Request;
            if (request == null)
                return;

            var headers = JsonConvert.SerializeObject(request.Headers);
            var property = new LogEventProperty(PropertyName, new ScalarValue(headers));
            logEvent.AddPropertyIfAbsent(property);
        }
    }
}