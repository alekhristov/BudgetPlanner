using BudgetPlanner.Data.Models.Abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BudgetPlanner.Data.Models
{
    public class Budget : ModelBase
    {
        public Budget()
        {
            this.Incomes = new HashSet<Income>();
            this.Categories = new HashSet<Category>();
        }

        public Month Month { get; set; }

        public decimal PlannedAmount { get; set; }

        public decimal AvailableAmount { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DateCreated { get; set; }

        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

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
