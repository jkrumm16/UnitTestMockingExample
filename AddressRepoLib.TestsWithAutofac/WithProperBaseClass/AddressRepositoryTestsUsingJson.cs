using Autofac;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AddressRepoLib.TestsWithAutofac.WithProperBaseClass
{

    [TestClass]
    public class AddressRepositoryTestsUsingJson : AddressRepositoryTestsBase
    {
        protected override void RegisterSerializer(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<JsonAddressDeserializer>().As<IAddressDeserializer>();
        }

        protected override string[] GetMockedTestData()
        {
            return new string[]
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
            };
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
