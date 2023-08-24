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
        private readonly Type[] _entityTypes = new[]
        {
            typeof(Account),
            typeof(BillPayment),
            typeof(Bill),
            typeof(Budget),
            typeof(Class),
            typeof(CompanyCurrency),
            typeof(CompanyInfo),
            typeof(CreditCardPayment),
            typeof(CreditMemo),
            typeof(Customer),
            typeof(CustomerType),
            typeof(Deposit),
            typeof(Employee),
            typeof(Estimate),
            typeof(ExchangeRate),
            typeof(Invoice),
            typeof(Item),
            typeof(JournalEntry),
            typeof(Department),
            typeof(PaymentMethod),
            typeof(Payment),
            typeof(Preferences),
            typeof(PurchaseOrder),
            typeof(Purchase),
            typeof(RefundReceipt),
            typeof(ReimburseCharge),
            typeof(SalesReceipt),
            typeof(TaxAgency),
            typeof(TaxClassification),
            typeof(TaxCode),
            typeof(TaxRate),
            typeof(Term),
            typeof(TimeActivity),
            typeof(Transfer),
            typeof(VendorCredit),
            typeof(Vendor),
        };

        [TestInitialize]
        public async Task Initialize()
        {
            var accessToken = await GetAccessTokenAsync();
            _service = new DataService(accessToken, TestHelper.RealmId, true);
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
                                    typeof(CompanyInfo),//Total count not returned
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
                { "date_macro", "Last Fiscal Year" }
            });
            Assert.IsNotNull(r);
            Assert.IsNotNull(r.Header?.ReportName);
            Assert.IsTrue(r.Rows.Row.Length != 0);
            Assert.IsTrue(r.Columns.Column.Length != 0);
        }

        [TestMethod]
        public async Task GetTransactionDetailByAccount()
        {
            var includedColumns = new[]
            {
                "account_name",
                "create_by",
                "create_date",
                "credit_amt",
                "credit_home_amt",
                "currency",
                "cust_name",
                "debt_amt",
                "debt_home_amt",
                "dept_name",
                "doc_num",
                "due_date",
                "emp_name",
                "exch_rate",
                "foreign_net_amount",
                "foreign_tax_amount",
                "home_net_amount",
                "home_tax_amount",
                "net_amount",
                "tax_amount",
                "is_adj",
                "is_ap_paid",
                "is_ar_paid",
                "is_cleared",
                "item_name",
                "klass_name",
                "last_mod_by",
                "last_mod_date",
                "memo",
                "nat_foreign_amount",
                "nat_foreign_open_bal",
                "nat_home_open_bal",
                "nat_open_bal",
                "olb_status",
                "pmt_mthd",
                "quantity",
                "rate",
                "split_acc",
                "subt_nat_home_amount",
                "subt_nat_amount",
                "tax_code_name",
                "tax_type",
                "tx_date",
                "txn_type",
                "vend_name",
            };
            var r = await _service.GetReportAsync("TransactionDetailByAccount", new()
            {
                { "columns", string.Join(",", includedColumns) },
                { "transaction_type", "post" },
                { "groupby", "none" },
                { "accounting_method", "Cash" },
                { "sort_by", "create_date" },
                { "sort_order", "descend" },
                { "start_date", DateTime.Today.AddMonths(-1).ToString("yyyy-MM-dd") },
                { "end_date", DateTime.Today.ToString("yyyy-MM-dd") },
            });
            Assert.IsNotNull(r);
            Assert.IsNotNull(r.Header?.ReportName);
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
        }

        [TestMethod]
        public async Task BatchQuery()
        {
            var response = await _service.BatchAsync(new IntuitBatchRequest
            {
                BatchItemRequest = new[]
                {
                        new BatchItemRequest
                        {
                            bId = Guid.NewGuid().ToString(),
                            Query = "SELECT * FROM Bill MAXRESULTS 30",
                        },
                        new BatchItemRequest
                        {
                            bId = Guid.NewGuid().ToString(),
                            Query = "SELECT * FROM Invoice MAXRESULTS 30",
                        }
                }
            });
            Assert.IsTrue(response.Response.ElementAt(0).QueryResponse.Bill.Length > 0);
            Assert.IsTrue(response.Response.ElementAt(1).QueryResponse.Invoice.Length > 0);
        }

        [TestMethod]
        public async Task GetInvoicePDFAsync()
        {
            var response = await _service.QueryAsync<Invoice>("SELECT * FROM Invoice MAXRESULTS 1");

            Assert.IsTrue(response.Response.Entities.Length > 0);

            var invoidePdfStream = await _service.GetInvoicePDFAsync(response.Response.Entities[0].Id);

            Assert.IsNotNull(invoidePdfStream);
            Assert.IsNotNull(invoidePdfStream.Length > 0);
        }

        [TestMethod]
        public async Task CreatePaymentAndVoidAsync()
        {
            // GET an Open Invoice
            var invoiceResponse = await _service.QueryAsync<Invoice>(
                "SELECT * FROM Invoice " +
                "WHERE Balance > '0' " +
                "ORDERBY DueDate DESC, Balance DESC " +
                "MAXRESULTS 1");

            if (invoiceResponse.Response.Entities.Length == 0)
            {
                Assert.Fail("No Invoices returned");
            }

            var invoice = invoiceResponse.Response.Entities[0];

            // Create a Payment for that Invoice
            var payment = new Payment()
            {
                CustomerRef = invoice.CustomerRef,
                TotalAmt = 1,
                Line = new[] {
                    new Line
                    {
                        Amount = 1,
                        LinkedTxn = new LinkedTxn[] { new LinkedTxn
                        {
                            TxnId = invoice.Id,
                            TxnType = $"{QboEntityTypeEnum.INVOICE}"
                        } }
                    }
                },
                PrivateNote = "Payment made by QuickBooksSharp"
            };

            var paymentResponse = await _service.PostAsync(payment);

            Assert.IsTrue(paymentResponse.Response != null);

            // Void Payment
            var voidPayment = new Payment()
            {
                Id = paymentResponse.Response.Id,
                SyncToken = paymentResponse.Response.SyncToken,
                sparse = true,
                PrivateNote = "Payment voided by QuickBooksSharp"
            };

            var voidPaymentResponse = await _service.PostAsync(voidPayment, OperationEnum.@void);

            Assert.IsNotNull(voidPaymentResponse.Response);
        }
    }
}
