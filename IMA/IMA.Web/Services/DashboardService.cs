using IMA.Shared.Interfaces;
using IMA.Shared.Models;
using IMA.Web.Data;
using Microsoft.EntityFrameworkCore;

namespace IMA.Web.Services
{
    public class DashboardService : IDashboard
    {
        private readonly AppDbContext _db;

        public DashboardService (AppDbContext db)
        {
            _db = db;
        }
        public async Task<DashboardSummary> GetSummaryAsync()
        {
            var investments = await _db.Investments
                .Include(i => i.porfolio)
                .ToListAsync();

            var totalValue = investments.Sum(i => i.quantity * i.purchasePrice);
            var totalPortfolios = await _db.Portfolios.CountAsync();

            return new DashboardSummary
            {
                totalValue = totalValue,
                totalPortfolios = totalPortfolios,
                totalPositions = investments.Count
            };
        }

        public async Task<Allocation> GetAllocation()
        {
            var investmetns = await _db.Investments.ToListAsync();
            var total = investmetns.Sum(i => i.quantity * i.purchasePrice);

            var allocation = new Allocation();

            allocation.allocationByType = investmetns
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
