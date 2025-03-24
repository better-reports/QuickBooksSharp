using QuickBooksSharp.Entities;

namespace QuickBooksSharp
{
    public class QueryCountResponse
    {
        public Warnings? Warnings { get; set; }

        public int? TotalCount { get; set; }

        public Fault? Fault { get; set; }
    }
}
