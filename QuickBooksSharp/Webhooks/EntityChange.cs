using QuickBooksSharp.Entities;
using System;
using System.Text.Json.Serialization;

namespace QuickBooksSharp
{
    /// <summary>
    /// Information about the entity that changed (customer, Invoice, etc.)
    /// </summary>
    public class EntityChange
    {
        /// <summary>
        /// The name of the entity that changed (customer, Invoice, etc.)
        /// </summary>
        [JsonPropertyName("name")]
        public EntityChangedName Name { get; set; }
        /// <summary>
        /// The ID of the changed entity
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; } = default!;
        /// <summary>
        /// The type of change
        /// </summary>
        [JsonPropertyName("operation")]
        public OperationEnum Operation { get; set; }
        /// <summary>
        /// The latest timestamp in UTC
        /// </summary>
        [JsonPropertyName("lastUpdated")]
        public DateTime LastUpdated { get; set; }
        /// <summary>
        /// The ID of the deleted or merged entity (this only applies to merge events)
        /// </summary>
        [JsonPropertyName("deletedId")]
        public string? DeletedId { get; set; }
    }
}
