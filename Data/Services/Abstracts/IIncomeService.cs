using BudgetPlanner.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetPlanner.Data.Services.Abstracts
{
    public interface IIncomeService
    {
        Task AddIncome(Income income);

        Task DeleteIncome(int incomeId);

        Task UpdateIncome(Income income);

        Task<Income> GetIncome(int incomeId);
    }
}
