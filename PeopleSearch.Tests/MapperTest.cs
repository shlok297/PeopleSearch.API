using Xunit;

using PeopleSearch.API.Dtos;
using PeopleSearch.API.Mapper;
using PeopleSearch.API.Models;

namespace PeopleSearch.Tests
{
    public class MapperTest
    {
        [Fact]
        public void UserDtoToUserMap()
        {
            // Arrange
            UserDto userDto = new UserDto()
            {
                FirstName = "Shlok",
                LastName = "PATEL",
                Age = 25,
                StreetAddress = "street",
                City = "SLC",
                Zip = "84102",
                Country = "USA",
                Interests = "ASP",
                State = "Utah",
                Image = ""
            };

            // Act
            User user= Mapper.UserDtoToUserMapper(userDto);

            // Assert
            Assert.Equal(userDto.FirstName.ToLower(), user.FirstName);
            Assert.Equal(userDto.LastName.ToLower(), user.LastName);
            Assert.Equal(userDto.Age, user.Age);
            Assert.Equal(userDto.Interests, user.Interests);
            Assert.Equal(userDto.Image, user.Image);

            Assert.Equal(userDto.StreetAddress, user.Address.StreetAddress);
            Assert.Equal(userDto.City, user.Address.City);
            Assert.Equal(userDto.Zip, user.Address.Zip);
            Assert.Equal(userDto.State, user.Address.State);
            Assert.Equal(userDto.Country, user.Address.Country);
        }
    }
}
