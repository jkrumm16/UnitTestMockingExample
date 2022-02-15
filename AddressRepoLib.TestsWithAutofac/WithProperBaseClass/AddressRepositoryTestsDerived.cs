using Autofac;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AddressRepoLib.TestsWithAutofac.WithProperBaseClass
{
    [TestClass]
    public class AddressRepositoryTestsDerived : MyTestBase<IAddressRepository>
    {
        protected override void Arrange(ContainerBuilder containerBuilder)
        {
            Builder.RegisterType<AddressRepository>().As<IAddressRepository>();
            Builder.RegisterType<JsonAddressParser>().As<IAddressParser>();

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

            InjectMockedDependency(dataSourceMock);
        }

        [TestMethod]
        public void AddressRepository_GetAllAddresses_AsJson_ShouldGetTwoAddressCorrect()
        {
            ActAndAssert((testScope) =>
            {
                ////////////////////////////////////////////////////////////////
                /// ARRANGE
                var repository = testScope.Resolve<IAddressRepository>();

                ////////////////////////////////////////////////////////////////
                /// ACT
                var addresses = repository.GetAllAddresses();

                ////////////////////////////////////////////////////////////////
                /// ASSERT
                Assert.AreEqual(2, addresses.Length);
                Assert.AreEqual("Max", addresses[0].FirstName);
                Assert.AreEqual("Erika", addresses[1].FirstName);
            });
        }
    }
}
