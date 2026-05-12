using IMA.Web.Data;
using IMA.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace IMA.Web.Services
{
    public class InvestmentService
    {
        private readonly AppDbContext _db;
        public InvestmentService(AppDbContext db)
        {
            _db = db;
        }

        // Get all investments for a specific portfolio
        public async Task<List<Investment>> GetByPortfolioAsync(int portfolioId) =>
            await _db.Investments
                .Where(i => i.portfolioId == portfolioId)
                .Include(i => i.transactions)
                .ToListAsync();

        // Get a single investment by Id
        public async Task<Investment?> GetByIdAsync(int id) =>
            await _db.Investments
                .Include(i => i.transactions)
                .FirstOrDefaultAsync(i => i.id == id);

        // Add a new investment
        public async Task AddAsync(Investment investment)
        {
            _db.Investments.Add(investment);
            await _db.SaveChangesAsync();
        }

        // Update an existing investment
        public async Task UpdateAsync(Investment investment)
        {
            _db.Investments.Update(investment);
            await _db.SaveChangesAsync();
        }

        // Delete an investment
        public async Task DeleteAsync(int id)
        {
            var investment = await _db.Investments.FindAsync(id);
            if (investment != null)
            {
                _db.Investments.Remove(investment);
                await _db.SaveChangesAsync();
            }
        }

        // Calculate current total value of an investment
        public async Task<decimal> GetTotalValueAsync(int id)
        {
            var investment = await _db.Investments.FindAsync(id);
            if (investment == null) return 0;
            return investment.quantity * investment.purchasePrice;
        }
    }
}
