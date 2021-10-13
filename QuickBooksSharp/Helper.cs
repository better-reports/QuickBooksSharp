using System;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace QuickBooksSharp
{
    public class Helper
    {
        /// <summary>
        /// Returns whether the webhook request was signed by Intui
        /// </summary>
        /// <param name="intuitSignature">Value from the HTTP header "intuit-signature"</param>
        /// <param name="webhookVerifierToken">The webhook verifier token located in the Intuit Developer dashboard</param>
        /// <param name="requestBody">The full HTTP requests body</param>
        /// <returns></returns>
        public static bool IsAuthenticWebhook(string intuitSignature, string webhookVerifierToken, string requestBody)
        {
            var verifierTokenBytes = Encoding.UTF8.GetBytes(webhookVerifierToken);
            var jsonBytes = Encoding.UTF8.GetBytes(requestBody);
            var hmac = new HMACSHA256(verifierTokenBytes);
            var hmacBytes = hmac.ComputeHash(jsonBytes);
            var hash = Convert.ToBase64String(hmacBytes);
            return hash == intuitSignature;
        }

        public static string SerializeToJSON(object o)
        {
            return JsonSerializer.Serialize(o, QuickBooksHttpClient.JsonSerializerOptions);
        }
    }
}
