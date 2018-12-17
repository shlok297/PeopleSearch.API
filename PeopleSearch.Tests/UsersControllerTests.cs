using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using Xunit.Abstractions;

using PeopleSearch.API.Controllers;
using PeopleSearch.API.Dtos;
using PeopleSearch.API.Interface;

namespace PeopleSearch.Tests
{
    public class UsersControllerTests
    {
        private Mock<IUsersRepository> _usersRepoMock;
        private UsersController _controller;

        public UsersControllerTests(ITestOutputHelper output)
        {
            _usersRepoMock = new Mock<IUsersRepository>();
            _controller = new UsersController(_usersRepoMock.Object);
        }

        [Fact]
        public async Task GetUsers_NullStringProvided()
        {
            // Arrange
            string searchString = null;

            // Act
            IActionResult result = await _controller.GetUser(searchString);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task GetUsers_NoStringProvided()
        {
            // Arrange
            string searchString = "";

            // Act
            IActionResult result = await _controller.GetUser(searchString);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task CreateUser_NullUser()
        {
            // Arrange
            UserDto user = null;

            // Act
            IActionResult result = await _controller.CreateUser(user);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task CreateUser_ValidUser()
        {
            // Arrange
            UserDto user = new UserDto()
            {
                FirstName = "Shlok",
                LastName = "Patel",
                Age = 26,
                StreetAddress = "street",
                City = "SLC",
                Zip = "84102",
                Country = "USA",
                Interests = "ASP",
                State = "Utah",
                Image = ""
            };

            // Act
            IActionResult result = await _controller.CreateUser(user);

            // Assert
            var actionResult = Assert.IsType<StatusCodeResult>(result);
        }
    }
}
