namespace AddressLookup.Api.Address
{
    public class SuggestionResult
    {
        public SuggestionResult(string id, string text)
        {
            Id = id;
            Text = text;
        }

        public string Id { get; private set; }
        public string Text { get; private set; }
    }
}
