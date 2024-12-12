using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceTracker.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? Amount { get; set; }
        public DateTime? Date { get; set; }
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
