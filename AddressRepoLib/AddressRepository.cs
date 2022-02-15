using System.Data;
using System.Linq;

namespace AddressRepoLib
{
    public class AddressRepository : IAddressRepository
    {
        private readonly IAddressDataSource _addressDataSource;
        private readonly IAddressParser _addressParser;

        public AddressRepository(IAddressDataSource addressDataSource,
                                 IAddressParser addressParser)
        {
            _addressDataSource = addressDataSource;
            _addressParser = addressParser;
        }

        public Address[] GetAllAddresses()
        {
            var serializedAddresses = _addressDataSource.GetAllAddresses();

            var addresses = serializedAddresses.Select(x => _addressParser.Parse(x)).ToArray();

            return addresses;
        }
    }
}
