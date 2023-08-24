namespace QuickBooksSharp
{
    public class RunPolicy
    {
        public static IRunPolicy DefaultRunPolicy { get; set; } = new MaxConcurrencyRetryRunPolicy();
    }
}
