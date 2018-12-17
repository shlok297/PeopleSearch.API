using Microsoft.EntityFrameworkCore;

using PeopleSearch.API.Models;

namespace PeopleSearch.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options){}

        public DbSet<User> User { get; set; }

        public DbSet<Address> Address { get; set; }
    }
}