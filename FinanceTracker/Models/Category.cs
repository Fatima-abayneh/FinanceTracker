using System.ComponentModel.DataAnnotations;

namespace FinanceTracker.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        [Required(ErrorMessage = "Budget is required")]
        //[Range(0, double.MaxValue, ErrorMessage = "Budget must be a positive number")]
        public double? CatBudget { get; set; } 
        public List <Transaction>? Transaction { get; set; }
        
    }
}
