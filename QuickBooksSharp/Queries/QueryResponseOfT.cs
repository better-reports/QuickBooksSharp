using QuickBooksSharp.Entities;

namespace QuickBooksSharp
{
    public class QueryResponse<TEntity> where TEntity : IntuitEntity
    {
        public Warnings? Warnings { get; set; }

        public int? StartPosition { get; set; }

        public int? MaxResults { get; set; }

        public int? TotalCount { get; set; }

        public Fault? Fault { get; set; }

        public TEntity[]? Entities { get; set; }
    }
}
