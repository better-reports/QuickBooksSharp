using Flurl;
using QuickBooksSharp.Entities;
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
            var res = await _client.GetAsync<IntuitResponse>(new Url(_serviceUrl).AppendPathSegment("query").SetQueryParam("query", query));
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
    }
}
