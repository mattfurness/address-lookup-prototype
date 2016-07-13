using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AddressLookup.Api.Addresses;
using AddressLookup.Api.Addresses.Result;

namespace AddressLookup.Api.Tests.Addresses
{
    class TestStaticSearcher : ISearcher
    {
        public async Task<IEnumerable<Suggestion>> Suggest(SearchQuery query)
        {
            var suggestions = new[]
            {
                new Suggestion("a1", "a_1"),
                new Suggestion("a2", "a_2"),
                new Suggestion("a3", "a_3"),
                new Suggestion("a4", "a_4"),
                new Suggestion("b1", "b_1"),
                new Suggestion("b2", "b_2"),
                new Suggestion("b3", "b_3"),
                new Suggestion("b4", "b_4"),
            };

            return suggestions.Where(s => s.Text.Contains(query.Query)).Take(query.MaxResults).ToList();
        }

        public async Task<IEnumerable<Address>> Search(SearchQuery query)
        {
            var addresses = new[]
            {
                new Address
                {
                    address_detail_pid = "c1",
                    full_address_line = "c_1"
                },
                new Address
                {
                    address_detail_pid = "c2",
                    full_address_line = "c_2"
                },
                new Address
                {
                    address_detail_pid = "c3",
                    full_address_line = "c_3"
                },
                new Address
                {
                    address_detail_pid = "c4",
                    full_address_line = "c_4"
                },
                new Address
                {
                    address_detail_pid = "d1",
                    full_address_line = "d_1"
                },
                new Address
                {
                    address_detail_pid = "d2",
                    full_address_line = "d_2"
                },
                new Address
                {
                    address_detail_pid = "d3",
                    full_address_line = "d_3"
                },
                new Address
                {
                    address_detail_pid = "d4",
                    full_address_line = "d_1"
                }
            };

            return addresses.Where(s => s.full_address_line.Contains(query.Query)).Take(query.MaxResults).ToList();
        }
    }
}
