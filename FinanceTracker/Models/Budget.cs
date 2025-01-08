using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceTracker.Models
{
    public class Budget
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        [Required, DataType(DataType.Currency)]
        public decimal Amount { get; set; }
        [Required]
        public DateTime Month { get; set; }

        
    }
}
