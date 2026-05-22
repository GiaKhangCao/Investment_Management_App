using IMA.Shared.Interfaces;
using IMA.Shared.Models;
using IMA.Web.Data;
using Microsoft.EntityFrameworkCore;

namespace IMA.Web.Services
{
    public class DashboardService : IDashboard
    {
        private readonly IDbContextFactory<AppDbContext> _dbFactory;

        public DashboardService(IDbContextFactory<AppDbContext> dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public async Task<DashboardSummary> GetSummaryAsync()
        {
            await using var db = await _dbFactory.CreateDbContextAsync();

            var investments = await db.Investments
                .Include(i => i.portfolio)
                .ToListAsync();

            var totalValue = investments.Sum(i => i.quantity * i.purchasePrice);
            var totalPortfolios = await db.Portfolios.CountAsync();

            return new DashboardSummary
            {
                totalValue = totalValue,
                totalPortfolios = totalPortfolios,
                totalPositions = investments.Count
            };
        }

        public async Task<Allocation> GetAllocation()
        {
            await using var db = await _dbFactory.CreateDbContextAsync();

            var investments = await db.Investments.ToListAsync();

            var allocation = new Allocation();
            allocation.allocationByType = investments
                .GroupBy(i => i.assetType)
                .ToDictionary(
                    group => group.Key,
                    group => group.Sum(i => i.quantity * i.purchasePrice)
                );
            allocation.totalValue = allocation.allocationByType.Values.Sum();

            return allocation;
        }
    }
}
