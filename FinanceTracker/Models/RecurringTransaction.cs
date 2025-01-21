using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FinanceTracker.Models
{

    public enum RecurrenceType
    {
        Daily,
        Weekly,
        Monthly,
        Yearly
    }
    public class RecurringTransaction
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Transaction type is required.")]
        public TransactionType Type { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(100, ErrorMessage = "Description cannot exceed 100 characters.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Amount is required.")]
        [DataType(DataType.Currency, ErrorMessage = "Invalid currency format.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than zero.")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "Category is required.")]
        public int CategoryId { get; set; }

        public Category? Category { get; set; }

        [Required(ErrorMessage = "Recurrence type is required.")]
        public RecurrenceType RecurrenceType { get; set; }

        [Required(ErrorMessage = "Next occurrence date is required.")]
        [DataType(DataType.Date, ErrorMessage = "Invalid date format.")]
        public DateTime NextOccurrence { get; set; }
    }
}
