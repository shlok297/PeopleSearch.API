using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using PeopleSearch.API.Dtos;
using PeopleSearch.API.Models;
using PeopleSearch.API.Interface;
using PeopleSearch.API.Constants;
using PeopleSearch.API.Mapper;

namespace PeopleSearch.API.Controllers
{
    [Route("api/users")]
    public class UsersController : Controller
    {
        private readonly IUsersRepository usersRepository;

        public UsersController(IUsersRepository usersRepository)
        {
            this.usersRepository = usersRepository;
        }

        // GET api/users/name     
        [HttpGet("{name}")]
        public async Task<IActionResult> GetUser(string name)
        {
            if (!String.IsNullOrWhiteSpace(name))
            {
                List<User> userData = await usersRepository.GetUsers(name.ToLower());
                if (userData.Count <= 0)
                {
                    return NotFound(ErrorMessages.UserNotFound);
                }
                return Ok(userData);
            }
            else
            {
                return BadRequest(ErrorMessages.NullOrEmptySpace);
            }
        }

        // POST api/users 
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody]UserDto userDto)
        {
            if (userDto != null)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                User user = Mapper.Mapper.UserDtoToUserMapper(userDto);           
                usersRepository.Add(user);
                await usersRepository.SaveChanges();
                return StatusCode(201); 
            }
            else
            {
                return BadRequest(ErrorMessages.NullUserData);
            }
        }
    }
}
