using IMA.Shared.Interfaces;
using IMA.Web.Data;
using IMA.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace IMA.Web.Services
{
    public class PortfolioService : IPortfolioService
    {
        private readonly AppDbContext _db;
        public PortfolioService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<List<Portfolio>> GetAllAsync() =>
            await _db.Portfolios.Include(p => p.investments).ToListAsync();

        public async Task AddAsync(Portfolio portfolio)
        {
            _db.Portfolios.Add(portfolio);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var portfolio = await _db.Portfolios.FindAsync(id);
            if (portfolio != null)
            {
                _db.Portfolios.Remove(portfolio);
                await _db.SaveChangesAsync();
            }
        }
    }
}
