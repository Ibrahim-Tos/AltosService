using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Altos.Services.Tests
{
    [TestClass]
    public class BaseTest
    {
        public TestContext TestContext { get; set; }
        public IServiceProvider IoCManager;// TODO:..

        protected void InitializeDependencyInjection()
        {
            //Init IoCManager
        }
    }
}
