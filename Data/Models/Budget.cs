using BudgetPlanner.Data.Models.Abstracts;
using System;
using System.Collections.Generic;

namespace BudgetPlanner.Data.Models
{
    public class Budget : ModelBase
    {
        public Month Month { get; set; }

        public decimal PlannedAmount { get; set; }

        public decimal AvailableAmount { get; set; }

        public DateTime DateCreated { get; set; }

        public int UserId { get; set; }

        public ApplicationUser User { get; set; }

        /// <summary>
        /// Navigation property - represents related entity
        /// </summary>
        public ICollection<Category> Categories { get; set; }

        /// <summary>
        /// Navigation property - represents related entity
        /// </summary>
        public ICollection<Income> Incomes { get; set; }
    }

    public enum Month
    {
        JANUARY,
        FEBRUARY,
        MARCH,
        APRIL,
        MAY,
        JUNE,
        JULY,
        AUGUST,
        SEPTEMBER,
        OCTOBER,
        NOVEMBER,
        DECEMBER
    }
}
