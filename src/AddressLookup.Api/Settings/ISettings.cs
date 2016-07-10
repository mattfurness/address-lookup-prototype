namespace AddressLookup.Api.Settings
{
    public interface ISettings
    {
        string this[string key] { get; } 
    }
}