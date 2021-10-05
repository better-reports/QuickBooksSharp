using QuickBooksSharp.Entities;
using System;

namespace QuickBooksSharp
{
    public class EntityChanged
    {
        public QboEntityTypeEnum Name { get; set; }
        public string Id { get; set; } = string.Empty;
        public OperationEnum Operation { get; set; }
        public DateTime LastUpdated { get; set; }
        public string? DeletedId { get; set; }
    }
}
