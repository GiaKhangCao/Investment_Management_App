namespace IMA.Web.Models
{
    public class Portfolio
    {
        public int id { get; set; }
        public string name { get; set; } = string.Empty;
        public string owner { get; set; } = string.Empty;
        public DateTime createdAt { get; set; }
        public List<Investment> investments  { get; set; } = new();
    }
}
