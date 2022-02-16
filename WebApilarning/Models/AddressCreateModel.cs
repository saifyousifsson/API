namespace WebApilarning.Models
{
    public class AddressCreateModel
    {
        public AddressCreateModel(string streetName, string postalCode, string country, string city)
        {
            StreetName = streetName;
            PostalCode = postalCode;
            Country = country;
            City = city;
        }

        public string StreetName { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string City { get; set; }

    }
}
