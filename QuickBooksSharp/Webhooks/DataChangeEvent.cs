using System.Collections.Generic;

namespace QuickBooksSharp
{
    public class DataChangeEvent
    {
        public List<EntityChanged> Entities { get; set; } = new List<EntityChanged>();
    }
}
