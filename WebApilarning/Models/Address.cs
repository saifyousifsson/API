namespace WebApilarning.Models
{
    public class Address
    {
        public Address(string streetName, string postalCode, string country, string city)
        {
            StreetName = streetName;
            PostalCode = postalCode;
            Country = country;
            City = city;
        }

        public Address(int id, string streetName, string postalCode, string country, string city)
        {
            Id = id;
            StreetName = streetName;
            PostalCode = postalCode;
            Country = country;
            City = city;
        }

        public int Id { get; set; }
        public string StreetName { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
    }
}
