using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

using PeopleSearch.API.Dtos;
using PeopleSearch.API.Models;
using PeopleSearch.API.Interface;
using PeopleSearch.API.Constants;


namespace PeopleSearch.API.Controllers
{
    [Route("api/users")]
    public class PeopleController : Controller
    {
        private readonly IPeopleRepository peopleRepository;

        public PeopleController(IPeopleRepository peopleRepository)
        {
            this.peopleRepository = peopleRepository;
        }

        // GET api/users/name     
        [HttpGet("{name}")]
        public async Task<IActionResult> GetUser(string name)
        {
            if (!String.IsNullOrWhiteSpace(name))
            {
                List<User> userData = await this.peopleRepository.GetUsers(name.ToLower());
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
        public async Task<IActionResult> Post([FromBody]UserDto userData)
        {
            if (userData != null)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                Address address = Mapper.Map<Address>(userData);
                User user = Mapper.Map<User>(userData);
                user.Address = address;

                this.peopleRepository.Add(user);
                await this.peopleRepository.SaveChanges();
                return StatusCode(201); 
            }
            else
            {
                return BadRequest(ErrorMessages.NullUserData);
            }
        }
    }
}
