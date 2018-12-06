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
        private readonly DataContext databaseContext;

        public PeopleRepository(DataContext context)
        {
            this.databaseContext = context;
        }

        public Task<List<User>> GetUsers(string name)
        {
            return this.databaseContext.User
                    .Include(user => user.Address)
                    .Where(user => user.FirstName.Contains(name) || user.LastName.Contains(name))
                    .ToListAsync();
        }

        public void Add(User user)
        {
            this.databaseContext.User.AddAsync(user);
        }

        public Task SaveChanges()
        {
            return this.databaseContext.SaveChangesAsync();
        }

    }
}