using System.Collections.Generic;

namespace QuickBooksSharp
{
    public class DataChangeEvent
    {
        public EntityChanged[] Entities { get; set; } = new EntityChanged[0];
    }
}
