using FinanceTracker.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FinanceTracker.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Budget> Budgets { get; set; }
        public DbSet<FinanceTracker.Models.RecurringTransaction>? RecurringTransaction { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        ////    modelBuilder.Entity<Category>()
        ////       .HasMany(c => c.Transaction)
        ////       .WithOne(t => t.Category)
        ////       .HasForeignKey(t => t.CategoryId);
        //}
    }
}
