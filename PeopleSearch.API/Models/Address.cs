namespace PeopleSearch.API.Models
{
    public class Address
    {
        public int Id { get; set; }

        public string StreetAddress { get; set; }
         
        public string City { get; set; }
        
        public string Zip { get; set; }
        
        public string Country { get; set; }
    
        public string State { get; set; }
    }
}