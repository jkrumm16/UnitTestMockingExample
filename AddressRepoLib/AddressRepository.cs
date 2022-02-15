using System.Data;
using System.Linq;

namespace AddressRepoLib
{
    public class AddressRepository : IAddressRepository
    {
        private readonly IAddressDataSource _addressDataSource;
        private readonly IAddressDeserializer _addressDeserializer;

        public AddressRepository(IAddressDataSource addressDataSource,
                                 IAddressDeserializer addressDeserializer)
        {
            _addressDataSource = addressDataSource;
            _addressDeserializer = addressDeserializer;
        }

        public Address[] GetAllAddresses()
        {
            var serializedAddresses = _addressDataSource.GetAllAddresses();

            var addresses = serializedAddresses.Select(x => _addressDeserializer.Parse(x)).ToArray();

            return addresses;
        }
    }
}
