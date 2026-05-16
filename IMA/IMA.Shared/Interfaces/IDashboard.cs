using IMA.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMA.Shared.Interfaces
{
    public interface IDashboard
    {
        Task<DashboardSummary> GetSummaryAsync();
        Task<Allocation> GetAllocation();
    }
}
