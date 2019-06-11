using BudgetPlanner.Data.Models;
using BudgetPlanner.Data.Services.Abstracts;
using System;
using System.Threading.Tasks;

namespace BudgetPlanner.Data.Services
{
    public class IncomeService : IIncomeService
    {
        private readonly BudgetPlannerDbContext dbContext;

        public IncomeService(BudgetPlannerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddIncome(Income income)
        {
            this.dbContext.Incomes.Add(income);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task DeleteIncome(int incomeId)
        {
            var income = this.GetIncome(incomeId);

            this.dbContext.Remove(income);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<Income> GetIncome(int incomeId)
        {
            var income = await this.dbContext.Incomes.FindAsync(incomeId) ?? throw new NullReferenceException("No such income exists");

            return income;
        }

        public async Task UpdateIncome(Income income)
        {
            var incomeToUpdate = await this.GetIncome(income.Id);

            this.dbContext.Incomes.Update(income);
            await this.dbContext.SaveChangesAsync();
        }
    }
}
