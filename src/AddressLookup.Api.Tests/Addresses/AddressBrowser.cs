using AddressLookup.Api.Addresses;
using FluentValidation;
using Nancy.Responses.Negotiation;
using Nancy.Testing;

namespace AddressLookup.Api.Tests.Addresses
{
    public static class AddressBrowser
    {
        public static BrowserResponse Get(this Browser browser, string requestPath, SearchRequest searchRequest)
        {
            return browser.Get(requestPath, with =>
            {
                with.Accept(new MediaRange("application/json"));
                with.HttpRequest();

                if (searchRequest.Count != null)
                    with.Query("count", searchRequest.Count.ToString());
                if (searchRequest.Format != null)
                    with.Query("format", searchRequest.Format.ToString());
                if (searchRequest.Text != null)
                    with.Query("text", searchRequest.Text.ToString());
            });
        }

        public static Browser Create()
        {
            return new Browser(cfg =>
            {
                cfg.Module<AddressModule>();
                cfg.Dependency<ISearcher>(new TestStaticSearcher());
                cfg.Dependency<IValidator<SearchRequest>>(new RequestValidator());
            });
        }
    }
}