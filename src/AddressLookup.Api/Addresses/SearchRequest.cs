namespace AddressLookup.Api.Addresses
{
    public class SearchRequest
    {
        public SearchRequest()
        {
        }

        public SearchRequest(string text, int? count, string format)
        {
            Text = text;
            Count = count;
            Format = format;
        }

        public string Text { get; private set; }
        public int? Count { get; private set; }
        public string Format { get; private set; }
    }
}
