namespace QuickBooksSharp
{
    public class UserInfo
    {
#pragma warning disable CS8618
        public string sub { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public string? email { get; set; }
        
        public bool? emailVerified { get; set; }
        
        public string? givenName { get; set; }

        public string? familyName { get; set; }

        public string? phoneNumber { get; set; }

        public bool? phoneNumberVerified { get; set; }
        
        public UserAddress? address { get; set; }

        public class UserAddress
        {
            public string? streetAddress { get; set; }
            
            public string? locality { get; set; }

            public string? region { get; set; }

            public string? postalCode { get; set; }

            public string? country { get; set; }
        }
    }
}
