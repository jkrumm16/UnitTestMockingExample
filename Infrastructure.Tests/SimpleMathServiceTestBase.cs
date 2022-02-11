﻿using Infrastructure.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Infrastructure.Tests
{
    public abstract class SimpleMathServiceTestBase
    {
        protected IService ServiceUnderTest { get; private set; }

        [TestInitialize]
        public void OnInitialize()
        {
            ServiceUnderTest = new SimpleMathService();
            ServiceUnderTest.Register(new AddService());
            ServiceUnderTest.Register(new SubtractService());
        }
    }
}
