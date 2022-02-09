using Microsoft.EntityFrameworkCore;
using TouristGuide.API.Models;

namespace TouristGuide.API.Data
{
    public class TouristGuideContext : DbContext
    {
        public TouristGuideContext(DbContextOptions<TouristGuideContext> options) : base(options)
        {

        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Photo> Photos { get; set; }
    }
}
