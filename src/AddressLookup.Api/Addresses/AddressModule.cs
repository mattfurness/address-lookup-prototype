using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Nancy;
using Nancy.ModelBinding;
using Nancy.Validation;

namespace AddressLookup.Api.Addresses
{
    public class MatchedResults<TResult>
    {
        public MatchedResults(IEnumerable<TResult> matches)
        {
            Matches = matches;
        }

        public IEnumerable<TResult> Matches { get; }
    }

    public class AddressModule : NancyModule
    {
        private readonly ISearcher _searcher;

        public AddressModule(ISearcher searcher) : base("addresses")
        {
            _searcher = searcher;
            Get["/suggest", true] = (_, ctx) => Suggest();
            Get["/query", true] = (_, ctx) => Search();
        }

        private async Task<object> Suggest()
        {
            return await GetResults(query => _searcher.Suggest(query));
        }

        private async Task<object> Search()
        {
            return await GetResults(query => _searcher.Search(query));
        }

        private async Task<object> GetResults<TResult>(Func<SearchQuery, Task<IEnumerable<TResult>>> resultFunc)
        {
            var searchRequest = this.Bind<SearchRequest>();
            var validationResult = this.Validate(searchRequest);
            if (!validationResult.IsValid)
            {
                return Negotiate.WithModel(validationResult).WithStatusCode(HttpStatusCode.BadRequest);
            }

            var query = BuildSearchQuery(searchRequest);
            var results = await resultFunc(query);

            return Negotiate.WithModel(new MatchedResults<TResult>(results));
        }

        private SearchQuery BuildSearchQuery(SearchRequest request)
        {
            return new SearchQuery((int)request.Count, request.Text);
        }
    }
}