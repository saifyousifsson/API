namespace WebApilarning.Models
{
    public class User
    {
        public User()
        {

        }

        public User(int id, string firstName, string lastName, string email)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

     

        public User(int id, string firstName, string lastName, string email, Product product)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

        public User(int id, string firstName, string lastName, string email, string streetName, string postalCode, string country, string city)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            StreetName = streetName;
            PostalCode = postalCode;
            Country = country;
            City = city;
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string StreetName { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string City { get; set; }

        public string DisplayName => $"{FirstName} {LastName}";

        public string Address => $"{StreetName}, {PostalCode} {City}";
    }
}
