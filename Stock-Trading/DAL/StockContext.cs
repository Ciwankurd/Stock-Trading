using Microsoft.EntityFrameworkCore;
namespace Stock_Trading.DAL
{
    public class StockContext : DbContext
    {
        public StockContext(DbContextOptions<StockContext> options) : base (options)
        {
            Database.EnsureCreated();
        }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
