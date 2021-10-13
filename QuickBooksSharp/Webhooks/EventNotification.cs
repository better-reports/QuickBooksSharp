using System.Text.Json.Serialization;

namespace QuickBooksSharp
{
    public class EventNotification
    {
        [JsonPropertyName("realmId")]
        public string RealmId { get; set; } = default!;
        [JsonPropertyName("dataChangeEvent")]
        public DataChangeEvent DataChangeEvent { get; set; } = default!;
    }
}
