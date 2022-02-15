using Autofac;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AddressRepoLib.TestsWithAutofac.WithProperBaseClass
{
    [TestClass]
    public class AddressRepositoryTestsUsingXml : AddressRepositoryTestsBase
    {
        protected override string[] GetMockedTestData()
        {
            return new string[] {
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
</Address>" };
        }

        protected override void RegisterSerializer(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<XmlAddressDeserializer>().As<IAddressDeserializer>();
        }

        [TestMethod]
        public void AddressRepository_GetAllAddresses_AsJson_ShouldGetTwoAddressCorrect()
        {
            ActAndAssert((instanceUnderTest) =>
            {
                ////////////////////////////////////////////////////////////////
                /// ACT
                var addresses = instanceUnderTest.GetAllAddresses();

                ////////////////////////////////////////////////////////////////
                /// ASSERT

                Assert.IsNull(ExceptionThrownByInstanceUnderTest);
                Assert.AreEqual(2, addresses.Length);
                Assert.AreEqual("Max", addresses[0].FirstName);
                Assert.AreEqual("Erika", addresses[1].FirstName);
            });
        }
    }
}
