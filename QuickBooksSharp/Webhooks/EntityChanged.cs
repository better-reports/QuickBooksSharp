using QuickBooksSharp.Entities;
using System;

namespace QuickBooksSharp
{
    /// <summary>
    /// Information about the entity that changed (customer, Invoice, etc.)
    /// </summary>
    public class EntityChanged
    {
        /// <summary>
        /// The name of the entity that changed (customer, Invoice, etc.)
        /// </summary>
        public EntityChangedName Name { get; set; }
        /// <summary>
        /// The ID of the changed entity
        /// </summary>
        public string Id { get; set; } = string.Empty;
        /// <summary>
        /// The type of change
        /// </summary>
        public OperationEnum Operation { get; set; }
        /// <summary>
        /// The latest timestamp in UTC
        /// </summary>
        public DateTime LastUpdated { get; set; }
        /// <summary>
        /// The ID of the deleted or merged entity (this only applies to merge events)
        /// </summary>
        public string? DeletedId { get; set; }
    }
}
