using System.ComponentModel.DataAnnotations;

namespace FinanceTracker.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [StringLength(200, ErrorMessage = "Description cannot exceed 200 characters.")]
        public string? Description { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public TransactionType Type { get; set; }
        public ICollection<Transaction>? Transactions { get; set; }
        public ICollection<Budget>? Budgets { get; set; }

    }
}
