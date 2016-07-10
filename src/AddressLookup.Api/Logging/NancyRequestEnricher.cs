using Nancy;
using Serilog.Events;

namespace AddressLookup.Api.Logging
{
    public abstract class NancyRequestEnricher : NancyEnricher
    {
        protected override void Enrich(NancyContext context, LogEvent logEvent)
        {
            EnrichInternal(context, logEvent);
        }

        protected abstract void EnrichInternal(NancyContext context, LogEvent logEvent);
    }
}