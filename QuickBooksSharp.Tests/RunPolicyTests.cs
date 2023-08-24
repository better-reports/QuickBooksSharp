using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuickBooksSharp.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace QuickBooksSharp.Tests
{
    [TestClass]
    [Ignore("Tests should be run manually")]
    public class RunPolicyTests : ServiceTestBase
    {
        private string _accessToken;

        [TestInitialize]
        public async Task Initialize()
        {
            _accessToken = await GetAccessTokenAsync();
        }

        private async Task IssueManyRequests(IRunPolicy policy)
        {
            var svc = new DataService(_accessToken, TestHelper.RealmId, true, policy);
            await Parallel.ForEachAsync(Enumerable.Range(1, 1000), new ParallelOptions { MaxDegreeOfParallelism = 50 }, async (i, token) =>
            {
                var res = await svc.QueryAsync<Customer>("SELECT * FROM Customer WHERE Id = '1'");
                Assert.IsNotNull(res);
                Assert.IsNull(res.Fault);
                Assert.IsNotNull(res.Time);
                Assert.IsNotNull(res.Response);
            });
        }

        [TestMethod]
        public async Task NoRetryShouldFailWhenTooManyRequests()
        {
            QuickBooksException ex = null;

            try
            {
                await IssueManyRequests(new NoRetryRunPolicy());
            }
            catch (QuickBooksException e)
            {
                ex = e;
            }

            Assert.IsNotNull(ex);
            Assert.IsTrue(ex.IsRateLimit);
        }

        [TestMethod]
        public async Task RetryShouldSucceedWhenTooManyRequests()
        {
            QuickBooksException ex = null;

            try
            {
                await IssueManyRequests(new SimpleRetryRunPolicy());
            }
            catch (QuickBooksException e)
            {
                ex = e;
            }

            Assert.IsNull(ex);
        }

        [TestMethod]
        public async Task MaxConccurencyRetryShouldSucceedWhenTooManyRequests()
        {
            QuickBooksException ex = null;

            try
            {
                await IssueManyRequests(new MaxConcurrencyRetryRunPolicy());
            }
            catch (QuickBooksException e)
            {
                ex = e;
            }

            Assert.IsNull(ex);
        }
    }
}
