﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Nest;

namespace AddressLookup.Api.Address.ElasticSearch
{
    class ElasticsearchSearcher : ISearcher
    {
        private ElasticClient _client;

        public ElasticsearchSearcher()
        {
            var node = new Uri(ConfigurationManager.AppSettings["ElasticSearchHost"]);
            var settings = new ConnectionSettings(node);
            _client = new ElasticClient(settings);
        }


        public async Task<IEnumerable<SuggestionResult>> Suggest(SearchQuery query)
        {
            var request = new Nest.SearchRequest
            {
                From = 0,
                Size = query.MaxResults,
                Query = new TermQuery { Field = "full_address_line", Value = query.Query },
                Sort = new List<ISort> { new SortField
                {
                    Field = "full_address_line",
                    Order = SortOrder.Ascending,
                } }
            };

            var response = await _client.SearchAsync<AddressResult>(request);

            return response.Documents.Select(d => new SuggestionResult(d.address_detail_pid, d.full_address_line));
        }

        public async Task<IEnumerable<AddressResult>> Search(SearchQuery query)
        {
            var request = new Nest.SearchRequest
            {
                From = 0,
                Size = query.MaxResults,
                Query = new TermQuery { Field = "full_address_line", Value = query.Query },
                Sort = new List<ISort> { new SortField
                {
                    Field = "full_address_line",
                    Order = SortOrder.Ascending,
                } }
            };

            var response = await _client.SearchAsync<AddressResult>(request);

            return response.Documents;
        }
    }
}