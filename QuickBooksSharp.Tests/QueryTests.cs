using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuickBooksSharp.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace QuickBooksSharp.Tests
{
    [TestClass]
    public class QueryTests : ServiceTestBase
    {
        private DataService _service;
        private Type[] _entityTypes = typeof(IntuitEntity).Assembly
                                                .GetExportedTypes()
                                                .Where(t => typeof(IntuitEntity).IsAssignableFrom(t) && !t.IsAbstract)
                                                .Where(t => t != typeof(CompanyInfo))
                                                .ToArray();

        [TestInitialize]
        public async Task Initialize()
        {
            _service = new DataService(await GetAccessTokenAsync(), TestHelper.RealmId, true);
            //exclude abstract types
            _entityTypes = _entityTypes.Where(t => !_entityTypes.Any(t2 => t != t2 && t2.IsAssignableTo(t))).ToArray();
        }

        [TestMethod]
        public async Task QueryCustomers()
        {
            var res = await _service.Query<Customer>("SELECT * FROM Customer");
            Assert.IsNotNull(res);
            Assert.IsNull(res.Fault);
            Assert.IsNotNull(res.Time);
            Assert.IsNotNull(res.Response);
            Assert.IsNull(res.Response.Fault);
            Assert.IsNotNull(res.Response.StartPosition);
            Assert.IsNotNull(res.Response.Entities);
            Assert.IsNotNull(res.Response.MaxResults);
            Assert.IsNotNull(res.Response.Entities[0].Id);
            Assert.IsNotNull(res.Response.Entities[0].DisplayName);
        }

        [TestMethod]
        public async Task QueryEntitiesCount()
        {
            await Task.WhenAll(_entityTypes
                .Where(t2 => !new[]
                                {
                                    typeof(ExchangeRate),//Message=Error processing query
                                    typeof(TaxPayment),//feature not supported bug
                                    typeof(CustomerType),//Detail=Dear entity developer, pl implement count query
                                }.Contains(t2))
                .Select(async t =>
            {
                try
                {
                    string entityName = t == typeof(QbTask) ? "Task" : t.Name;
                    var res = await _service.Query<IntuitEntity>($"SELECT COUNT(*) FROM {entityName}");
                    Assert.IsNotNull(res);
                    Assert.IsNull(res.Fault);
                    Assert.IsNotNull(res.Time);
                    Assert.IsNotNull(res.Response);
                    Assert.IsNull(res.Response.Fault);
                    Assert.IsNotNull(res.Response.TotalCount);
                }
                catch (QuickBooksException ex) when (ex.ResponseContent.Contains("Metadata not found for Entity"))
                {
                    //Ignore entities that don't support querying
                }
            }));
        }

        [TestMethod]
        public async Task QueryEntities()
        {
            await Task.WhenAll(_entityTypes
                 .Where(t2 => !new[]
                                {
                                    typeof(Preferences), //deserialization bug
                                    typeof(TaxPayment),//feature not supported bug
                                }.Contains(t2))
                .Select(async t =>
            {
                try
                {
                    string entityName = t == typeof(QbTask) ? "Task" : t.Name;
                    var res = await _service.Query<IntuitEntity>($"SELECT * FROM {entityName}");
                    Assert.IsNotNull(res);
                    Assert.IsNull(res.Fault);
                    Assert.IsNotNull(res.Time);
                    Assert.IsNull(res.Response.Fault);
                    Assert.IsNotNull(res.Response);
                    //it seems that if there are 0 rows, the following are null
                    if (res.Response.StartPosition != null)
                    {
                        Assert.IsNotNull(res.Response.Entities);
                        Assert.IsNotNull(res.Response.MaxResults);
                    }
                }
                catch (QuickBooksException ex) when (ex.ResponseContent.Contains("Metadata not found for Entity"))
                {
                    //Ignore entities that don't support querying
                }
            }));
        }
    }
}
