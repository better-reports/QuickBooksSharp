namespace QuickBooksSharp
{
    public enum RateLimitBreachBehavior
    {
        /// <summary>
        /// Throw an exception. This is the default
        /// </summary>
        Throw,

        /// <summary>
        /// Wait one minute and retry (once only)
        /// </summary>
        WaitAndRetryOnce
    }
}
