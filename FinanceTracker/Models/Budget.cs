namespace FinanceTracker.Models
{
    public class Budget
    {
        public int id { get; set; }
        public string? name { get; set; }
        public double? InicialAmount { get; set; } 
        public double? CurrentAmount { get; set; } 
        public DateTime? startDate { get; set; }
        public DateTime? endDate { get; set; }
    }
}
