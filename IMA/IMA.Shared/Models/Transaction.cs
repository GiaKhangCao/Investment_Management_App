namespace IMA.Shared.Models
{
    public class Transaction
    {
        public int id { get; set; }
        public string type { get; set; } = string.Empty;
        public decimal amount { get; set; }
        public decimal date { get; set; }
        public int intvesmentId { get; set; }
        public Investment? investment { get; set; } = null;
    }
}
