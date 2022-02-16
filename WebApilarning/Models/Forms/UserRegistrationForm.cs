namespace WebApilarning.Models.Forms
{
    public class UserRegistrationForm
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string StreetName { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public DateTime Created { get; set; }
      

    }
}
