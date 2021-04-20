using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuickBooksSharp.Entities;
using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;

namespace QuickBooksSharp.Tests
{
    [TestClass]
    public class DataServiceTests : ServiceTestBase
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
            var res = await _service.QueryAsync<Customer>("SELECT * FROM Customer");
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
        public async Task CreateUpdateParseUpdateCustomer()
        {
            string uniquifier = DateTime.Now.Ticks.ToString();
            var resCreate = await _service.PostAsync(new Customer
            {
                DisplayName = $"Test - My display name {uniquifier}",
                Suffix = "Jr",
                Title = "Mr",
                MiddleName = "Test - My middle name",
                FamilyName = "Test - My family name",
                GivenName = "Test - My given name",
            });
            Assert.IsNotNull(resCreate);
            Assert.IsNull(resCreate.Fault);
            Assert.IsNotNull(resCreate.Time);
            Assert.IsNotNull(resCreate.Response);
            Assert.IsNotNull(resCreate.Response.Id);
            Assert.IsNotNull(resCreate.Response.DisplayName);

            var resSparseUpdate = await _service.PostAsync(new Customer
            {
                Id = resCreate.Response.Id,
                SyncToken = resCreate.Response.SyncToken,
                GivenName = $"{resCreate.Response.GivenName} - sparsed",
                sparse = true
            });
            Assert.IsNotNull(resSparseUpdate);
            Assert.IsNull(resSparseUpdate.Fault);
            Assert.IsNotNull(resSparseUpdate.Time);
            Assert.IsNotNull(resSparseUpdate.Response);
            Assert.IsNotNull(resSparseUpdate.Response.Id);
            Assert.AreEqual(resSparseUpdate.Response.DisplayName, resCreate.Response.DisplayName);
            Assert.AreNotEqual(resSparseUpdate.Response.GivenName, resCreate.Response.GivenName);

            var c = resSparseUpdate.Response;
            c.FamilyName = $"{resSparseUpdate.Response.FamilyName} - full";
            c.sparse = false;
            var resFullUpdate = await _service.PostAsync(resSparseUpdate.Response);
            Assert.IsNotNull(resFullUpdate);
            Assert.IsNull(resFullUpdate.Fault);
            Assert.IsNotNull(resFullUpdate.Time);
            Assert.IsNotNull(resFullUpdate.Response);
            Assert.IsNotNull(resFullUpdate.Response.Id);
            Assert.AreEqual(resFullUpdate.Response.DisplayName, resCreate.Response.DisplayName);
            Assert.AreNotEqual(resFullUpdate.Response.FamilyName, resCreate.Response.FamilyName);
        }

        [TestMethod]
        public async Task QueryEntitiesCount()
        {
            await Task.WhenAll(_entityTypes
                .Where(t2 => !new[]
                                {
                                    typeof(TaxPayment),//Only available on AU/UK companies
                                    typeof(ExchangeRate),//Message=Error processing query
                                    typeof(CustomerType),//Detail=Dear entity developer, pl implement count query
                                }.Contains(t2))
                .Select(async t =>
            {
                try
                {
                    string entityName = t == typeof(QbTask) ? "Task" : t.Name;
                    var res = await _service.QueryAsync<IntuitEntity>($"SELECT COUNT(*) FROM {entityName}");
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
            var entities = new ConcurrentQueue<IntuitEntity>();
            await Task.WhenAll(_entityTypes
                 .Where(t2 => !new[]
                                {
                                    typeof(TaxPayment),//Only available on AU/UK companies
                                    typeof(Preferences), //deserialization bug
                                }.Contains(t2))
                .Select(async t =>
            {
                try
                {
                    string entityName = t == typeof(QbTask) ? "Task" : t.Name;
                    var res = await _service.QueryAsync<IntuitEntity>($"SELECT * FROM {entityName}");
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
                        if (res.Response.Entities.FirstOrDefault()?.Id != null)
                            entities.Enqueue(res.Response.Entities.FirstOrDefault());
                    }
                }
                catch (QuickBooksException ex) when (ex.ResponseContent.Contains("Metadata not found for Entity"))
                {
                    //Ignore entities that don't support querying
                }
            }));

            await Task.WhenAll(entities
                .Where(e => e.GetType() != typeof(TaxCode))//id is not numeric but Read endpoint expects number
                .Select(async e =>
            {
                var resOne = await _service.GetAsync(e.Id, e.GetType());
                Assert.IsNotNull(resOne);
                Assert.IsNotNull(resOne.Response);
                Assert.IsNotNull(resOne.Response.Id);
            }));
        }
    }
}
