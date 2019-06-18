using BudgetPlanner.Data.Models;
using BudgetPlanner.Data.Services.Abstracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetPlanner.Data.Services
{
    public class BudgetService : IBudgetService
    {
        private readonly BudgetPlannerDbContext dbContext;

        public BudgetService(BudgetPlannerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task CopyOldBudget(int budgetId)
        {
            throw new NotImplementedException();
        }

        public async Task CreateMonthlyBudget(ICollection<Category> budgetCategories, ICollection<Income> incomes, string userId)
        {
            var budget = new Budget();

            foreach (var category in budgetCategories)
            {
                budget.PlannedAmount += category.PlannedAmount;
            }

            foreach (var income in incomes)
            {
                budget.AvailableAmount += income.Amount;
            }

            var user = await this.dbContext.Users.FindAsync(userId) ?? throw new NullReferenceException("No such user exists");

            budget.ApplicationUser = user;
            budget.ApplicationUserId = user.Id;
            budget.Month = (Month)DateTime.UtcNow.Month;

            this.dbContext.Budgets.Add(budget);
            await this.dbContext.SaveChangesAsync();

        }

        public async Task EditBudget(Budget updatedBudget)
        {
            var budget = await this.dbContext.Budgets.FindAsync(updatedBudget.Id) ?? throw new NullReferenceException("No such budget exists");

            this.dbContext.Budgets.Update(updatedBudget);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<Budget> GetBudget(int budgetId)
        {
            return await this.dbContext.Budgets.FindAsync(budgetId) ?? throw new NullReferenceException("No such budget exists");
        }

        public async Task<ICollection<Budget>> GetBudgetsForUser(string userId)
        {
            return await this.dbContext.Budgets.Where(b => b.ApplicationUserId == userId).ToListAsync();
        }

        public async Task<ICollection<Category>> GetCategoriesForBudget(int budgetId)
        {
            return await this.dbContext.Categories.Where(c => c.BudgetId == budgetId).ToListAsync();
        }

        public async Task<ICollection<Income>> GetIncomesForBudget(int budgetId)
        {
            return await this.dbContext.Incomes.Where(i => i.BudgetId == budgetId).ToListAsync();
        }

        public async Task CreateDummyBudget(string userId)
        {
            var budgets = await dbContext.Budgets.Where(b => b.ApplicationUserId == userId).ToListAsync();
            if (budgets ==  null || budgets.Count <= 0)
            {
                var budget = new Budget();
                var user = await dbContext.Users.FindAsync(userId) ?? throw new NullReferenceException("No such user exists");

                budget.ApplicationUser = user;
                budget.ApplicationUserId = user.Id;
                budget.Month = (Month) DateTime.UtcNow.Month - 1;
                budget.DateCreated = DateTime.UtcNow;

                dbContext.Budgets.Add(budget);
                await dbContext.SaveChangesAsync();

                var categories = new List<Category>()
                {
                    new Category()
                    {
                        Name = "Groceries",
                        DateCreated = DateTime.UtcNow,
                        Budget = budget
                    },
                    new Category()
                    {
                        Name = "Shopping",
                        DateCreated = DateTime.UtcNow,
                        Budget = budget
                    },
                    new Category()
                    {
                        Name = "Restaurants",
                        DateCreated = DateTime.UtcNow,
                        Budget = budget
                    },
                    new Category()
                    {
                        Name = "Transport",
                        DateCreated = DateTime.UtcNow,
                        Budget = budget
                    },
                    new Category()
                    {
                        Name = "Travel",
                        DateCreated = DateTime.UtcNow,
                        Budget = budget
                    },
                    new Category()
                    {
                        Name = "Entertaiment",
                        DateCreated = DateTime.UtcNow,
                        Budget = budget
                    },
                    new Category()
                    {
                        Name = "Health",
                        DateCreated = DateTime.UtcNow,
                        Budget = budget
                    },
                    new Category()
                    {
                        Name = "Services",
                        DateCreated = DateTime.UtcNow,
                        Budget = budget
                    },
                    new Category()
                    {
                        Name = "Utilities",
                        DateCreated = DateTime.UtcNow,
                        Budget = budget
                    },
                    new Category()
                    {
                        Name = "Cash",
                        DateCreated = DateTime.UtcNow,
                        Budget = budget
                    },
                    new Category()
                    {
                        Name = "Transfer",
                        DateCreated = DateTime.UtcNow,
                        Budget = budget
                    },
                    new Category()
                    {
                        Name = "Insurance",
                        DateCreated = DateTime.UtcNow,
                        Budget = budget
                    },
                    new Category()
                    {
                        Name = "Sport",
                        DateCreated = DateTime.UtcNow,
                        Budget = budget
                    },
                    new Category()
                    {
                        Name = "Home",
                        DateCreated = DateTime.UtcNow,
                        Budget = budget
                    }
                };
                dbContext.Categories.AddRange(categories);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
