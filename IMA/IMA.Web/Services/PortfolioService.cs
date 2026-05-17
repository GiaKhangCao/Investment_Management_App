using IMA.Shared.Interfaces;
using IMA.Web.Data;
using IMA.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace IMA.Web.Services
{
    public class PortfolioService : IPortfolioService
    {
        private readonly IDbContextFactory<AppDbContext> _dbFactory;

        public PortfolioService(IDbContextFactory<AppDbContext> dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public async Task<List<Portfolio>> GetAllAsync()
        {
            await using var db = await _dbFactory.CreateDbContextAsync();
            return await db.Portfolios.Include(p => p.investments).ToListAsync();
        }

        public async Task AddAsync(Portfolio portfolio)
        {
            await using var db = await _dbFactory.CreateDbContextAsync();
            db.Portfolios.Add(portfolio);
            await db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await using var db = await _dbFactory.CreateDbContextAsync();
            var portfolio = await db.Portfolios.FindAsync(id);
            if (portfolio != null)
            {
                db.Portfolios.Remove(portfolio);
                await db.SaveChangesAsync();
            }
        }
    }
}
