using Microsoft.EntityFrameworkCore;
using TuristApp2.Models;
using TuristApp2.Models.TuristApp2.Models;

namespace TuristApp2.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Miejsca> Miejsca { get; set; }

        public DbSet<Posty> Posty { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
    }
}
