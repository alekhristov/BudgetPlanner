using BudgetPlanner.Data.Models.Abstracts;
using System;
using System.ComponentModel.DataAnnotations;

namespace BudgetPlanner.Data.Models
{
    public class Income : ModelBase
    {
        public IncomeType Type { get; set; }

        public decimal Amount { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }

        public int BudgetId { get; set; }

        public Budget Budget { get; set; }
    }

    public enum IncomeType
    {
        SALARY,
        RENT,
        INTEREST,
        DIVIDENDS,
        BONUSES
    }
}
