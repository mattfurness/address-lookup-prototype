using AddressLookup.Api.Addresses;
using FluentValidation;
using Nancy;
using Nancy.Testing;
using Newtonsoft.Json;
using NUnit.Framework;
using Shouldly;
using TestStack.BDDfy;

namespace AddressLookup.Api.Tests.Addresses
{
    [TestFixture]
    public class SuggestRequestTests
    {
        private BrowserResponse _result;
        private Browser _browser;

        public void GivenAnAddressModule()
        {
            _browser = AddressBrowser.Create();
        }

        public void WhenRequestIsMadeWithMatchingQuery()
        {
            _result = _browser.Get("/addresses/suggest", new SearchRequest("a", 2, "json"));
        }

        public void ThenThereShouldBeTwoResults()
        {
            dynamic result = JsonConvert.DeserializeObject<dynamic>(_result.Body.AsString());
            int resultCount = result.matches.Count;
            resultCount.ShouldBe(2);
        }

        public void AndContentTypeShouldBeJson()
        {
            _result.ContentType.ShouldBe("application/json; charset=utf-8");
        }

        public void AndResultsShouldBeInSuggestFormat()
        {
            dynamic result = JsonConvert.DeserializeObject<dynamic>(_result.Body.AsString()).matches[0];
            string id = result.id;
            string text = result.text;

            id.ShouldBe("a1");
            text.ShouldBe("a_1");
        }

        [Test]
        public void Execute()
        {
            this.BDDfy();
        }
    }
}
