using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PeopleSearch.API.Data;
using PeopleSearch.API.Dtos;
using PeopleSearch.API.Models;
using System.Drawing;
using PeopleSearch.API.Repository;
using PeopleSearch.API.Interface;


namespace PeopleSearch.API.Controllers
{
    [Route("api/[controller]")]
    public class PeopleController : Controller
    {
        private readonly IPeopleRepository peopleRepository;

        public PeopleController(IPeopleRepository peopleRepository)
        {
            this.peopleRepository = peopleRepository;
        }

        // GET api/people/name     
        [HttpGet("{name}")]
        public async Task<IActionResult> Get(string name)
        {
            if (String.IsNullOrWhiteSpace(name)){
                return NotFound();
            }
            List<People> data = await this.peopleRepository.GetUsers(name.ToLower());
            return Ok(data);
        }

        // POST api/values 
        [HttpPost("register")]
        public async Task<IActionResult> Post([FromBody]userForRegisterDto userForRegisterDto)
        {
            try{
                    if(!ModelState.IsValid){ 
                        return BadRequest(ModelState);
                    }
                    userForRegisterDto.FirstName  = userForRegisterDto.FirstName.ToLower();
                    userForRegisterDto.LastName  = userForRegisterDto.LastName.ToLower();
            
                    var createnewLocation = new Location{
                        Address = userForRegisterDto.Address,
                        City = userForRegisterDto.City,
                        State = userForRegisterDto.State,
                        Zip = userForRegisterDto.Zip,
                        Country = userForRegisterDto.Country
                    };

                    var userToCreate = new People{
                        FirstName = userForRegisterDto.FirstName,
                        LastName = userForRegisterDto.LastName,
                        Location = createnewLocation,
                        LocationId = createnewLocation.Id,
                        Age = userForRegisterDto.Age,
                        Interests = userForRegisterDto.Interests,
                        Image = userForRegisterDto.Image
                    };
                            
                    this.peopleRepository.Add(userToCreate);
                    await this.peopleRepository.SaveChanges();
                    return StatusCode(201); 
                }    
                catch{
                    return BadRequest();
                }
            }
 
    
    }
}
