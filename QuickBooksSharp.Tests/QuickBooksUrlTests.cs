using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace QuickBooksSharp.Tests
{
    [TestClass]
    public class QuickBooksUrlTests
    {
        [TestMethod]
        public void ShouldCreateSandboxUrl()
        {
            var url = QuickBooksUrl.Build(true, 123);

            Assert.IsNotNull(url);
            Assert.AreEqual(url.ToUri().AbsoluteUri, "https://sandbox-quickbooks.api.intuit.com/v3/company/123?minorversion=56");

        }

        [TestMethod]
        public void ShouldCreateProductionUrl()
        {
            var url = QuickBooksUrl.Build(false, 123);

            Assert.IsNotNull(url);
            Assert.AreEqual(url.ToUri().AbsoluteUri, "https://quickbooks.api.intuit.com/v3/company/123?minorversion=56");
        }
    }
}
