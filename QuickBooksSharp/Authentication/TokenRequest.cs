namespace QuickBooksSharp
{
    public class TokenRequest
    {
        public string code { get; set; } = default!;

        public string redirect_uri { get; set; } = default!;

        /// <summary>
        /// "authorization_code" or "refresh_token"
        /// </summary>
        public string grant_type { get; set; } = default!;

        public string refresh_token { get; set; } = default!;
    }
}
