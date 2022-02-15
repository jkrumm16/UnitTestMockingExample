using Newtonsoft.Json;

namespace AddressRepoLib
{
    public class JsonAddressParser : IAddressParser
    {
        public Address Parse(string addressSerialized)
        {
            return JsonConvert.DeserializeObject<Address>(addressSerialized);
        }
    }

    
}
