using AddressLookup.Api.Addresses;
using Nancy.Testing;
using Newtonsoft.Json;
using NUnit.Framework;
using Shouldly;
using TestStack.BDDfy;

namespace AddressLookup.Api.Tests.Addresses
{
    [TestFixture]
    public class SearchRequestTests
    {
        private BrowserResponse _result;
        private Browser _browser;

        public void GivenAnAddressModule()
        {
            _browser = AddressBrowser.Create();
        }

        public void WhenRequestIsMadeWithMatchingQuery()
        {
            _result = _browser.Get("/addresses/query", new SearchRequest("c", 2, "json"));
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

        public void AndResultsShouldBeInAddressFormat()
        {
            dynamic result = JsonConvert.DeserializeObject<dynamic>(_result.Body.AsString()).matches[0];
            string id = result.address_detail_pid;
            string address = result.full_address_line;

            id.ShouldBe("c1");
            address.ShouldBe("c_1");
        }

        [Test]
        public void Execute()
        {
            this.BDDfy();
        }
    }
}