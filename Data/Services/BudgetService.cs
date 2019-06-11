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
            var budgets = await this.dbContext.Budgets.Where(b => b.ApplicationUserId == userId).ToListAsync();

            if (budgets == null || budgets.Count == 0)
            {
                throw new NullReferenceException($"There is not budgets for user {userId}");
            }

            return budgets;
        }
    }
}
