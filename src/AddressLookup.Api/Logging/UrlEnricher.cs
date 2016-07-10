using Nancy;
using Serilog.Events;

namespace AddressLookup.Api.Logging
{
    public class UrlEnricher : NancyRequestEnricher
    {
        public const string PropertyName = "Url";

        protected override void EnrichInternal(NancyContext context, LogEvent logEvent)
        {
            var request = context.Request;
            if (request == null)
                return;

            var url = request.Url;
            var urlProperty = new LogEventProperty(PropertyName, new ScalarValue(url));
            logEvent.AddPropertyIfAbsent(urlProperty);
        }
    }
}