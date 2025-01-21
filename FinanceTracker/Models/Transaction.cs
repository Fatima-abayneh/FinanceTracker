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

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(100, ErrorMessage = "Description cannot exceed 100 characters.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Amount is required.")]
        [DataType(DataType.Currency, ErrorMessage = "Invalid currency format.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than zero.")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "Transaction type is required.")]
        public TransactionType Type { get; set; }

        [Required(ErrorMessage = "Date is required.")]
        [DataType(DataType.Date, ErrorMessage = "Invalid date format.")]
        public DateTime Date { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Category ID is required.")]
        public int CategoryId { get; set; }

        public Category? Category { get; set; }
    }
}
