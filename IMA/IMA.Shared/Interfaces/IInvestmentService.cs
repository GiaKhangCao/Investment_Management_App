using IMA.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMA.Shared.Interfaces
{
    public interface IInvestmentService
    {
        Task<List<Investment>> GetByPortfolioAsync(int portfolioId);
        Task<Investment?> GetByIdAsync(int id);
        Task AddAsync(Investment investment);
        Task UpdateAsync(Investment investment);
        Task DeleteAsync(int id);
        Task<decimal> GetTotalValueAsync(int id);
    }
}
