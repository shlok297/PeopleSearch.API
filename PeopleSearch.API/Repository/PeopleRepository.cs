using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PeopleSearch.API.Data;
using PeopleSearch.API.Interface;
using PeopleSearch.API.Models;

namespace PeopleSearch.API.Repository
{
    public class PeopleRepository : IPeopleRepository
    {
        private readonly DataContext _context;

        public PeopleRepository(DataContext context)
        {
            _context = context;
        }

        public Task<List<People>> GetUsers (string name) =>
           _context.People.Include(x => x.Location).Where(x => x.FirstName.Contains(name) || x.LastName.Contains(name)).ToListAsync();
        
        public void Add(People people) =>
            _context.People.AddAsync(people);
    
        public Task SaveChanges() => 
            _context.SaveChangesAsync();

    }
}