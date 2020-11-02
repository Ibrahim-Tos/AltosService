using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Altos.Services.Tests.Features.Products
{
    [TestClass]
    [TestCategory("Products")]
    public class ProductServiceTests : BaseTest
    {
        [TestInitialize]
        public void Initialize()
        {
            InitializeDependencyInjection();
        }
    }
}
