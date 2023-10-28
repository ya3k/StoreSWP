using Microsoft.EntityFrameworkCore;
using StoreSWP.Models;

namespace StoreSWP.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Speaker> Speakers { get; set; }
        public DbSet<Brand> Brands { get; set; }


    }
}
