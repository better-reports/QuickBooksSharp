using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace QuickBooksSharp
{
    /// <summary>
    /// Webhooks are designed to handle updates for multiple QuickBooks Online companies (specified by the realm ID).
    /// However, each notification is tied to a single realm ID.If your app is connected to multiple QuickBooks Online companies, you’ll get individual webhook notifications for each company (i.e.one eventNotification per realm ID).
    /// 
    /// <para>Documentation: https://developer.intuit.com/app/developer/qbo/docs/develop/webhooks </para>
    /// </summary>
    /// <remarks>
    /// There are no Intuit-imposed limits to payload size or number of events. Individual server architectures may impose their own limits (2MB is a common default size limit). Assume this limit is imposed by your server unless you know otherwise.
    /// </remarks>
    public class WebhookEvent
    {
        public EventNotification[] EventNotifications { get; set; } = new EventNotification[0];

        public readonly static JsonSerializerOptions JsonSerializerOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            Converters =
            {
                //new JsonStringEnumConverter(),

                //using community package to fix https://github.com/dotnet/runtime/issues/31081
                //can revert to out of the box converter once fix (.net 6?)
                new JsonStringEnumMemberConverter()
            }
        };
    }
}
