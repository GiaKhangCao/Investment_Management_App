namespace IMA.Web.Models
{
    public class Investment
    {
        public int id { get; set; }
        public string ticket { get; set; } = string.Empty;
        public string assetType { get; set; } = string.Empty;
        public decimal quantity { get; set; }
        public decimal purchasePrice { get; set; }
        public DateTime purchaseDate { get; set; }
        public int porfolioId { get; set; }
        public Portfolio? porfolio { get; set; } = null;
    }
}
