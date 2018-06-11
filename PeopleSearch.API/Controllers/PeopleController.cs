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
        private IPeopleRepository _peopleRepository;

        public PeopleController(IPeopleRepository peopleRepository)
        {
            _peopleRepository = peopleRepository;
        }

        // GET api/people/name     
        [HttpGet("{name}")]
        public async Task<IActionResult> GetValue(string name)
        {
            try{
                if(name == null || name == ""){
                    return NotFound();
                }
                var nameL = name.ToLower();
                var data = await _peopleRepository.GetOne(nameL);
                return Ok(data);
            }
            catch{
                return StatusCode(500 , "Error occured while searching the database");
            }
            
        }

        // POST api/values 
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]userForRegisterDto userForRegisterDto)
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
                            
                    _peopleRepository.Add(userToCreate);
                    await _peopleRepository.SaveChanges();
                    return StatusCode(201); 
                }    
                catch{
                    return BadRequest();
                }
            }
 
    
    }
}
