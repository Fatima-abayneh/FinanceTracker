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

        public TransactionType Type { get; set; }

        [Required, StringLength(100)]
        public string Description { get; set; }

        [Required, DataType(DataType.Currency)]
        public decimal Amount { get; set; }

        
        public int CategoryId { get; set; }

        public Category Category { get; set; }

        [Required]
        public RecurrenceType RecurrenceType { get; set; }

        public DateTime NextOccurrence { get; set; }

       
    }
}
