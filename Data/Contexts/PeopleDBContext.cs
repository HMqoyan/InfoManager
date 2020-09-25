using InfoManager.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace InfoManager.Data.Contexts
{
    public class PeopleDBContext : DbContext
    {
        public DbSet<Person> People { get; set; }
        public PeopleDBContext(DbContextOptions<PeopleDBContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
