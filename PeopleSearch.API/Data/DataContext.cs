using Microsoft.EntityFrameworkCore;
using PeopleSearch.API.Models;

namespace PeopleSearch.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options){}

        public DbSet<People> People { get; set; }

        public DbSet<Location> Location { get; set; }
    }
}