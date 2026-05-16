using System;
using System.Collections.Generic;
using System.Text;

namespace IMA.Shared.Models
{
    public class DashboardSummary
    {
        public decimal totalValue { get; set; }
        public int totalPortfolios { get; set; }
        public int totalPositions { get; set; }
    }

    public class Allocation
    {
        public Dictionary<string, decimal> allocationByType { get; set; } = new();
        public decimal totalValue { get; set; }
        public Dictionary<string, decimal> allcoationPercentage =>
            totalValue == 0 ? new() :
            allocationByType.ToDictionary(
                kvp => kvp.Key,
                kvp => Math.Round((kvp.Value / totalValue) * 100, 2)
            );
    }
}
