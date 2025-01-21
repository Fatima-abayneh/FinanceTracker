using System.ComponentModel.DataAnnotations;

namespace FinanceTracker.Models
{
    public class Category
    {
        public int Id { get; set; }

    [Required(ErrorMessage = "Name is required.")]
    [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")] // Assuming a reasonable limit
    public string Name { get; set; }

    [StringLength(200, ErrorMessage = "Description cannot exceed 200 characters.")]
    public string? Description { get; set; }

    [Required]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

    [Required(ErrorMessage = "Transaction type is required.")]
    public TransactionType Type { get; set; }

    public ICollection<Transaction>? Transactions { get; set; }

    public ICollection<Budget>? Budgets { get; set; }

    }
}
