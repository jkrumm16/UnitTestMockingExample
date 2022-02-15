using Newtonsoft.Json;

namespace AddressRepoLib
{
    public class JsonAddressDeserializer : IAddressDeserializer
    {
        public Address Parse(string addressSerialized)
        {
            return JsonConvert.DeserializeObject<Address>(addressSerialized);
        }
    }
}
