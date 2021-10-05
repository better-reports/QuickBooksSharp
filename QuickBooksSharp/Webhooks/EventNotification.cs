namespace QuickBooksSharp
{
    public class EventNotification
    {
        public string RealmId { get; set; } = string.Empty;
        public DataChangeEvent DataChangeEvent { get; set; } = new DataChangeEvent();
    }
}
