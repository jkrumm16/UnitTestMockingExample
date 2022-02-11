using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Infrastructure.Tests
{
    [TestClass]
    public class SubtractServiceTests : SimpleMathServiceTestBase
    {
        [TestMethod]
        public void AddService_Add_ShouldBeOkay()
        {
            ////////////////////////////////////
            /// ARRANGE
            var subtractService = ServiceUnderTest.GetExtension<SubtractService>();

            ////////////////////////////////////
            /// ACT
            var result = subtractService.Subtract(1, 1);

            ////////////////////////////////////
            /// ASSERT
            Assert.AreEqual(0, result);
        }
    }
}
