using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Infrastructure.Tests
{

    [TestClass]
    public class SimpleMathServiceTests : SimpleMathServiceTestBase
    {
        [TestMethod]
        public void SimpleMathService_Execute_ShouldBeOkay()
        {
            ////////////////////////////////////
            /// ARRANGE
            /// empty here

            ////////////////////////////////////
            /// ACT
            var result = ServiceUnderTest.Execute(new AddOperation(1, 1));

            ////////////////////////////////////
            /// ASSERT
            Assert.AreEqual(2, result);
        }
    }
}
