namespace AddressLookup.Api.Addresses
{
    public class SearchQuery
    {
        public SearchQuery(int maxResults, string query)
        {
            MaxResults = maxResults;
            Query = query;
        }

        public int MaxResults { get; }
        public string Query { get; }
    }
}   