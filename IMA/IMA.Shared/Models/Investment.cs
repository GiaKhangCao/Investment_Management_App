namespace IMA.Shared.Models
{
    public class Investment
    {
        public int id { get; set; }
        public string ticker { get; set; } = string.Empty;
        public string assetType { get; set; } = string.Empty;
        public decimal quantity { get; set; }
        public decimal purchasePrice { get; set; }
        public DateTime purchaseDate { get; set; }
        public int portfolioId { get; set; }
        public Portfolio? portfolio { get; set; } = null;
        public List<Transaction> transactions { get; set; } = new();
    }
}
