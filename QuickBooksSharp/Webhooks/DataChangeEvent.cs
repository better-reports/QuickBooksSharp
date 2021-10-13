namespace QuickBooksSharp
{
    public class DataChangeEvent
    {
        public EntityChange[] Entities { get; set; } = default!;
    }
}
