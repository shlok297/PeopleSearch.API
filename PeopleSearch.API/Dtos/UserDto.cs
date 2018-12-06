using System.ComponentModel.DataAnnotations;

namespace PeopleSearch.API.Dtos
{
    public class UserDto
    {
        [Required(ErrorMessage ="Please enter first name")]
        [StringLength(30,ErrorMessage ="Character limit 30")]
        public string FirstName { get; set; }
         
        [Required(ErrorMessage ="Please enter last name")]
        [StringLength(30, ErrorMessage ="Character limit 30")]
        public string LastName { get; set; }
        
        [Required(ErrorMessage ="Please enter age")]
        [Range(1,200)]
        public int Age { get; set; }
         
        [Required(ErrorMessage ="Please enter address")]
        [StringLength(75, ErrorMessage ="Character limit 75")]
        public string StreetAddress { get; set; }
         
        [Required(ErrorMessage ="Please enter city")]
        [StringLength(30,ErrorMessage ="Character limit 30")]
        public string City { get; set; }
        
        [Required(ErrorMessage ="Please enter zip")]
        [StringLength(15,ErrorMessage ="Character limit 15")]
        public string Zip { get; set; }
        
        [Required(ErrorMessage ="Please enter country")]
        public string Country { get; set; }
        
        [StringLength(255,ErrorMessage ="Character limit 255")]
        public string Interests { get; set; }
        
        [Required(ErrorMessage ="Please enter state")]
        public string State { get; set; }

        public string Image { get; set; }
    }
}