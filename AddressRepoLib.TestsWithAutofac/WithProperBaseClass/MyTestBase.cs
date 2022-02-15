using Autofac;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

namespace AddressRepoLib.TestsWithAutofac.WithProperBaseClass
{
    public class MyTestBase<TInstanceUnderTest>
    {
        protected ContainerBuilder Builder { get; private set; }
        protected List<object> TestDependencies { get; private set; }
        protected TInstanceUnderTest InstanceUnderTest { get; private set; }
        protected Exception ExceptionThrownByInstanceUnderTest { get; private set; }

        [TestInitialize]
        public void OnInitialize()
        {
            Builder = new ContainerBuilder();
            TestDependencies = new List<object>();
            Arrange(Builder);

            foreach (var obj in TestDependencies)
            {
                Builder.RegisterInstance(obj);
            }
        }

        protected virtual void Arrange(ContainerBuilder containerBuilder)
        {
        }

        protected virtual void RegisterMockedDependency<T>(Mock<T> dependency) where T : class
        {
            Builder.RegisterInstance(dependency.Object);
        }

        protected void ActAndAssert(Action<TInstanceUnderTest> theInnerActAndAssertAction)
        {
            using (var scope = Builder.Build().BeginLifetimeScope())
            {
                try
                {
                    theInnerActAndAssertAction(scope.Resolve<TInstanceUnderTest>());
                }
                catch (Exception ex)
                {
                    ExceptionThrownByInstanceUnderTest = ex;
                }
            }
        }
    }
}
