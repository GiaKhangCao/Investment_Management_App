using IMA.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace IMA.Web.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Portfolio> Porforlios { get; set; }
        public DbSet<Investment> Investments { get; set; } 
        public DbSet<Transaction> Transactions { get; set; }
    }
}
