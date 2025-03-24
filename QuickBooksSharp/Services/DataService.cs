﻿using Flurl;
using QuickBooksSharp.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace QuickBooksSharp
{
    public class DataService : IDataService
    {
        protected readonly QuickBooksHttpClient _client;

        protected readonly Url _serviceUrl;

        public DataService(string accessToken, long realmId, bool useSandbox, IRunPolicy? runPolicy = null)
        {
            _client = new QuickBooksHttpClient(accessToken, realmId, runPolicy ?? RunPolicy.DefaultRunPolicy);
            _serviceUrl = QuickBooksUrl.Build(useSandbox, realmId);
        }

        public async Task<IntuitResponse<QueryCountResponse>> QueryCountAsync(string queryCount)
        {
            var res = await QueryAsync<IntuitEntity>(queryCount);
            return new IntuitResponse<QueryCountResponse>
            {
                RequestId = res.RequestId,
                Time = res.Time,
                Status = res.Status,
                Warnings = res.Warnings,
                Fault = res.Fault,
                Response = new QueryCountResponse
                {
                    Fault = res.Response?.Fault,
                    Warnings = res.Response?.Warnings,
                    TotalCount = res.Response?.TotalCount
                }
            };
        }

        public async Task<IntuitResponse<QueryResponse<TEntity>>> QueryAsync<TEntity>(string query) where TEntity : IntuitEntity
        {
            var res = await _client.GetAsync<IntuitResponse>(new Url(_serviceUrl).AppendPathSegment("query")
                                                                                 .SetQueryParam("query", query));
            var queryRes = res.QueryResponse;
            return new IntuitResponse<QueryResponse<TEntity>>
            {
                RequestId = res.requestId,
                Time = res.time,
                Status = res.status,
                Warnings = res.Warnings,
                Fault = res.Fault,
                Response = new QueryResponse<TEntity>
                {
                    MaxResults = queryRes?.maxResults,
                    StartPosition = queryRes?.startPosition,
                    TotalCount = queryRes?.totalCount,
                    Warnings = queryRes?.Warnings,
                    Fault = queryRes?.Fault,
                    Entities = queryRes?.IntuitObjects?.Cast<TEntity>().ToArray()
                }
            };
        }

        public async Task<IntuitResponse<TEntity>> GetAsync<TEntity>(string id) where TEntity : IntuitEntity
        {
            var res = await _client.GetAsync<IntuitResponse>(new Url(_serviceUrl).AppendPathSegment(GetEntityName(typeof(TEntity)))
                                                                                 .AppendPathSegment(id));
            return new IntuitResponse<TEntity>
            {
                RequestId = res.requestId,
                Time = res.time,
                Status = res.status,
                Warnings = res.Warnings,
                Fault = res.Fault,
                Response = (TEntity?)res.IntuitObject
            };
        }

        public async Task<IntuitResponse<IntuitEntity>> GetAsync(string id, Type entityType)
        {
            var res = await _client.GetAsync<IntuitResponse>(new Url(_serviceUrl).AppendPathSegment(GetEntityName(entityType))
                                                                                 .AppendPathSegment(id));
            return new IntuitResponse<IntuitEntity>
            {
                RequestId = res.requestId,
                Time = res.time,
                Status = res.status,
                Warnings = res.Warnings,
                Fault = res.Fault,
                Response = res.IntuitObject
            };
        }

        public async Task<Report> GetReportAsync(string reportName, Dictionary<string, string> parameters)
        {
            var url = new Url(_serviceUrl).AppendPathSegment($"reports/{reportName}");
            foreach (var p in parameters)
                url.SetQueryParam(p.Key, p.Value);
            return await _client.GetAsync<Report>(url);
        }

        public async Task<IntuitResponse<CDCResponse>> GetCDCAsync(DateTimeOffset changedSince, IEnumerable<string> entityNames)
        {
            var url = new Url(_serviceUrl).AppendPathSegment($"cdc")
                                          .SetQueryParam("changedSince", changedSince)
                                          .SetQueryParam("entities", string.Join(",", entityNames));
            var res = await _client.GetAsync<IntuitResponse>(url);
            return new IntuitResponse<CDCResponse>
            {
                RequestId = res.requestId,
                Time = res.time,
                Status = res.status,
                Warnings = res.Warnings,
                Fault = res.Fault,

                //https://help.developer.intuit.com/s/question/0D54R00007pjGeCSAU/in-the-xsd-why-is-intuitresponsecdcresponse-maxoccurs-unbounded
                Response = res.CDCResponse![0] //schema returns array but should be single => REPORT ERROR TO QB FORUM
            };
        }

        public async Task<IntuitResponse<BatchItemResponse[]>> BatchAsync(IntuitBatchRequest r)
        {
            var res = await _client.PostAsync<IntuitResponse>(new Url(_serviceUrl).AppendPathSegment("batch"), r);
            return new IntuitResponse<BatchItemResponse[]>
            {
                RequestId = res.requestId,
                Time = res.time,
                Status = res.status,
                Warnings = res.Warnings,
                Fault = res.Fault,
                Response = res.BatchItemResponse
            };
        }

        /// <inheritdoc/>
        public async Task<IntuitResponse<TEntity>> PostAsync<TEntity>(TEntity e, OperationEnum? operation = null, OperationEnum? include = null) where TEntity : IntuitEntity
        {
            var url = new Url(_serviceUrl).AppendPathSegment(GetEntityName(typeof(TEntity)));

            if (operation != null && operation != OperationEnum.Unspecified)
                url = url.SetQueryParam("operation", operation);

            if (include != null && include != OperationEnum.Unspecified)
                url = url.SetQueryParam("include", include);

            var res = await _client.PostAsync<IntuitResponse>(url, e);
            return new IntuitResponse<TEntity>
            {
                RequestId = res.requestId,
                Time = res.time,
                Status = res.status,
                Warnings = res.Warnings,
                Fault = res.Fault,
                Response = (TEntity?)res.IntuitObject
            };
        }

        private async Task<TEntity> PostWithEntityResultAsync<TEntity>(TEntity e)
        {
            var url = new Url(_serviceUrl).AppendPathSegment(GetEntityName(typeof(TaxService)));

            return await _client.PostAsync<TEntity>(url, e);
        }

        /// <remarks>
        /// Unlike other entities, TaxService is a special case where the return type is not an IntuitResponse but the entity itself.
        /// </remarks>
        public async Task<TaxService> PostTaxServiceAsync(TaxService taxService)
        {
            return await PostWithEntityResultAsync(taxService);
        }

        /// <inheritdoc/>
        public async Task<Stream> GetInvoicePDFAsync(string invoiceId)
        {
            var url = new Url(_serviceUrl).AppendPathSegment($"/invoice/{invoiceId}/pdf");
            var res = await _client.SendAsync(() =>
            {
                var httpRequest = new HttpRequestMessage(HttpMethod.Get, url);
                httpRequest.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/pdf"));
                return httpRequest;
            });

            return await res.Content.ReadAsStreamAsync();
        }

        private string GetEntityName(Type t)
        {
            if (t == typeof(CreditCardPaymentTxn))
                return "creditcardpayment";
            else if (t == typeof(TaxService))
                return "taxservice/taxcode";

            return t.Name.ToLowerInvariant();
        }
    }
}
