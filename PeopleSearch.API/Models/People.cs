namespace PeopleSearch.API.Models
{
    public class People
    {
        public int Id { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        

        public int LocationId { get; set; }
        public Location Location { get; set; }
        
        public string Interests { get; set; }
        public int Age { get; set; }
        public string Image { get; set; }

    }
}