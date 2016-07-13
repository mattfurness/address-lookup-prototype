using System.Collections.Generic;
using System.Threading.Tasks;
using AddressLookup.Api.Addresses.Result;

namespace AddressLookup.Api.Addresses
{
    public interface ISearcher
    {
        Task<IEnumerable<Suggestion>> Suggest(SearchQuery query);
        Task<IEnumerable<Address>> Search(SearchQuery query);
    }
}
