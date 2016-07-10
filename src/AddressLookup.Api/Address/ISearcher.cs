using System.Collections.Generic;
using System.Threading.Tasks;

namespace AddressLookup.Api.Address
{
    public interface ISearcher
    {
        Task<IEnumerable<SuggestionResult>> Suggest(SearchQuery query);
        Task<IEnumerable<AddressResult>> Search(SearchQuery query);
    }
}
