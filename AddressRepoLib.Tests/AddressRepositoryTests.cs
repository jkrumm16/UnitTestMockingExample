﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AddressRepoLib.Tests
{
    [TestClass]
    public class AddressRepositoryTests
    {
        [TestMethod]
        public void AddressRepository_GetAllAddresses_AsJson_ShouldGetTwoAddressCorrect()
        {
            ////////////////////////////////////////////////////////////////
            /// ARRANGE
            var dataSourceMock = new Mock<IAddressDataSource>();
            dataSourceMock.Setup(x => x.GetAllAddresses()).Returns(new string[]
            {
@"{
    ""LastName"":""Mustermann"",
    ""FirstName"":""Max"",
    ""Steet"":""Musterstraße"",
    ""HouseNumber"":""1a"",
    ""PostalCode"":""12345"",
    ""City"":""Musterhausen"",
    ""ISOA2CountryCode"":""DE""
}",
@"{
    ""LastName"":""Mustermann"",
    ""FirstName"":""Erika"",
    ""Steet"":""Musterstraße"",
    ""HouseNumber"":""1a"",
    ""PostalCode"":""12345"",
    ""City"":""Musterhausen"",
    ""ISOA2CountryCode"":""DE""
}"
            });

            var addressRepository = new AddressRepository(dataSourceMock.Object, new JsonAddressParser());

            ////////////////////////////////////////////////////////////////
            /// ARRANGE

            var addresses = addressRepository.GetAllAddresses();

            ////////////////////////////////////////////////////////////////
            /// ASSERT

            Assert.AreEqual(2, addresses.Length);
            Assert.AreEqual("Max", addresses[0].FirstName);
            Assert.AreEqual("Erika", addresses[1].FirstName);
        }

        [TestMethod]
        public void AddressRepository_GetAllAddresses_AsXml_ShouldGetTwoAddressCorrect()
        {
            ////////////////////////////////////////////////////////////////
            /// ARRANGE
            var dataSourceMock = new Mock<IAddressDataSource>();
            dataSourceMock.Setup(x => x.GetAllAddresses()).Returns(new string[]
            {
@"<?xml version=""1.0"" encoding=""UTF-8"" ?>
<Address>
  <LastName>Mustermann</LastName>
  <FirstName>Max</FirstName>
  <Steet>Musterstraße</Steet>
  <HouseNumber>1a</HouseNumber>
  <PostalCode>12345</PostalCode>
  <City>Musterhausen</City>
  <ISOA2CountryCode>DE</ISOA2CountryCode>
</Address>
",
@"<?xml version=""1.0"" encoding=""UTF-8"" ?>
<Address>
  <LastName>Mustermann</LastName>
  <FirstName>Erika</FirstName>
  <Steet>Musterstraße</Steet>
  <HouseNumber>1a</HouseNumber>
  <PostalCode>12345</PostalCode>
  <City>Musterhausen</City>
  <ISOA2CountryCode>DE</ISOA2CountryCode>
</Address>" });

            var addressRepository = new AddressRepository(dataSourceMock.Object, new XmlAddressParser());

            ////////////////////////////////////////////////////////////////
            /// ARRANGE

            var addresses = addressRepository.GetAllAddresses();

            ////////////////////////////////////////////////////////////////
            /// ASSERT

            Assert.AreEqual(2, addresses.Length);
            Assert.AreEqual("Max", addresses[0].FirstName);
            Assert.AreEqual("Erika", addresses[1].FirstName);
        }
    }
}