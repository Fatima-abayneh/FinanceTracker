using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceTracker.Models
{
    public enum TransactionType
    {
        Income,
        Expense
    }
    public class Transaction
    {
        public int Id { get; set; }
        [Required, StringLength(100)]
        public string Description { get; set; }
        [Required, DataType(DataType.Currency)]
        public decimal Amount { get; set; }
        public TransactionType Type { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
