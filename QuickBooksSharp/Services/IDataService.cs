using QuickBooksSharp.Entities;
using System;
using System.Collections.Generic;
using System.IO;
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

        /// <summary>
        /// Create, Update, or SparseUpdate the entity, depending on the value of the 'sparse' property
        /// </summary>
        /// <typeparam name="TEntity">QuickBooks Entity</typeparam>
        /// <param name="e">Entity to be sent</param>
        /// <param name="include">Defines the operation to be executed in QuickBooks. For example: Required when voiding a payment</param>
        /// <returns></returns>
        Task<IntuitResponse<TEntity>> PostAsync<TEntity>(TEntity e, OperationEnum include = OperationEnum.Unspecified) where TEntity : IntuitEntity;

        Task<IntuitResponse<QueryResponse<TEntity>>> QueryAsync<TEntity>(string query) where TEntity : IntuitEntity;

        /// <summary>
        /// Get an invoice as PDF
        /// <para>This resource returns the specified object in the response body as an Adobe Portable Document Format (PDF) file. The resulting PDF file is formatted according to custom form styles in the company settings.</para>
        /// <see href="https://developer.intuit.com/app/developer/qbo/docs/api/accounting/most-commonly-used/invoice#get-an-invoice-as-pdf">QBO Documentation</see>
        /// </summary>
        /// <param name="invoiceId">Unique identifier for this object</param>
        /// <returns>This resource returns the specified object in the response body as an Adobe Portable Document Format (PDF) file. The resulting PDF file is formatted according to custom form styles in the company settings.</returns>
        Task<Stream> GetInvoicePDFAsync(string invoiceId);
    }
}