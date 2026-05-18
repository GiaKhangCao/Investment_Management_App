using IMA.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMA.Shared.Interfaces
{
    public interface IPortfolioService
    {
        Task<List<Portfolio>> GetAllAsync();
        Task AddAsync(Portfolio portfolio);
        Task DeleteAsync(int id);
    }
}
