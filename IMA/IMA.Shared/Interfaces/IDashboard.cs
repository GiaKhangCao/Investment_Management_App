using IMA.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMA.Shared.Interfaces
{
    public interface IDashboard
    {
        Task<IDashboard> GetSummaryAsync();
        Task<List<MonthlyPerformance>> GethMonthlyPerformanceSync();
        Task<Allocation> GetAllocation();
    }
}
