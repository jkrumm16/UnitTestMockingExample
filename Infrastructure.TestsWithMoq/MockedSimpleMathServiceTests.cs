using Infrastructure.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace Infrastructure.TestsWithMoq
{
    [TestClass]
    public class MockedSimpleMathServiceTests
    {
        [TestMethod]
        public void AddService_Add_ShouldAddCorrect()
        {
            ////////////////////////////////////
            /// ARRANGE

            // create a mock of SimpleMathService which returns 3, if an AddOperation (1+1) is executed
            var mockedOwner = new Mock<SimpleMathService>();
            mockedOwner.Setup(x => x.Execute(new AddOperation(1, 1))).Returns(3); // 1 + 1 = 3 !!

            mockedOwner.Setup(x => x.Execute(It.Is<IServiceOperation>(operation => operation.GetType() != typeof(AddOperation))))
                .Throws(new ArgumentException());

            // create a real instance of AddService and set the mocked parent
            var addService = new AddService
            {
                Owner = mockedOwner.Object
            };

            ////////////////////////////////////
            /// ACT
            var aResult = addService.Calculate(1, 1);

            ////////////////////////////////////
            /// ASSERT
            Assert.AreEqual(3, aResult); // 1 + 1 = 3 !!


            try
            {
                mockedOwner.Object.Execute(new SubtractOperation(1, 1));
            }
            catch (Exception e)
            {
                Assert.AreEqual(typeof(ArgumentException), e.GetType());
            }
        }
    }
}
