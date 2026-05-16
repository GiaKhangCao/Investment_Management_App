using System;
using System.Collections.Generic;
using System.Text;

namespace IMA.Shared.Models
{
    public class DashboardSummary
    {
        public decimal totalValue { get; set; }
        public decimal todayGain { get; set; }
        public decimal todayGainPercent { get; set; }
        public int totalPortfolios { get; set; }
        public int totalPositions { get; set; }
        public decimal monthlyGain { get; set; }
    }

    public class MonthlyPerformance
    {
        public string month { get; set; } = string.Empty;
        public decimal value { get; set; }
    }

    public class Allocation
    {
        public decimal stockValu { get; set; }
        public decimal ETFsValue { get; set; }
        public decimal cashValue { get; set; }
    }
}
