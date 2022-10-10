using Microsoft.EntityFrameworkCore;
using Stock_Trading.Models;

namespace Stock_Trading.DAL
{
    public class StockContext : DbContext
    {
        public StockContext(DbContextOptions<StockContext> options) : base (options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Stock> stocks { get; set; }

        public DbSet<BrukerStock> brukerstock { get; set; }

        public DbSet<Bruker> brukere { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
