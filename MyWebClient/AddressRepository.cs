using System.Data;
using System.Linq;

namespace MyWebClient
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
            return _addressDataSource.GetAllAddresses()
                .Select(x => _addressParser.Parse(x)).ToArray();
        }
    }
}
