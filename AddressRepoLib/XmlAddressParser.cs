﻿using System.IO;
using System.Xml.Serialization;

namespace AddressRepoLib
{
    public class XmlAddressParser : IAddressParser
    {
        public Address Parse(string addressSerialized)
        {
            var serializer = new XmlSerializer(typeof(Address));

            using (TextReader reader = new StringReader(addressSerialized))
            {
                return (Address)serializer.Deserialize(reader);
            }
        }
    }

    
}
