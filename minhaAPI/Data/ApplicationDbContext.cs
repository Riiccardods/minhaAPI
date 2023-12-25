using Microsoft.EntityFrameworkCore;
using minhaAPI.Models;

namespace minhaAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Nome> Nomes { get; set; }
    }
}
