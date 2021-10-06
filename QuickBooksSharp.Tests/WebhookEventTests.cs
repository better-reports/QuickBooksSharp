using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text.Json;

namespace QuickBooksSharp.Tests
{
    [TestClass]
    public class WebhookEventTests
    {
        private readonly string _validNotification =
@"{
    ""eventNotifications"":[
        { 
            ""realmId"":""4620816365179422850"",
            ""dataChangeEvent"": {
                ""entities"": [
                    {
                        ""name"":""Customer"",
                        ""id"":""2"",
                        ""operation"":""Update"",
                        ""lastUpdated"":""2021-09-28T15:27:59.000Z""
                    },
                    {
                        ""name"":""Invoice"",
                        ""id"":""3"",
                        ""operation"":""Void"",
                        ""lastUpdated"":""2021-10-28T15:27:59.000Z""
                    },
                    {
                        ""name"":""CreditMemo"",
                        ""id"":""4"",
                        ""operation"":""merge"",
                        ""lastUpdated"":""2021-11-28T15:27:59.000Z"",
                        ""deletedId"":""5""
                    }
                ]
            }
        }
    ]
}";

        [TestMethod]
        public void ShouldDeserializeValidJson()
        {
            WebhookEvent notification = JsonSerializer.Deserialize<WebhookEvent>(_validNotification, WebhookEvent.JsonSerializerOptions);

            Assert.IsNotNull(notification);
            Assert.IsNotNull(notification.EventNotifications);
            Assert.IsTrue(notification.EventNotifications.Length > 0);
            Assert.IsNotNull(notification.EventNotifications[0]);
            Assert.IsNotNull(notification.EventNotifications[0].DataChangeEvent);
            Assert.IsNotNull(notification.EventNotifications[0].DataChangeEvent.Entities);
            Assert.IsTrue(notification.EventNotifications[0].DataChangeEvent.Entities.Length > 0);
            // Customer
            Assert.IsNotNull(notification.EventNotifications[0].DataChangeEvent.Entities[0]);
            Assert.IsTrue(notification.EventNotifications[0].DataChangeEvent.Entities[0].Id == "2");
            Assert.IsNull(notification.EventNotifications[0].DataChangeEvent.Entities[0].DeletedId);
            Assert.IsTrue(notification.EventNotifications[0].DataChangeEvent.Entities[0].Name == EntityChangedName.Customer);
            Assert.IsTrue(notification.EventNotifications[0].DataChangeEvent.Entities[0].Operation == Entities.OperationEnum.update);
            Assert.IsTrue(notification.EventNotifications[0].DataChangeEvent.Entities[0].LastUpdated == new DateTime(2021, 9, 28, 15, 27, 59, DateTimeKind.Utc));
            // Invoice
            Assert.IsNotNull(notification.EventNotifications[0].DataChangeEvent.Entities[1]);
            Assert.IsTrue(notification.EventNotifications[0].DataChangeEvent.Entities[1].Id == "3");
            Assert.IsNull(notification.EventNotifications[0].DataChangeEvent.Entities[1].DeletedId);
            Assert.IsTrue(notification.EventNotifications[0].DataChangeEvent.Entities[1].Name == EntityChangedName.Invoice);
            Assert.IsTrue(notification.EventNotifications[0].DataChangeEvent.Entities[1].Operation == Entities.OperationEnum.@void);
            Assert.IsTrue(notification.EventNotifications[0].DataChangeEvent.Entities[1].LastUpdated == new DateTime(2021, 10, 28, 15, 27, 59, DateTimeKind.Utc));
            // CreditMemo
            Assert.IsNotNull(notification.EventNotifications[0].DataChangeEvent.Entities[2]);
            Assert.IsTrue(notification.EventNotifications[0].DataChangeEvent.Entities[2].Id == "4");
            Assert.IsTrue(notification.EventNotifications[0].DataChangeEvent.Entities[2].DeletedId == "5");
            Assert.IsTrue(notification.EventNotifications[0].DataChangeEvent.Entities[2].Name == EntityChangedName.CreditMemo);
            Assert.IsTrue(notification.EventNotifications[0].DataChangeEvent.Entities[2].Operation == Entities.OperationEnum.merge);
            Assert.IsTrue(notification.EventNotifications[0].DataChangeEvent.Entities[2].LastUpdated == new DateTime(2021, 11, 28, 15, 27, 59, DateTimeKind.Utc));
        }
    }
}
