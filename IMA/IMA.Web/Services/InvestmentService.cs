using IMA.Shared.Interfaces;
using IMA.Web.Data;
using IMA.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace IMA.Web.Services
{
    public class InvestmentService : IInvestmentService
    {
        private readonly IDbContextFactory<AppDbContext> _dbFactory;

        public InvestmentService(IDbContextFactory<AppDbContext> dbFactory)
        {
            _dbFactory = dbFactory;
        }
        public async Task<List<Investment>> GetAllAsync()
        {
            await using var db = await _dbFactory.CreateDbContextAsync();
            return await db.Investments
                .Include(i => i.portfolio)
                .Include(i => i.transactions)
                .ToListAsync();
        }
        public async Task<List<Investment>> GetByType(string assetType)
        {
            await using var db = await _dbFactory.CreateDbContextAsync();
            return await db.Investments
                .Where(i => i.assetType == assetType)
                .Include(i => i.transactions)
                .ToListAsync();
        }
        public async Task<List<Investment>> GetByTicker(string ticker)
        {
            await using var db = await _dbFactory.CreateDbContextAsync();
            return await db.Investments
                .Where(i => i.ticker == ticker)
                .Include(i => i.transactions)
                .ToListAsync();
        }

        public async Task<List<Investment>> GetByPortfolioAsync(int portfolioId)
        {
            await using var db = await _dbFactory.CreateDbContextAsync();
            return await db.Investments
                .Where(i => i.portfolioId == portfolioId)
                .Include(i => i.transactions)
                .ToListAsync();
        }

        public async Task<Investment?> GetByIdAsync(int id)
        {
            await using var db = await _dbFactory.CreateDbContextAsync();
            return await db.Investments
                .Include(i => i.transactions)
                .FirstOrDefaultAsync(i => i.id == id);
        }

        public async Task AddAsync(Investment investment)
        {
            await using var db = await _dbFactory.CreateDbContextAsync();
            db.Investments.Add(investment);
            await db.SaveChangesAsync();
        }

        public async Task UpdateAsync(Investment investment)
        {
            await using var db = await _dbFactory.CreateDbContextAsync();
            db.Investments.Update(investment);
            await db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await using var db = await _dbFactory.CreateDbContextAsync();
            var investment = await db.Investments.FindAsync(id);
            if (investment != null)
            {
                db.Investments.Remove(investment);
                await db.SaveChangesAsync();
            }
        }

        public async Task<decimal> GetTotalValueAsync(int id)
        {
            await using var db = await _dbFactory.CreateDbContextAsync();
            var investment = await db.Investments.FindAsync(id);
            if (investment == null) return 0;
            return investment.quantity * investment.purchasePrice;
        }

    }
}
