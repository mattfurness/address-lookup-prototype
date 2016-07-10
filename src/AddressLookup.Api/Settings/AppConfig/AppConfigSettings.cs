using System.Configuration;

namespace AddressLookup.Api.Settings.AppConfig
{
    class AppConfigSettings: ISettings
    {
        public string this[string key] => ConfigurationManager.AppSettings[key];
    }
}
