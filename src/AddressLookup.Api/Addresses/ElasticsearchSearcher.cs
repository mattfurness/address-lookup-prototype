using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AddressLookup.Api.Addresses.Result;
using AddressLookup.Api.Settings;
using Nest;

namespace AddressLookup.Api.Addresses
{
    class ElasticsearchSearcher : ISearcher
    {
        private ElasticClient _client;
        private string _index;

        public ElasticsearchSearcher(ISettings settings)
        {
            var node = new Uri(settings["ElasticSearchHost"]);
            var index = settings["AddressIndex"];
            var clientSettings = new ConnectionSettings(node).DefaultIndex(index);
            _client = new ElasticClient(clientSettings);
        }


        public async Task<IEnumerable<Suggestion>> Suggest(SearchQuery query)
        {
            var request = new Nest.SearchRequest
            {
                From = 0,
                Size = query.MaxResults,
                Query = new MatchQuery { Field = "full_address_line", Query = query.Query }
            };

            var response = await _client.SearchAsync<Address>(request);

            return response.Documents.Select(d => new Suggestion(d.address_detail_pid, d.full_address_line));
        }

        public async Task<IEnumerable<Address>> Search(SearchQuery query)
        {
            var request = new Nest.SearchRequest
            {
                From = 0,
                Size = query.MaxResults,
                Query = new MatchQuery { Field = "full_address_line", Query = query.Query, Operator = Operator.And},
                Sort = new List<ISort> { new SortField
                {
                    Field = "full_address_line",
                    Order = SortOrder.Ascending,
                } }
            };

            var response = await _client.SearchAsync<Address>(request);

            return response.Documents;
        }
    }
}