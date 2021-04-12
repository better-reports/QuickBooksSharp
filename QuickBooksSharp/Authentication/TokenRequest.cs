namespace QuickBooksSharp
{
    public class TokenRequest
    {
        public string code { get; set; }

        public string redirect_uri { get; set; }

        /// <summary>
        /// "authorization_code" or "refresh_token"
        /// </summary>
        public string grant_type { get; set; }

        public string refresh_token { get; set; }
    }
}
