namespace QuickBooksSharp
{
    public class QueryService : ServiceBase
    {
        public QueryService(string accessToken, long realmId, bool useSandbox) 
            : base(accessToken, realmId, useSandbox, "query")
        {
        }

    }
}
