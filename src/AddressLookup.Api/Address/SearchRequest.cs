namespace AddressLookup.Api.Address
{
    class SearchRequest
    {
        public string Text { get; private set; }
        public int Count { get; private set; }
        public string Format { get; private set; }
    }
}
