using Autofac;
using Moq;

namespace AddressRepoLib.TestsWithAutofac.WithProperBaseClass
{
    public abstract class AddressRepositoryTestsBase : MyTestBase<IAddressRepository>
    {
        protected override void Arrange(ContainerBuilder containerBuilder)
        {
            Builder.RegisterType<AddressRepository>().As<IAddressRepository>();

            RegisterSerializer(Builder);

            var dataSourceMock = new Mock<IAddressDataSource>();
            dataSourceMock.Setup(x => x.GetAllAddresses()).Returns(GetMockedTestData());

            RegisterMockedDependency(dataSourceMock);
        }

        protected abstract void RegisterSerializer(ContainerBuilder containerBuilder);

        protected abstract string[] GetMockedTestData();
    }
}
