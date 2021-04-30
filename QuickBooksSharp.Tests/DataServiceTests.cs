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
                                                .OrderBy(t => t.Name)
                                                .Where(t => typeof(IntuitEntity).IsAssignableFrom(t) && !t.IsAbstract)
                                                .Where(t => t != typeof(CompanyInfo))
                                                .ToArray();

        [TestInitialize]
        public async Task Initialize()
        {
            _service = new DataService(await GetAccessTokenAsync(), TestHelper.RealmId, true);
            //exclude abstract types
            var excludedTypes = _entityTypes.Where(t => _entityTypes.Any(t2 => t != t2 && t2.IsAssignableTo(t)))
                                            .Except(new[] { typeof(Account), typeof(Vendor) })
                                            .ToArray();
            _entityTypes = _entityTypes.Except(excludedTypes).ToArray();
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
                                    typeof(ExchangeRate),//Message=Error processing query https://help.developer.intuit.com/s/question/0D54R00007pirJESAY/the-following-query-results-in-an-error-select-count-from-exchangerateerror-returned-from-api-error-processing-query
                                    typeof(CustomerType),//Detail=Dear entity developer, pl implement count query https://help.developer.intuit.com/s/question/0D54R00007pirJFSAY/select-count-from-customertype-returns-an-error
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
                        {
                            //Built-in tax code entities can have non numeric id TAX  or NON
                            //See https://help.developer.intuit.com/s/question/0D74R000004jvUi
                            entities.Enqueue(res.Response.Entities.FirstOrDefault(i => long.TryParse(i.Id, out _)));
                        }
                    }
                }
                catch (QuickBooksException ex) when (ex.ResponseContent.Contains("Metadata not found for Entity"))
                {
                    //Ignore entities that don't support querying
                }
            }));

            await Task.WhenAll(entities
                //https://help.developer.intuit.com/s/question/0D54R00007pisJuSAI/taxcode-id-tax-instead-of-numeric-ids
                .Select(async e =>
            {
                var resOne = await _service.GetAsync(e.Id, e.GetType());
                Assert.IsNotNull(resOne);
                Assert.IsNotNull(resOne.Response);
                Assert.IsNotNull(resOne.Response.Id);
            }));
        }

        [TestMethod]
        public async Task GetProfitAndLossReport()
        {
            var r = await _service.GetReportAsync("ProfitAndLoss", new()
            {
                { "accounting_method", "Accrual" },
                { "date_macro", "Last Fiscal Year" }
            });
            Assert.IsNotNull(r);
            Assert.IsNotNull(r.Header?.ReportName);
            Assert.IsTrue(r.Rows.Row.Length != 0);
            Assert.IsTrue(r.Columns.Column.Length != 0);
        }

        [TestMethod]
        public async Task GetJournalReport()
        {
            var r = await _service.GetReportAsync("JournalReport", new()
            {
                { "docnum", "1047" }
            });
            Assert.IsNotNull(r);
            Assert.IsNotNull(r.Header?.ReportName);
            Assert.IsTrue(r.Rows.Row.Length != 0);
            Assert.IsTrue(r.Columns.Column.Length != 0);
        }

        [TestMethod]
        public async Task GetCDC()
        {
            var entityTypes = _entityTypes.Except(new[]
                                        {
                                            typeof(TaxPayment), //UK/AU only

                                            //not all entities are supported by CDC
                                            typeof(QbdtEntityIdMapping),
                                            typeof(ConvenienceFeeDetail),
                                            typeof(EmailDeliveryInfo),
                                            typeof(Tag),
                                            typeof(FixedAsset),
                                            typeof(MasterAccount),
                                            typeof(StatementCharge),
                                            typeof(JournalCode),
                                            typeof(SalesOrder),
                                            typeof(SalesRep),
                                            typeof(PriceLevel),
                                            typeof(PriceLevelPerItem),
                                            typeof(CustomerMsg),
                                            typeof(InventorySite),
                                            typeof(ShipMethod),
                                            typeof(QbTask),
                                            typeof(UOM),
                                            typeof(TemplateName),
                                            typeof(TDSMetadata),
                                            typeof(BooleanTypeCustomFieldDefinition),
                                            typeof(DateTypeCustomFieldDefinition),
                                            typeof(NumberTypeCustomFieldDefinition),
                                            typeof(StringTypeCustomFieldDefinition),
                                            typeof(ChargeCredit),
                                            typeof(JobType),
                                            typeof(OtherName),
                                            typeof(Status),
                                            typeof(SyncActivity),
                                            typeof(TaxAgency),
                                            typeof(TaxClassification),
                                            typeof(TaxService),
                                            typeof(User),
                                            typeof(VendorType),
                                            typeof(Currency),
                                        })
                                        .OrderBy(t => t.Name);

            await Task.WhenAll(entityTypes.Select(async t =>
            {
                var res = await _service.GetCDCAsync(DateTimeOffset.UtcNow.AddDays(-10), new[] { t.Name });
                Assert.IsNotNull(res);
                Assert.IsNotNull(res.Response);
                Assert.IsTrue(res.Response.QueryResponse.Length == 1);
                var queryResponse = res.Response.QueryResponse.First();
                if (queryResponse.IntuitObjects != null)
                    Assert.IsTrue(queryResponse.IntuitObjects.All(o => o.GetType() == t));
            }));

            var resAll = await _service.GetCDCAsync(DateTimeOffset.UtcNow.AddDays(-10), entityTypes.Select(t => t.Name));
            Assert.IsNotNull(resAll);
            Assert.IsNotNull(resAll.Response);
            Assert.IsTrue(resAll.Response.QueryResponse.Length == entityTypes.Count());
            foreach (var i in Enumerable.Zip(resAll.Response.QueryResponse, entityTypes))
            {
                if (i.First.IntuitObjects != null)
                    Assert.IsTrue(i.First.IntuitObjects.All(o => o.GetType() == i.Second));
            }
        }
    }
}
