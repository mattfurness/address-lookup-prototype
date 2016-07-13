using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace AddressLookup.Api.Settings
{
    class CustomJsonSerializer : JsonSerializer
    {
        public CustomJsonSerializer()
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver();
        }
    }
}
