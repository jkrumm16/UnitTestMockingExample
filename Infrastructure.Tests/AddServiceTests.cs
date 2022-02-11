using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Infrastructure.Tests
{
    [TestClass]
    public class AddServiceTests : SimpleMathServiceTestBase
    {
        [TestMethod]
        public void AddService_Add_ShouldBeOkay()
        {
            ////////////////////////////////////
            /// ARRANGE
            var addService = ServiceUnderTest.GetExtension<AddService>();

            ////////////////////////////////////
            /// ACT
            var result = addService.Add(1, 1);

            ////////////////////////////////////
            /// ASSERT
            Assert.AreEqual(2, result);
        }
    }
}
