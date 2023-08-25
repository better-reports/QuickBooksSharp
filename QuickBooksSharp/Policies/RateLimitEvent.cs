using System;

namespace QuickBooksSharp
{
    public class RateLimitEvent
    {
        public long? RealmId { get; }

        public Uri RequestUri { get; }

        public RateLimitEvent(long? realmId, Uri requestUri)
        {
            RealmId = realmId;
            RequestUri = requestUri;
        }
    }
}
