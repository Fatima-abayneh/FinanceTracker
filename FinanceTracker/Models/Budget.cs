using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceTracker.Models
{
    public class Budget
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Category ID is required.")]
        public int CategoryId { get; set; }

        public Category? Category { get; set; }

        [Required(ErrorMessage = "Amount is required.")]
        [DataType(DataType.Currency, ErrorMessage = "Invalid currency format.")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "Month is required.")]
        public DateTime Month { get; set; }

    }
}
