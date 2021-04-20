using Flurl;
using QuickBooksSharp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickBooksSharp
{
    public class DataService : ServiceBase
    {
        public DataService(string accessToken, long realmId, bool useSandbox) 
            : base(accessToken, realmId, useSandbox)
        {
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
            var res = await _client.GetAsync<IntuitResponse>(new Url(_serviceUrl).AppendPathSegment(typeof(TEntity).Name.ToLowerInvariant())
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
            var res = await _client.GetAsync<IntuitResponse>(new Url(_serviceUrl).AppendPathSegment(entityType.Name.ToLowerInvariant())
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

        /// <summary>
        /// Create, Update, or SparseUpdate the entity, depending on the value of the 'sparse' property
        /// </summary>
        public async Task<IntuitResponse<TEntity>> PostAsync<TEntity>(TEntity e) where TEntity : IntuitEntity
        {
            var res = await _client.PostAsync<IntuitResponse>(new Url(_serviceUrl).AppendPathSegment(typeof(TEntity).Name.ToLowerInvariant()), e);
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
    }
}
