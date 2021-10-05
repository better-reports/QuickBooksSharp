using System.Collections.Generic;

namespace QuickBooksSharp
{
    public class WebhookNotification
    {
        public List<EventNotification> EventNotifications { get; set; } = new List<EventNotification>();
    }
}
