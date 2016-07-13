namespace AddressLookup.Api.Addresses.Result
{
    public class Suggestion
    {
        public Suggestion(string id, string text)
        {
            Id = id;
            Text = text;
        }

        public string Id { get; private set; }
        public string Text { get; private set; }
    }
}
