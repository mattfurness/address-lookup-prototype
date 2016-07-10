using Nancy;
using Newtonsoft.Json;
using Serilog.Events;

namespace AddressLookup.Api.Logging
{
    public class UserHostAddressEnricher : NancyRequestEnricher
    {
        public const string PropertyName = "User Host Address";

        protected override void EnrichInternal(NancyContext context, LogEvent logEvent)
        {
            var request = context.Request;
            if (request == null)
                return;

            var userHostAddress = JsonConvert.SerializeObject(request.UserHostAddress);
            var property = new LogEventProperty(PropertyName, new ScalarValue(userHostAddress));
            logEvent.AddPropertyIfAbsent(property);
        }
    }
}