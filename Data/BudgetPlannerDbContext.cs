using BudgetPlanner.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BudgetPlanner.Data
{
    public class BudgetPlannerDbContext : IdentityDbContext
    {
        public BudgetPlannerDbContext(DbContextOptions<BudgetPlannerDbContext> options)
            : base(options)
        {
        }

        public DbSet<Budget> Budgets { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Payment> Payments { get; set; }

        public DbSet<Income> Incomes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Configuring one-to-many realationship between User and Permission tables
            builder
                .Entity<Category>()
                .HasOne(c => c.Budget)
                .WithMany(b => b.Categories);

            builder
                .Entity<Income>()
                .HasOne(i => i.Budget)
                .WithMany(b => b.Incomes);

            builder
                .Entity<Budget>()
                .HasOne(b => b.ApplicationUser)
                .WithMany(u => u.Budgets);

            builder
                .Entity<Income>()
                .HasOne(i => i.Budget)
                .WithMany(b => b.Incomes);

            builder
                .Entity<Payment>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Payments);

            // Enums registration as strings
            builder
                .Entity<ApplicationUser>()
                .Property(u => u.Gender)
                .HasConversion<string>();

            builder
                .Entity<Budget>()
                .Property(b => b.Month)
                .HasConversion<string>();

            builder
                .Entity<Income>()
                .Property(b => b.Type)
                .HasConversion<string>();

            base.OnModelCreating(builder);

            // Renaming default ASP .NET Core Identity table to "User" table
            builder
                .Entity<ApplicationUser>()
                .ToTable("User");
        }
    }
}
