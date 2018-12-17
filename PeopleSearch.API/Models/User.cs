namespace PeopleSearch.API.Models
{
    public class User
    {
        public int Id { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public int AddressId { get; set; }

        public Address Address { get; set; }
        
        public string Interests { get; set; }

        public int Age { get; set; }

        public string Image { get; set; }
    }
}