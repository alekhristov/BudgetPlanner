using BudgetPlanner.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetPlanner.Data.Services.Abstracts
{
    public interface IBudgetService
    {
        Task CreateMonthlyBudget(ICollection<Category> budgetCategories, ICollection<Income> incomes, string userId);

        Task<ICollection<Budget>> GetBudgetsForUser(string userId);

        Task<Budget> GetBudget(int budgetId);

        Task EditBudget(Budget updatedBudget);

        Task CopyOldBudget(int budgetId);
    }
}
