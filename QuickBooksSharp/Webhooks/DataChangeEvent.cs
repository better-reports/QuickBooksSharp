using System.Text.Json.Serialization;

namespace QuickBooksSharp
{
    public class DataChangeEvent
    {
        [JsonPropertyName("entities")]
        public EntityChange[] Entities { get; set; } = default!;
    }
}
