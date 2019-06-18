using BudgetPlanner.Data.Models;
using System.Collections.Generic;

namespace BudgetPlanner.Models
{
    public class BudgetsViewModel
    {
        public BudgetsViewModel()
        {
            this.Budgets = new List<Budget>();
        }

        public IList<Budget> Budgets { get; set; }
    }
}
