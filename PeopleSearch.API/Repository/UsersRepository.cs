using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using PeopleSearch.API.Data;
using PeopleSearch.API.Interface;
using PeopleSearch.API.Models;

namespace PeopleSearch.API.Repository
{
    public class UsersRepository : IUsersRepository
    {
        private readonly DataContext databaseContext;

        public UsersRepository(DataContext context)
        {
            this.databaseContext = context;
        }

        public Task<List<User>> GetUsers(string name)
        {
            return databaseContext.User
                    .Include(user => user.Address)
                    .Where(user => user.FirstName.Contains(name) || user.LastName.Contains(name))
                    .ToListAsync();
        }

        public void Add(User user)
        {
            databaseContext.User.AddAsync(user);
        }

        public Task SaveChanges()
        {
            return databaseContext.SaveChangesAsync();
        }

    }
}