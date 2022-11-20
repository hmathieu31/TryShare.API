using INSAT._4I4U.TryShare.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace INSAT._4I4U.TryShare.TricyclesAvailable.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Tricycle> Tricycles { get; set; }
    }
}
