using System.Collections.Generic;
using AddressLookup.Api.Addresses;
using FluentValidation;
using Nancy;
using Nancy.Testing;
using NUnit.Framework;
using Shouldly;
using TestStack.BDDfy;

namespace AddressLookup.Api.Tests.Addresses
{
    [TestFixture]
    public class InvalidCountTests
    {
        private BrowserResponse _result;
        private Browser _browser;

        public void GivenAnAddressModule()
        {
            _browser = AddressBrowser.Create();
        }

        public void WhenRequestIsMadeWithZeroCount()
        {
            _result = _browser.Get("/addresses/search", new SearchRequest("test", 0, "json"));
        }

        public void ThenValidationShouldFail()
        {
            _result.StatusCode.ShouldBe(HttpStatusCode.BadRequest);
        }

        [Test]
        public void Execute()
        {
            this.BDDfy();
        }
    }

    [TestFixture]
    public class InvalidFormatTests
    {
        private BrowserResponse _result;
        private Browser _browser;

        public void GivenAnAddressModule()
        {
            _browser = AddressBrowser.Create();
        }

        public void WhenRequestIsMadeWithNoQuery()
        {
            _result = _browser.Get("/addresses/search", new SearchRequest("test", 10, "xml"));
        }

        public void ThenValidationShouldFail()
        {
            _result.StatusCode.ShouldBe(HttpStatusCode.BadRequest);
        }

        [Test]
        public void Execute()
        {
            this.BDDfy();
        }
    }

    [TestFixture]
    public class MissingQueryTests
    {
        private BrowserResponse _result;
        private Browser _browser;

        public void GivenAnAddressModule()
        {
            _browser = AddressBrowser.Create();
        }

        public void WhenRequestIsMadeWithNoQuery()
        {
            _result = _browser.Get("/addresses/search", new SearchRequest(null, 10, "json"));
        }

        public void ThenValidationShouldFail()
        {
            _result.StatusCode.ShouldBe(HttpStatusCode.BadRequest);
        }

        [Test]
        public void Execute()
        {
            this.BDDfy();
        }
    }

    [TestFixture]
    public class MissingCountTests
    {
        private BrowserResponse _result;
        private Browser _browser;

        public void GivenAnAddressModule()
        {
            _browser = AddressBrowser.Create();
        }

        public void WhenRequestIsMadeWithNoCount()
        {
            _result = _browser.Get("/addresses/search", new SearchRequest("test", null, "json"));
        }

        public void ThenValidationShouldFail()
        {
            _result.StatusCode.ShouldBe(HttpStatusCode.BadRequest);
        }

        [Test]
        public void Execute()
        {
            this.BDDfy();
        }
    }

    [TestFixture]
    public class MissingFormatTests
    {
        private BrowserResponse _result;
        private Browser _browser;

        public void GivenAnAddressModule()
        {
            _browser = new Browser(cfg =>
            {
                cfg.Module<AddressModule>();
                cfg.Dependency<ISearcher>(new TestStaticSearcher());
                cfg.Dependency<IValidator<SearchRequest>>(new RequestValidator());
            });
        }

        public void WhenRequestIsMadeWithNoFormat()
        {
            _result = _browser.Get("/addresses/search", new SearchRequest("test", 10, null));
        }

        public void ThenValidationShouldFail()
        {
            _result.StatusCode.ShouldBe(HttpStatusCode.BadRequest);
        }

        [Test]
        public void Execute()
        {
            this.BDDfy();
        }
    }
}
