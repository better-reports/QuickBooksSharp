using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace QuickBooksSharp
{
    public static class RunPolicy
    {
        public static IRunPolicy DefaultRunPolicy { get; set; } = new MaxConcurrencyRetryRunPolicy();

        internal static ISubject<RateLimitEvent> _RateLimitFired = new Subject<RateLimitEvent>();

        public static readonly IObservable<RateLimitEvent> RateLimitFired = _RateLimitFired.AsObservable();

        internal static void NotifyRateLimt(RateLimitEvent rateLimitEvent)
        {
            _RateLimitFired.OnNext(rateLimitEvent);
        }
    }
}
