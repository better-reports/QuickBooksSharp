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
            Assert.AreEqual(url.Scheme, "https");
            Assert.AreEqual(url.Host, "sandbox-quickbooks.api.intuit.com");
            Assert.AreEqual(url.Path, "/v3/company/123");
            Assert.AreEqual(url.Query, "minorversion=56");

        }

        [TestMethod]
        public void ShouldCreateProductionUrl()
        {
            var url = QuickBooksUrl.Build(false, 123);

            Assert.IsNotNull(url);
            Assert.AreEqual(url.Scheme, "https");
            Assert.AreEqual(url.Host, "quickbooks.api.intuit.com");
            Assert.AreEqual(url.Path, "/v3/company/123");
            Assert.AreEqual(url.Query, "minorversion=56");
        }
    }
}
