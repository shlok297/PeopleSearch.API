using PeopleSearch.API.Models;
using PeopleSearch.API.Dtos;

namespace PeopleSearch.API.Mapper
{
    public static class Mapper
    {
        public static User UserDtoToUserMapper(UserDto userDto)
        {
            Address address = new Address()
            {
                StreetAddress = userDto.StreetAddress,
                City = userDto.City,
                Zip = userDto.Zip,
                Country = userDto.Country,
                State = userDto.State
            };

            return new User()
            {
                FirstName = userDto.FirstName.ToLower(),
                LastName = userDto.LastName.ToLower(),
                Age = userDto.Age,
                Address = address,
                Interests = userDto.Interests,
                Image = userDto.Image
            };
        }
    }
}
