using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Infrastructure.TestsWithMoq
{
    [TestClass]
    public class MockedAddServiceTests
    {
        [TestMethod]
        public void Mock()
        {
            ////////////////////////////////////
            /// ARRANGE

            // create a mock of AddService which returns 3, if 1,1 is used as parameter
            var mockedService = new Mock<AddService>();
            mockedService.Setup(x => x.Calculate(1, 1)).Returns(3); // 1 + 1 = 3

            // create a real instance of AddService and set the mocked parent
            var mathService = new SimpleMathService();
            mathService.Register(mockedService.Object);


            ////////////////////////////////////
            /// ACT
            var realServiceResult = mathService.Execute(new AddOperation(1, 1));
            var mockedServiceResult = mockedService.Object.Calculate(1, 1);

            ////////////////////////////////////
            /// ASSERT
            Assert.AreEqual(2, realServiceResult); // 1 + 1 = 2 !!
            Assert.AreEqual(3, mockedServiceResult); // 1 + 1 = 3 !!
        }
    }
}
