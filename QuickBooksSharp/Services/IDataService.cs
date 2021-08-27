using QuickBooksSharp.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuickBooksSharp
{
    public interface IDataService
    {
        Task<IntuitResponse<BatchItemResponse[]>> BatchAsync(IntuitBatchRequest r);
        Task<IntuitResponse<IntuitEntity>> GetAsync(string id, Type entityType);
        Task<IntuitResponse<TEntity>> GetAsync<TEntity>(string id) where TEntity : IntuitEntity;
        Task<IntuitResponse<CDCResponse>> GetCDCAsync(DateTimeOffset changedSince, IEnumerable<string> entityNames);
        Task<Report> GetReportAsync(string reportName, Dictionary<string, string> parameters);
        Task<IntuitResponse<TEntity>> PostAsync<TEntity>(TEntity e) where TEntity : IntuitEntity;
        Task<IntuitResponse<QueryResponse<TEntity>>> QueryAsync<TEntity>(string query) where TEntity : IntuitEntity;
    }
}